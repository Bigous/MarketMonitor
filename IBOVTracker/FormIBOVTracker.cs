using BCJ.Profit;
using MaterialSkin;
using MaterialSkin.Controls;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text;

namespace IBOVTracker
{
	public partial class FormIBOVTracker : MaterialForm, IDisposable
	{
		private RTDIBov? ibov;
		public FormIBOVTracker()
		{
			InitializeComponent();
			var materialSkinManager = MaterialSkinManager.Instance;
			materialSkinManager.AddFormToManage(this);
			materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
		}

		private void CopyIBOVButton_Click(object sender, EventArgs e)
		{
			if (ibov is not null)
			{
				StringBuilder sb = new(ibov.Data.Rows.Count * 6);
				foreach (DataRow row in ibov.Data.Rows)
				{
					sb.Append($"{row["Code"]}, ");
				}
				sb.Length -= 2;
				Clipboard.SetText(sb.ToString());
				StatusLabel.Text = "IBOV copiado para o clipboard";
			}
		}

		#region Data Loader

		private void ConfigureIbovDGV(DataGridView dgv, Dictionary<string, string> columnFormats, List<string>? visibleColumns = null)
		{
			if (ibov == null) return;

			dgv.DataSource = new DataView(ibov.Data);
			foreach (DataGridViewColumn col in dgv.Columns)
			{
				col.Visible = visibleColumns == null || visibleColumns.Contains(col.Name);
				if (col.Visible)
				{
					col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
					if (columnFormats.TryGetValue(col.Name, out string? format))
					{
						col.DefaultCellStyle.Format = format;
					}
				}
			}

			dgv.CellFormatting += (object? sender, DataGridViewCellFormattingEventArgs e) =>
			{
				if (e.Value is double val && e.CellStyle.Format == "P")
				{
					if (val > 0.0)
						e.CellStyle.ForeColor = Color.DarkGreen;
					else
						e.CellStyle.ForeColor = Color.Red;
				}
				else
				{
					e.CellStyle.ForeColor = Color.FromArgb(20, 20, 20);
				}
			};

			dgv.CellFormatting += (object? sender, DataGridViewCellFormattingEventArgs e) =>
			{
				if (e.Value is double val && e.CellStyle.Format == "P")
				{
					if (val >= -0.05 && val <= 0.05)
						e.CellStyle.BackColor = Color.White;
					else
						e.CellStyle.BackColor = Color.Yellow;
				}
			};
		}

		private void MaintainDGVOk()
		{
			LeilaoValDGV.ClearSelection();
			LeilaoDesDGV.ClearSelection();
			MercadoValDGV.ClearSelection();
			MercadoDesDGV.ClearSelection();

			LeilaoValDGV.FirstDisplayedScrollingRowIndex = 0;
			LeilaoDesDGV.FirstDisplayedScrollingRowIndex = 0;
			MercadoValDGV.FirstDisplayedScrollingRowIndex = 0;
			MercadoDesDGV.FirstDisplayedScrollingRowIndex = 0;
		}


		private async void LoadData()
		{
			StatusLabel.Text = "Carregando dados da B3 e do Profit...";
			try
			{
				ibov = await RTDIBov.LoadRTDIBov();

				// DataGrids
				var columnFormats = new Dictionary<string, string>()
				{
					{"Theoretical Quantity", "N"},
					{"Part. (%)", "N"},
					{"Preço teórico", "C"},
					{"Cotação", "C"},
					{"Fechamento", "C"},
					{"Variação", "P"},
					{"Variação Teórica", "P"}
				};

				// IBOV
				ConfigureIbovDGV(IBOVDGV, columnFormats);

				// Leilões
				var leilaoCols = new List<string>() { "Code", "Variação Teórica" };

				// Leilao Valorização
				ConfigureIbovDGV(LeilaoValDGV, columnFormats, leilaoCols);
				LeilaoValDGV.Sort(LeilaoValDGV.Columns["Variação Teórica"], ListSortDirection.Descending);

				// Leilao Desvalorização
				ConfigureIbovDGV(LeilaoDesDGV, columnFormats, leilaoCols);
				LeilaoDesDGV.Sort(LeilaoDesDGV.Columns["Variação Teórica"], ListSortDirection.Ascending);

				// Mercados
				var mercadoCols = new List<string>() { "Code", "Variação" };

				// Mercados Valorização
				ConfigureIbovDGV(MercadoValDGV, columnFormats, mercadoCols);
				MercadoValDGV.Sort(MercadoValDGV.Columns["Variação"], ListSortDirection.Descending);

				// Mercados Desvalorização
				ConfigureIbovDGV(MercadoDesDGV, columnFormats, mercadoCols);
				MercadoDesDGV.Sort(MercadoDesDGV.Columns["Variação"], ListSortDirection.Ascending);

				MaintainDGVOk();

				ReductorLabel.Text = $"Redutor: {ibov.Reductor.ToString(CultureInfo.CurrentCulture)}";
				DateLabel.Text = ibov.FromWhen.Date.ToString("d");
				GAPTB.Text = ibov.GapWinIBov.ToString("#");

				void lamb(RTDIBov r)
				{
					if (!this.IsDisposed)
						this.Invoke((MethodInvoker)delegate { OnAfterIBOVUpdate(); });
				}

				ibov.AfterUpdate += lamb;
				lamb(ibov);
				StatusLabel.Text = "Tudo pronto!";
			}
			catch (Exception e)
			{
				StatusLabel.Text = $"{e.Message} - tente mais tarde.";
			}
		}

		private void OnAfterIBOVUpdate()
		{
			if (ibov == null)
				return;
			try
			{
				IBOVLabel.Text = ibov.IBovReal.ToString("#");
				IBOVTeoricoLabel.Text = ibov.IBovTeorico.ToString("#");
				WINFUTLabel.Text = ibov.WinFut.ToString("#");

				double gapTeorico = (ibov.IBovTeorico + double.Parse(GAPTB.Text)) - ibov.WinFut;
				GapTeoricoLabel.Text = gapTeorico.ToString("#");
				GapTeoricoLabel.UseAccent = gapTeorico < 0.0;

				EmLeilaoLabel.Text = ibov.IBovEmLeilao.ToString();
				ReprLeilaoLabel.Text = (ibov.IBovReprLeilao).ToString("0.00%");

				CalcLabel.Text = $"IBOV: {ibov.IBovReal:#} | Teórico: {ibov.IBovTeorico:#}";

				MaintainDGVOk();
			}
			catch
			{
				// FIXME: Alguns race condition podem gerar problemas... especialmente se o excel estiver executando o RTD ao mesmo tempo que esta aplicação... o Profit não envia corretamente os valores pra quem pediu. Envia todos para todo mundo que conectou.
			}
		}
		#endregion

		private void FormIBOVTracker_Load(object sender, EventArgs e) => LoadData();

		private void TopSwitch_CheckedChanged(object sender, EventArgs e)
		{
			this.TopMost = TopSwitch.Checked;
			if (TopSwitch.Checked)
			{
				StatusLabel.Text = "Janela com TopMost";
			}
			else
			{
				StatusLabel.Text = "Janela sem TopMost";
			}
		}

		#region IDisposable
		private bool isDisposing = false;
		public new void Dispose()
		{
			lock (this)
			{
				if (isDisposing) return;
				isDisposing = true;
			}
			if (ibov != null) ibov.Dispose();
			base.Dispose();
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}