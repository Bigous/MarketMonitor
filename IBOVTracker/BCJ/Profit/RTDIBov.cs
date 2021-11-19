using BCJ.B3;
using System.Data;
using System.Diagnostics;

namespace BCJ.Profit
{
	public delegate void AfterUpdate(RTDIBov rtdIBov);
	public class RTDIBov : IDisposable, RTDTrading.IRTDUpdateEvent
	{
		private const string CNTheoreticalPrice = "Preço teórico";
		private const string CNCotation = "Cotação";
		private const string CNClosed = "Fechamento";
		private const string CNTheoreticalVariation = "Variação Teórica";
		private const string CNVariation = "Variação";

		private readonly IBOV ibov;
		private RTDTrading.IRtdServer? profit;
		private readonly Dictionary<int, Topic> topics = new();
		public long Count { get; set; }
		public int HeartbeatInterval { get; set; }

		public double TheoreticalQuantity { get => ibov.TheoreticalQuantity; }
		public double Reductor { get => ibov.Reductor; }

		public DateTime FromWhen { get => ibov.FromWhen; }

		/// <summary>
		/// DataTable com os dados do IBOV e dados recuperados do Profit. Nunca interagir com ele diretamente. Sempre criar um DataView intermediário para agir com ele para não ter problema de atualização de dados.
		/// </summary>
		public DataTable Data { get => ibov.Data; }

		public Dictionary<int, Topic> Topics { get => topics; }

		public event AfterUpdate? AfterUpdate;

		public event AfterUpdate? AfterGapUpdate;

		public double AjusteWINFUT;
		public double IBOVFechamento;
		public double IBOVUltimo;
		public double WinFut;
		private string IBOVData;

		private RTDIBov(IBOV ib)
		{
			ibov = ib;
			IBOVData = "";
		}

		private static double CalcVariacao(double cotacao, double precoTeorico, double fechamento)
		{
			if (precoTeorico == 0)
			{
				return fechamento == 0 ? 0 : (cotacao - fechamento) / fechamento;
			}
			else
			{
				return 0.0;
			}
		}

		private static double CalcVariacaoTeorica(double cotacao, double precoTeorico)
		{
			if (precoTeorico == 0)
			{
				return 0.0;
			}
			else
			{
				return cotacao == 0 ? 0 : (precoTeorico - cotacao) / cotacao;
			}
		}

		#region Topic Update Events
		private void OnUpdateCotation(Topic t)
		{
			if (t.Reference is DataRow row && t.LastReceivedValue is double cotacao && t.RtdCode == $"{row["Code"]}_B_0")
			{
				double precoTeorico = row[CNTheoreticalPrice] as double? ?? 0.0;
				double fechamento = row[CNClosed] as double? ?? 0.0;

				row.BeginEdit();
				row[CNCotation] = cotacao;
				row[CNTheoreticalVariation] = CalcVariacaoTeorica(cotacao, precoTeorico);
				row[CNVariation] = CalcVariacao(cotacao, precoTeorico, fechamento);
				row.EndEdit();
			}
		}

		private void OnUpdateTheoreticalPrice(Topic t)
		{
			if (t.Reference is DataRow row && t.LastReceivedValue is double precoTeorico && t.RtdCode == $"{row["Code"]}_B_0")
			{
				double cotacao = row[CNCotation] as double? ?? 0.0;
				double fechamento = row[CNClosed] as double? ?? 0.0;

				row.BeginEdit();
				row[CNTheoreticalPrice] = precoTeorico;
				row[CNTheoreticalVariation] = CalcVariacaoTeorica(cotacao, precoTeorico);
				row[CNVariation] = CalcVariacao(cotacao, precoTeorico, fechamento);
				row.EndEdit();
			}
		}

		private void OnUpdateClose(Topic t)
		{
			if (t.Reference is DataRow row && t.LastReceivedValue is double fechamento && t.RtdCode == $"{row["Code"]}_B_0")
			{
				double precoTeorico = row[CNTheoreticalPrice] as double? ?? 0.0;
				double cotacao = row[CNCotation] as double? ?? 0.0;

				row.BeginEdit();
				row[CNClosed] = fechamento;
				row[CNTheoreticalVariation] = CalcVariacaoTeorica(cotacao, precoTeorico);
				row[CNVariation] = CalcVariacao(cotacao, precoTeorico, fechamento);
				row.EndEdit();
			}
		}

		private void UpdateData()
		{
			lock (this)
			{
				if (isDisposed)
					return;

				var refresh = GetRtdServer().RefreshData(topics.Count);

				var qtdNotifications = refresh.GetLength(1);
				for (int j = 0; j < qtdNotifications; j++)
				{
					if (refresh.GetValue(0, j) is int topicId)
					{
						if (topics.TryGetValue(topicId, out Topic? t) && t != null)
						{
							object? val = refresh.GetValue(1, j);
							if (val != null)
								t.LastReceivedValue = val;
						}
						else
						{
							Debug.WriteLine($"What came? {refresh.GetValue(0, j)}  -- {refresh.GetValue(1, j)}");
						}
					}
				}
				try
				{
					AfterUpdate?.Invoke(this);
				}
				catch { }
			}
		}
		#endregion


		public async static Task<RTDIBov> LoadRTDIBov()
		{
			var rtdibov = new RTDIBov(await IBOV.LoadIBOV());

			rtdibov.ibov.Data.Columns.Add(CNTheoreticalPrice, typeof(double));
			rtdibov.ibov.Data.Columns.Add(CNCotation, typeof(double));
			rtdibov.ibov.Data.Columns.Add(CNClosed, typeof(double));
			rtdibov.ibov.Data.Columns.Add(CNTheoreticalVariation, typeof(double));
			rtdibov.ibov.Data.Columns.Add(CNVariation, typeof(double));

			RTDTrading.IRtdServer server = rtdibov.GetRtdServer();
			var rows = rtdibov.ibov.Data.Rows;

			// Criando os tópicos a serem ouvidos...

			// Topicos referente ao IBOV
			for (int i = 0; i < rows.Count; i++)
			{
				var row = rows[i];
				if (row["Code"] is string code)
				{
					string rtdId = code + "_B_0";

					rtdibov.CreateTopic(new Topic(rtdId, "ULT", row, rtdibov.OnUpdateCotation));
					rtdibov.CreateTopic(new Topic(rtdId, "PRT", row, rtdibov.OnUpdateTheoreticalPrice));
					rtdibov.CreateTopic(new Topic(rtdId, "FEC", row, rtdibov.OnUpdateClose));
				}
			}

			// Tópicos referente aos dados adicionais
			// Ajuste do WINFUT
			rtdibov.CreateTopic(new Topic("WINFUT_F_0", "AJA", rtdibov, t =>
			{
				if (t.Reference is RTDIBov r && t.LastReceivedValue is double val)
				{
					r.AjusteWINFUT = val;
				}
			}));

			// WINFUT - ultimo
			rtdibov.CreateTopic(new Topic("WINFUT_F_0", "ULT", rtdibov, t =>
			{
				if (t.Reference is RTDIBov r && t.LastReceivedValue is double val)
				{
					r.WinFut = val;
				}
			}));

			// Fechamento do IBOV
			rtdibov.CreateTopic(new Topic("IBOV_B_0", "FEC", rtdibov, t =>
			{
				if (t.Reference is RTDIBov r && t.LastReceivedValue is double val)
				{
					r.IBOVFechamento = val;
				}
			}));

			// Ultimo IBOV
			rtdibov.CreateTopic(new Topic("IBOV_B_0", "ULT", rtdibov, t =>
			{
				if (t.Reference is RTDIBov r && t.LastReceivedValue is double val)
				{
					r.IBOVUltimo = val;
				}
			}));

			// IBOV - data de referencia
			rtdibov.CreateTopic(new Topic("IBOV_B_0", "DAT", rtdibov, t =>
			{
				if (t.Reference is RTDIBov r && t.LastReceivedValue is string str)
				{
					r.IBOVData = str;
					r.AfterGapUpdate?.Invoke(r);
				}
			}));

			// Inicia a atualização agora que está tudo setado corretamente.
			rtdibov.StartTopics();

			return rtdibov;
		}

		public void AddTopic(Topic t)
		{
			topics.Add(t.Id, t);
			object ret = GetRtdServer().ConnectData(t.Id, t.RtdTopic(), true);
			t.LastReceivedValue = ret;
		}

		private void CreateTopic(Topic t)
		{
			topics.Add(t.Id, t);
		}

		private void StartTopics()
		{
			foreach (var t in topics.Values)
			{
				object ret = GetRtdServer().ConnectData(t.Id, t.RtdTopic(), true);
				t.LastReceivedValue = ret;
			}
		}

		#region RTDTrading.IRTDUpdateEvent Members
		public void UpdateEvent()
		{
			// Do not call the RTD Heartbeat()
			// method.
			HeartbeatInterval = -1;
		}

		public void UpdateNotify()
		{
			Count++;
			Task.Run(() => this.UpdateData());
		}

		public void Disconnect()
		{
			// Do nothing
		}
		#endregion

		#region Singleton de acesso ao RTDServer do profit
		RTDTrading.IRtdServer GetRtdServer()
		{
			if (profit == null)
			{
				Type? rtd = Type.GetTypeFromProgID("rtdtrading.rtdserver");
				if (rtd != null)
				{
					profit = (RTDTrading.IRtdServer?)Activator.CreateInstance(rtd);
					if (profit != null)
					{
						// Create the updateEvent.
						profit.ServerStart(this);
					}
				}
			}
			if (profit == null)
				throw new Exception("Não pude criar o server RTD");
			return profit;
		}
		#endregion

		#region IDisposable Support
		private bool isDisposed = false;
		public void Dispose()
		{
			// To debug this, as it's running in the application termination, we must keep the debugger running.
			// System.Diagnostics.Debugger.Launch();
			lock (this)
			{
				if (isDisposed) return;
				isDisposed = true;
			}

			var server = GetRtdServer();
			foreach (int t in topics.Keys)
			{
				server.DisconnectData(t);
			}
			server.ServerTerminate();
			profit = null;
			ibov.Dispose();

			GC.SuppressFinalize(this);
		}

		~RTDIBov() => Dispose();
		#endregion

		#region IBovUtils

		// TODO: IBovUtils poderiam ser pré-calculados sempre, sem a necessidade de iterar sobre todo o DataSet toda vez, do mesmo modo que a variação é feita... Só precisa ver o que é menos custoso... Outra ideia é ter uma variável que indica se precisa ser recalculado, se precisar, recalcula, se não usa a última calculada.
		public double IBovReal
		{
			get
			{
				double ret = 0.0;
				foreach (DataRow row in Data.Rows)
				{
					double tq = (double)row["Theoretical Quantity"];
					double cot = 0.0;
					if (row[CNCotation] is double cotacao && cotacao > 0.0)
						cot = cotacao;
					else if (row[CNClosed] is double fechamento && fechamento > 0.0)
						cot = fechamento;
					ret += tq * cot;
				}
				return ret / Reductor;
			}
		}

		public double IBovTeorico
		{
			get
			{
				double ret = 0.0;
				foreach (DataRow row in Data.Rows)
				{
					double tq = (double)row["Theoretical Quantity"];
					double cot = 0.0;
					if (row["Preço Teórico"] is double pt && pt > 0.0)
						cot = pt;
					else if (row[CNCotation] is double cotacao && cotacao > 0.0)
						cot = cotacao;
					else if (row[CNClosed] is double fechamento && fechamento > 0.0)
						cot = fechamento;

					ret += tq * cot;
				}
				return ret / Reductor;
			}
		}

		public int IBovEmLeilao
		{
			get
			{
				int ret = 0;
				foreach (DataRow row in Data.Rows)
				{
					if (row["Preço Teórico"] is double pt && pt > 0.0)
						ret++;
				}
				return ret;
			}
		}

		public double IBovReprLeilao
		{
			get
			{
				double ret = 0.0;
				foreach (DataRow row in Data.Rows)
				{
					if (row["Preço Teórico"] is double pt && pt > 0.0)
						if (row["Theoretical Quantity"] is double tq)
							ret += tq * pt;
				}
				return (ret / Reductor) / IBovTeorico;
			}
		}

		public double GapWinIBov
		{
			get
			{
				return AjusteWINFUT - IBovFechamentoReal;
			}
		}

		public double IBovFechamentoReal
		{
			get
			{
				if (DateTime.Now.ToString("d/M/yyyy") == IBOVData)
					return IBOVFechamento;
				return IBOVUltimo;
			}
		}
		#endregion
	}
}