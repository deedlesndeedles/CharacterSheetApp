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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CombatTrackerClient.Custom_Controls
{
    public sealed partial class LoadItem : UserControl
    {
        string Name, Campaign;
        string id;
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public LoadItem(string ID, string name, string campaign, int level)
        {
            this.InitializeComponent();

            Name = name;
            Campaign = campaign;
            id = ID;

            textName.Text = name;
            textCampaign.Text = campaign;
            textLevel.Text += level;
        }
    }
}
