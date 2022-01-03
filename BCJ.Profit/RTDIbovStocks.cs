using BCJ.B3;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCJ.Profit
{
	public delegate void AfterUpdateStocks(RTDIbovStocks rtdIBov);
	public class RTDIbovStocks : RTDTrading.IRTDUpdateEvent
	{
		private RTDTrading.IRtdServer? profit;
		private readonly Dictionary<int, Topic> topics = new();
		public long Count { get; set; }
		public int HeartbeatInterval { get; set; }

		public double TheoreticalQuantity;
		public double Reductor;

		public DateTime FromWhen;

		public ObservableCollection<RTDIBovItemModel> Stocks;


		public Dictionary<int, Topic> Topics { get => topics; }

		public event AfterUpdateStocks? AfterUpdate;

		public event AfterUpdateStocks? AfterGapUpdate;

		public double AjusteWINFUT;
		public double IBOVFechamento;
		public double IBOVUltimo;
		public double WinFut;
		private string IBOVData;

		private RTDIbovStocks(IBovStocks ibs)
		{
			TheoreticalQuantity = ibs.TheoreticalQuantity;
			Reductor = ibs.Reductor;
			FromWhen = ibs.FromWhen;
			Stocks = new ObservableCollection<RTDIBovItemModel>(
				from stock in ibs.Stocks
				select new RTDIBovItemModel(stock)
			);
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
			if (t.Reference is RTDIBovItemModel stock && t.LastReceivedValue is double cotacao && t.RtdCode == $"{stock.Code}_B_0")
			{
				double precoTeorico = stock.PrecoTeorico;
				double fechamento = stock.Fechamento;

				stock.Cotacao = cotacao;
				stock.VariacaoTeorica = CalcVariacaoTeorica(cotacao, precoTeorico);
				stock.Variacao = CalcVariacao(cotacao, precoTeorico, fechamento);
			}
		}

		private void OnUpdateTheoreticalPrice(Topic t)
		{
			if (t.Reference is RTDIBovItemModel stock && t.LastReceivedValue is double precoTeorico && t.RtdCode == $"{stock.Code}_B_0")
			{
				double cotacao = stock.Cotacao;
				double fechamento = stock.Fechamento;

				stock.PrecoTeorico = precoTeorico;
				stock.VariacaoTeorica = CalcVariacaoTeorica(cotacao, precoTeorico);
				stock.Variacao = CalcVariacao(cotacao, precoTeorico, fechamento);
			}
		}

		private void OnUpdateClose(Topic t)
		{
			if (t.Reference is RTDIBovItemModel stock && t.LastReceivedValue is double fechamento && t.RtdCode == $"{stock.Code}_B_0")
			{
				double precoTeorico = stock.PrecoTeorico;
				double cotacao = stock.Cotacao;

				stock.Fechamento = fechamento;
				stock.VariacaoTeorica = CalcVariacaoTeorica(cotacao, precoTeorico);
				stock.Variacao = CalcVariacao(cotacao, precoTeorico, fechamento);
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
				catch (Exception e)
				{
					Debug.WriteLine(e);
				}
			}
		}
		#endregion


		public async static Task<RTDIbovStocks> LoadRTDIbovStocks()
		{
			var rtdibov = new RTDIbovStocks(await IBovStocks.LoadIBOVStocks());

			RTDTrading.IRtdServer server = rtdibov.GetRtdServer();

			// Criando os tópicos a serem ouvidos...

			// Topicos referente ao IBOV
			foreach (var stock in rtdibov.Stocks)
			{
				string rtdId = stock.Code + "_B_0";

				rtdibov.CreateTopic(new Topic(rtdId, "ULT", stock, rtdibov.OnUpdateCotation));
				rtdibov.CreateTopic(new Topic(rtdId, "PRT", stock, rtdibov.OnUpdateTheoreticalPrice));
				rtdibov.CreateTopic(new Topic(rtdId, "FEC", stock, rtdibov.OnUpdateClose));
			}

			// Tópicos referente aos dados adicionais
			// Ajuste do WINFUT
			rtdibov.CreateTopic(new Topic("WINFUT_F_0", "AJA", rtdibov, t =>
			{
				if (t.Reference is RTDIbovStocks r && t.LastReceivedValue is double val)
				{
					r.AjusteWINFUT = val;
				}
			}));

			// WINFUT - ultimo
			rtdibov.CreateTopic(new Topic("WINFUT_F_0", "ULT", rtdibov, t =>
			{
				if (t.Reference is RTDIbovStocks r && t.LastReceivedValue is double val)
				{
					r.WinFut = val;
				}
			}));

			// Fechamento do IBOV
			rtdibov.CreateTopic(new Topic("IBOV_B_0", "FEC", rtdibov, t =>
			{
				if (t.Reference is RTDIbovStocks r && t.LastReceivedValue is double val)
				{
					r.IBOVFechamento = val;
				}
			}));

			// Ultimo IBOV
			rtdibov.CreateTopic(new Topic("IBOV_B_0", "ULT", rtdibov, t =>
			{
				if (t.Reference is RTDIbovStocks r && t.LastReceivedValue is double val)
				{
					r.IBOVUltimo = val;
				}
			}));

			// IBOV - data de referencia
			rtdibov.CreateTopic(new Topic("IBOV_B_0", "DAT", rtdibov, t =>
			{
				if (t.Reference is RTDIbovStocks r && t.LastReceivedValue is string str)
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

			GC.SuppressFinalize(this);
		}

		~RTDIbovStocks() => Dispose();
		#endregion

		#region IBovUtils

		// TODO: IBovUtils poderiam ser pré-calculados sempre, sem a necessidade de iterar sobre todo o DataSet toda vez, do mesmo modo que a variação é feita... Só precisa ver o que é menos custoso... Outra ideia é ter uma variável que indica se precisa ser recalculado, se precisar, recalcula, se não usa a última calculada.
		public double IBovReal
		{
			get
			{
				double ret = 0.0;
				foreach (var stock in Stocks)
				{
					double cot = 0.0;
					if (stock.Cotacao > 0.0)
						cot = stock.Cotacao;
					else if (stock.Fechamento > 0.0)
						cot = stock.Fechamento;
					ret += stock.TheoreticalQuantity * cot;
				}
				return ret / Reductor;
			}
		}

		public double IBovTeorico
		{
			get
			{
				double ret = 0.0;
				foreach (var stock in Stocks)
				{
					double cot = 0.0;
					if (stock.PrecoTeorico > 0.0)
						cot = stock.PrecoTeorico;
					else if (stock.Cotacao > 0.0)
						cot = stock.Cotacao;
					else if (stock.Fechamento > 0.0)
						cot = stock.Fechamento;

					ret += stock.TheoreticalQuantity * cot;
				}
				return ret / Reductor;
			}
		}

		public double IBovTeoricoPonderado
		{
			get
			{
				double ret = 0.0;
				foreach (var stock in Stocks)
				{
					double cot = 0.0;
					if (stock.PrecoTeorico > 0.0)
					{
						cot = stock.PrecoTeorico;
						if (stock.Fechamento > 0.0)
						{
							double variacao = (stock.Fechamento - stock.PrecoTeorico) / stock.Fechamento;
							if (Math.Abs(variacao) > 0.05)
							{
								// se a variação for maior que 5%, cosiderar 10% da variação (ou seria melhor desconsiderar a variação?)
								// pt = fechamento + (fechamento * variacao * 0.1);
								// Mudei de ideia e estou desconsiderando a variação...
								cot = stock.Fechamento;
							}
						}
					}
					else if (stock.Cotacao > 0.0)
						cot = stock.Cotacao;
					else if (stock.Fechamento > 0.0)
						cot = stock.Fechamento;

					ret += stock.TheoreticalQuantity * cot;
				}
				return ret / Reductor;
			}
		}

		public int IBovEmLeilao
		{
			get
			{
				int ret = 0;
				foreach (var stock in Stocks)
				{
					if (stock.PrecoTeorico > 0.0)
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
				foreach (var stock in Stocks)
				{
					if (stock.PrecoTeorico > 0.0)
						ret += stock.TheoreticalQuantity * stock.PrecoTeorico;
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
