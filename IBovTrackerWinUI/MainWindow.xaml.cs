using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

using CommunityToolkit.WinUI.UI.Controls;

using BCJ.Profit;
using System.Threading;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace IBovTrackerWinUI
{
	/// <summary>
	/// An empty window that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainWindow : Window
	{
		public IntPtr hwnd;
		public RTDIbovStocks ibov;
		
		//readonly Microsoft.UI.Dispatching.DispatcherQueue dispatcherQueue = Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread();
		readonly public SynchronizationContext syncContext = SynchronizationContext.Current;

		public MainWindow()
		{
			this.InitializeComponent();

			hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);

			LoadData();
		}

		public TextBlock StatusLabel => statusLabel;

		#region DataLoader

		private async void LoadData()
		{
			statusLabel.Text = "Carregando dados da B3 e do Profit...";
			try
			{
				ibov = await RTDIbovStocks.LoadRTDIbovStocks();

				void lamb(RTDIbovStocks r)
				{
					syncContext.Post(state => { OnDataUpdated(); }, r);
				}

				ibov.AfterUpdate += lamb;
				OnLoadFinished();
			}
			catch (Exception e)
			{
				statusLabel.Text = $"{e.Message} - tente mais tarde.";
			}
		}

		private void OnDataUpdated()
		{
			//throw new NotImplementedException();
		}

		#endregion

		public UIElement TitleElement => CustomTitleBar;

		private void OnLoadFinished()
		{
			nvMenu.IsEnabled = true;
			nviGaps.IsSelected = true;
			statusLabel.Text = "Tudo pronto...";
		}

		public void NavigationView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
		{
			if (args.IsSettingsSelected)
			{
				contentFrame.Navigate(typeof(SettingsPage));
			}
			else
			{
				if (args.SelectedItem is NavigationViewItem selectedItem && selectedItem.Tag is string selectedItemTag)
				{
					string pageName = "IBovTrackerWinUI." + selectedItemTag;
					Type pageType = Type.GetType(pageName);
					contentFrame.Navigate(pageType);
				}
			}
		}
	}
}
