using CombatTrackerClient.Custom_Controls;
using CombatTrackerClient.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CombatTrackerClient
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class PartyPage : Page
	{
        private int selected; 

        public PartyPage()
		{
			this.InitializeComponent();

            LoadMembers();
		}

        private void LoadMembers()
        {
            gridView.Items.Clear();

<<<<<<< HEAD
            foreach (Character c in CharacterSerializer.characters.Values)
            {
                if (c.ID == MainPage.LEADER_ID || c.PartyLeaderID == MainPage.LEADER_ID)
                    gridView.Items.Add(new PartyItem(c));
            }

            gridView.SelectedIndex = MainPage.CURRENT_index;
=======
            gridView.Items.Add(new PartyItem(MainPage.CHARACTERloaded));

            foreach (Character c in MainPage.CHARACTERloaded.Party)
            {
                gridView.Items.Add(new PartyItem(c));
            }

            gridView.SelectedIndex = MainPage.SELECTEDparty;
>>>>>>> origin/master
        }

        private async Task<bool> AddMember()
        {
<<<<<<< HEAD
            Character character = new Character(MainPage.LEADER_ID);

            character.Name = Character.DEFAULT_NAME;
            character.ID = CharacterSerializer.GenerateID();

            CharacterSerializer.AddCharacterToSerializationList(character);
            await CharacterSerializer.Serialize();

            return true;
        }

        private async void buttonAddMember_Click(object sender, RoutedEventArgs e)
        {
            await AddMember();
=======
            MainPage.CHARACTERcurrent.Party.Add(new Character(MainPage.CHARACTERloaded.ID));

            CharacterSerializer.Serialize();
>>>>>>> origin/master

            LoadMembers();
        }

        private void buttonEditMember_Click(object sender, RoutedEventArgs e)
        {
            if (gridView.SelectedItem != null)
            {
<<<<<<< HEAD
                if (((PartyItem)gridView.SelectedItem).PartyMember != MainPage.CHARACTER)
                {
                    MainPage.CHARACTER = CharacterSerializer.FindCharacterByID(((PartyItem)gridView.SelectedItem).PartyMember.ID);

                    CharacterSerializer.CURRENTindex = CharacterSerializer.FindCharacterIndex(MainPage.CHARACTER);

                    MainPage.CURRENT_index = gridView.SelectedIndex;
                }
                else
                {
                    Message.msg("Character already selected.");
                }
            }
            else
                Message.msg("Please select a character.");
        }

        private void buttonDeleteMember_Click(object sender, RoutedEventArgs e)
        {
            if (gridView.SelectedItem != null)
            {
                if (((PartyItem)gridView.SelectedItem).PartyMember.ID != MainPage.LEADER_ID)
                {
                    //Message.msg("Do you want to delete?");
                    bool delete = Message.prompt("Do you want to permanently delete " + ((PartyItem)gridView.SelectedItem).PartyMember.Name + "?").Result;

                    //if (delete)
                    {
                        Character c = CharacterSerializer.FindCharacterByID(((PartyItem)gridView.SelectedItem).PartyMember.ID);

                        CharacterSerializer.RemoveCharacterFromSerializationList(c);

                        LoadMembers();
                    }
                }
                else
                    Message.msg("Cannot delete the party leader.");
            }
            else
            {
                Message.msg("Select a character to delete.");
=======
                if (MainPage.CHARACTERcurrent != ((PartyItem)gridView.SelectedItem).PartyMember)
                {
                    MainPage.CHARACTERcurrent = ((PartyItem)gridView.SelectedItem).PartyMember;
                    MainPage.SELECTEDparty = gridView.SelectedIndex;
                }
                else
                {
                    MessageDialog dialog = new MessageDialog("Character already selected.");
                    dialog.ShowAsync();
                }
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Select a character to edit.");
                dialog.ShowAsync();
>>>>>>> origin/master
            }
        }
    }
}
