using BCJ.Profit;
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace IBovTrackerWinUI
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class IBOVPage : Page
	{
		private MainWindow m_window = null;
		public IBOVPage()
		{
			this.DataContext = this;

			if (Microsoft.UI.Xaml.Application.Current is IBovTrackerWinUI.App app)
			{
				m_window = app.m_window;
			}

			this.InitializeComponent();
		}

		public string Redutor => m_window.ibov.Reductor.ToString(CultureInfo.CurrentCulture);

		public string IBOV => m_window.ibov.IBovReal.ToString("#");

		public string IBovTeorico => m_window.ibov.IBovTeorico.ToString("#");

		public string DataPregao => m_window.ibov.FromWhen.Date.ToString("d");

		public IEnumerable<RTDIBovItemModel> Stocks => m_window.ibov.Stocks;
	}
}
