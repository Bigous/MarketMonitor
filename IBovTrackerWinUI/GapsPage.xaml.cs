using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;

using BCJ.Profit;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace IBovTrackerWinUI
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class GapsPage : Page, INotifyPropertyChanged
	{
		private MainWindow m_window = null;
		Microsoft.UI.Dispatching.DispatcherQueue dispatcherQueue = Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread();

		public GapsPage()
		{
			this.DataContext = this;

			if (Microsoft.UI.Xaml.Application.Current is IBovTrackerWinUI.App app)
			{
				m_window = app.m_window;
			}

			this.InitializeComponent();

			tbGap.Text = m_window.ibov.GapWinIBov.ToString("#");

			m_window.ibov.AfterUpdate += Ibov_AfterUpdate;
			Ibov_AfterUpdate();
		}

		#region Binded Proprerties

		public void TbGap_Changed(object sender, TextChangedEventArgs e)
		{
			double gap = 0.0;
			double.TryParse(tbGap.Text, out gap);
			GAPTeorico = ((m_window.ibov.IBovTeorico + gap) - m_window.ibov.WinFut).ToString("#");
			GAPPonderado = ((m_window.ibov.IBovTeoricoPonderado + gap) - m_window.ibov.WinFut).ToString("#");
			m_window.ibov.Stocks[21].Variacao *= -1;
			Ibov_AfterUpdate();
		}

		private void Ibov_AfterUpdate(RTDIbovStocks rtd)
		{
			dispatcherQueue.TryEnqueue(Ibov_AfterUpdate);
		}

		private void Ibov_AfterUpdate()
		{
			try
			{
				double gap = 0.0;
				double.TryParse(tbGap.Text, out gap);

				IBOV = m_window.ibov.IBovReal.ToString("#");
				IBovTeorico = m_window.ibov.IBovTeorico.ToString("#");
				WINFUT = m_window.ibov.WinFut.ToString("#");
				GAPTeorico = ((m_window.ibov.IBovTeorico + gap) - m_window.ibov.WinFut).ToString("#");
				GAPPonderado = ((m_window.ibov.IBovTeoricoPonderado + gap) - m_window.ibov.WinFut).ToString("#");
				EmLeilao = m_window.ibov.IBovEmLeilao.ToString();
				ReprLeilao = m_window.ibov.IBovReprLeilao.ToString("0.00%");

				RaisePropertyChanged(nameof(MercadoAsc));
				RaisePropertyChanged(nameof(LeilaoAsc));
				RaisePropertyChanged(nameof(MercadoDesc));
				RaisePropertyChanged(nameof(LeilaoDesc));
			}
			catch { }
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void RaisePropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		private string _IBOV;
		private string _IBovTeorico;
		private string _WINFUT;
		private string _GAPTeorico;
		private string _GAPPonderado;
		private string _EmLeilao;
		private string _ReprLeilao;

		public string IBOV
		{
			get { return _IBOV; }
			set
			{
				if (!value.Equals(_IBOV))
				{
					_IBOV = value;
					RaisePropertyChanged(nameof(IBOV));
				}
			}
		}
		public string IBovTeorico
		{
			get { return _IBovTeorico; }
			set
			{
				if (!value.Equals(_IBovTeorico))
				{
					_IBovTeorico = value;
					RaisePropertyChanged(nameof(IBovTeorico));
				}
			}
		}
		public string WINFUT
		{
			get { return _WINFUT; }
			set
			{
				if (!value.Equals(_WINFUT))
				{
					_WINFUT = value;
					RaisePropertyChanged(nameof(WINFUT));
				}
			}
		}
		public string GAPTeorico
		{
			get { return _GAPTeorico; }
			set
			{
				if (!value.Equals(_GAPTeorico))
				{
					_GAPTeorico = value;
					RaisePropertyChanged(nameof(GAPTeorico));
				}
			}
		}
		public string GAPPonderado
		{
			get { return _GAPPonderado; }
			set
			{
				if (!value.Equals(_GAPPonderado))
				{
					_GAPPonderado = value;
					RaisePropertyChanged(nameof(GAPPonderado));
				}
			}
		}
		public string EmLeilao
		{
			get { return _EmLeilao; }
			set
			{
				if (!value.Equals(_EmLeilao))
				{
					_EmLeilao = value;
					RaisePropertyChanged(nameof(EmLeilao));
				}
			}
		}
		public string ReprLeilao
		{
			get { return _ReprLeilao; }
			set
			{
				if (!value.Equals(_ReprLeilao))
				{
					_ReprLeilao = value; RaisePropertyChanged(nameof(ReprLeilao));
				}
			}
		}

		public IOrderedEnumerable<RTDIBovItemModel> MercadoAsc => m_window.ibov.Stocks.OrderBy(c => c.Variacao);
		public IOrderedEnumerable<RTDIBovItemModel> MercadoDesc => m_window.ibov.Stocks.OrderByDescending(c => c.Variacao);
		public IOrderedEnumerable<RTDIBovItemModel> LeilaoAsc => m_window.ibov.Stocks.OrderBy(c => c.VariacaoTeorica);
		public IOrderedEnumerable<RTDIBovItemModel> LeilaoDesc => m_window.ibov.Stocks.OrderByDescending(c => c.VariacaoTeorica);

		#endregion

		public void BtIBOVToClipboard_Click(object sender, RoutedEventArgs e)
		{
			if (m_window.ibov is not null)
			{
				StringBuilder sb = new(m_window.ibov.Stocks.Count * 6);
				foreach (var stock in m_window.ibov.Stocks)
				{
					sb.Append($"{stock.Code}, ");
				}
				sb.Length -= 2;
				DataPackage dp = new();
				dp.RequestedOperation = DataPackageOperation.Copy;
				dp.SetText(sb.ToString());
				Clipboard.SetContent(dp);
				m_window.StatusLabel.Text = "IBOV copiado para o clipboard";
			}
		}

		public void TogTop_Toggled(object sender, RoutedEventArgs e)
		{
			SetTopmost(togTop.IsOn);
		}

		private void SetTopmost(bool isTopmost)
		{
			var topFlag = isTopmost ? PInvoke.User32.SpecialWindowHandles.HWND_TOPMOST : PInvoke.User32.SpecialWindowHandles.HWND_NOTOPMOST;
			var flags = PInvoke.User32.SetWindowPosFlags.SWP_NOMOVE | PInvoke.User32.SetWindowPosFlags.SWP_NOSIZE | PInvoke.User32.SetWindowPosFlags.SWP_SHOWWINDOW;

			_ = PInvoke.User32.SetWindowPos(m_window.hwnd, topFlag, 0, 0, 0, 0, flags);
		}
	}
}
