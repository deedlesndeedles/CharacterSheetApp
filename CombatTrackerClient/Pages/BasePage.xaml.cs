using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using CombatTrackerClient.Custom_Controls;

namespace CombatTrackerClient
{
	public sealed partial class BasePage : Page
	{
		public BasePage()
		{
			this.InitializeComponent();
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			
		}
    }
}
