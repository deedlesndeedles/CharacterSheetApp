using CombatTrackerClient.Tools;
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
    public sealed partial class PartyItem : UserControl
    {
        Character partyMember;
        public Character PartyMember
        {
            get
            {
                return partyMember;
            }
            set
            {
                partyMember = value;
            }
        }

        public PartyItem(Character character)
        {
            this.InitializeComponent();

            partyMember = character;

<<<<<<< HEAD
            textName.Text = partyMember.Name;

            if (partyMember.PartyLeaderID != "self")
                symbolLeader.Visibility = Visibility.Collapsed;
=======
            System.Diagnostics.Debug.WriteLine(partyMember.CharName);

            textName.Text = partyMember.CharName;
>>>>>>> origin/master
        }
    }
}
