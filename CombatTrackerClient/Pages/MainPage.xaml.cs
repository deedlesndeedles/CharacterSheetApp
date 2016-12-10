//http://timokorinth.de/creating-circular-progress-bar-wpf-silverlight/
using CombatTrackerClient.Tools;
using System.Linq;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.UI.Xaml.Shapes;
using CombatTrackerClient.Custom_Controls;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace CombatTrackerClient
{
    public sealed partial class MainPage : Page
    {
        GridLength _twoHundredPix = new GridLength(175, GridUnitType.Pixel);
        GridLength _fiftyPix = new GridLength(50, GridUnitType.Pixel);

        public static bool IsClicking = false;
        public static object BeingClicked;

        NavigationButton _currentlySelected;

        public static MainPage MAINPAGE;
<<<<<<< HEAD
        public static Character CHARACTER;
        public static string LEADER_ID;
        public static int CURRENT_index;
=======
        public static Character CHARACTERcurrent, CHARACTERloaded;
        public static int SELECTEDparty;
>>>>>>> origin/master

        public MainPage()
        {
            MAINPAGE = this;

            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Colors.Black;
            titleBar.ForegroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = Colors.Black;
            titleBar.ButtonForegroundColor = Colors.White;
            titleBar.InactiveBackgroundColor = Colors.Black;
            titleBar.InactiveForegroundColor = App.Colors.BUTTON_CLICK.Color;
            titleBar.ButtonInactiveBackgroundColor = Colors.Black;
            titleBar.ButtonHoverBackgroundColor = App.Colors.BUTTON_IDLE_LEFT.Color;
            titleBar.ButtonHoverForegroundColor = Colors.White;

            InitializeComponent();
            NavCharacter.SetPageType(PageType.CHARACTER);
            NavBase.SetPageType(PageType.BASE);
            NavCombat.SetPageType(PageType.COMBAT);
            NavSkills.SetPageType(PageType.SKILLS);
            NavFeats.SetPageType(PageType.FEATS);
            NavInventory.SetPageType(PageType.INVENTORY);
            NavSpells.SetPageType(PageType.SPELLS);
            NavParty.SetPageType(PageType.PARTY);
            NavSettings.SetPageType(PageType.SETTINGS);
            NavSettings1.SetPageType(PageType.SETTINGS);

            NewCharacter.SetLoadType(LoadType.NEW);
            LoadCharacter.SetLoadType(LoadType.LOAD);
            DeleteCharacter.SetLoadType(LoadType.DELETE);
            SortOptions.SetLoadType(LoadType.SORT);
            NavCharactersMenu.SetLoadType(LoadType.MENU);

            LoadCharacters();

            //ChangePage(NavCharacter);
        }

        private async Task<bool> LoadCharacters()
        {
            CharacterSerializer.CharFolder = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFolderAsync("Appstate", Windows.Storage.CreationCollisionOption.OpenIfExists);
            await CharacterSerializer.Deserialize();

            UpdateLoadGrid();

            await CharacterSerializer.Serialize();

            return true;
        }

        public void UpdateLoadGrid()
        {
            gridView.Items.Clear();

            foreach (Character c in CharacterSerializer.Characters.Values)
            {
                if (c.PartyLeaderID == "self")
                    gridView.Items.Add(new LoadItem(c.ID, c.Name, c.Campaign, c.Level));
            }
        }

        public async Task<bool> LoadMenu()
        {
            gridView.Visibility = Visibility.Visible;
            gridFiles.Visibility = Visibility.Visible;
<<<<<<< HEAD
                        
=======

>>>>>>> origin/master
            await LoadCharacters();

            NavigationButton blank = new NavigationButton();
            blank.SetPageType(PageType.BLANK);
            ChangePage(blank);
<<<<<<< HEAD
                       
=======

>>>>>>> origin/master
            await CharacterSerializer.Serialize();

            return true;
        }

        public void SwitchCharacter(Character character)
        {
            gridView.Visibility = Visibility.Collapsed;
            gridFiles.Visibility = Visibility.Collapsed;

<<<<<<< HEAD
            CHARACTER = character;
            LEADER_ID = character.ID;
=======
            
            CHARACTERloaded = character;
            CHARACTERcurrent = CHARACTERloaded;
>>>>>>> origin/master

            CharacterSerializer.CURRENTindex = CharacterSerializer.FindCharacterIndex(CHARACTERloaded);

            ChangePage(NavCharacter);
        }

        public void SwitchCharacter()
        {
            if (gridView.SelectedItem != null)
            {
                gridView.Visibility = Visibility.Collapsed;
                gridFiles.Visibility = Visibility.Collapsed;

                //Select by Index
                //CHARACTER = CharacterSerializer.characters.Values.ElementAt(gridView.SelectedIndex);

                //Select by Character Indicated
<<<<<<< HEAD
                CHARACTER = CharacterSerializer.FindCharacterByID(((LoadItem)gridView.SelectedItem).ID);
                LEADER_ID = CHARACTER.ID;
=======
                CHARACTERcurrent = CharacterSerializer.FindCharacterByID(((LoadItem)gridView.SelectedItem).ID);
                CHARACTERloaded = CharacterSerializer.FindCharacterByID(((LoadItem)gridView.SelectedItem).ID);
>>>>>>> origin/master

                CharacterSerializer.CURRENTindex = CharacterSerializer.FindCharacterIndex(CHARACTERloaded);

                ChangePage(NavCharacter);
            }
        }

        public void DeleteChar()
        {
            if (gridView.SelectedItem != null)
            {
                //Select by Character Indicated
                Character c = CharacterSerializer.FindCharacterByID(((LoadItem)gridView.SelectedItem).ID);

                CharacterSerializer.RemoveCharacterFromSerializationList(c);

                UpdateLoadGrid();
            }
            else
            {
                Message.msg("Select a character to delete.");
            }
        }

        #region Navigation
        private void ChangePage(NavigationButton navButton)
		{
			if(_currentlySelected != null)
				_currentlySelected.MakeActive(false);

			navButton.MakeActive(true);
			Content.Navigate(navButton.Type);
			_currentlySelected = navButton;
		}

		private void Navigation_Pressed(object sender, PointerRoutedEventArgs e)
		{
			IsClicking = true;
			NavigationButton button = sender as NavigationButton;
			if(button != null && button != BeingClicked)
			{
				BeingClicked = button;
				button.Clicked(true);
			}
        }

		private void Pointer_Released(object sender, PointerRoutedEventArgs e)
		{
			IsClicking = false;
			NavigationButton button = sender as NavigationButton;
			if(button != null && BeingClicked == button)
				ChangePage(button);
		}

		private void Expand_Released(object sender, PointerRoutedEventArgs e)
		{
			ColumnDefinition expandColumnDef = MainGrid.ColumnDefinitions.ElementAt(0);

			expandColumnDef.Width = expandColumnDef.Width == _twoHundredPix ? _fiftyPix : _twoHundredPix;
			Expand.Background = App.Colors.BUTTON_HOVER;
		}

        private void LoadButton_Pressed(object sender, PointerRoutedEventArgs e)
        {
            IsClicking = true;
            FilesButton button = sender as FilesButton;
            if (button != null && button != BeingClicked)
            {
                BeingClicked = button;
                button.Clicked(true);
            }
        }

        private void LoadPointer_Released(object sender, PointerRoutedEventArgs e)
        {
            IsClicking = false;
            FilesButton button = sender as FilesButton;
            if (button != null && BeingClicked == button)
                button.Function();
        }

        private void Expand_Pressed(object sender, PointerRoutedEventArgs e)
		{
			Expand.Background = App.Colors.BUTTON_CLICK;
		}

		private void Hover_Enter(object sender, PointerRoutedEventArgs e)
		{
			Expand.Background = App.Colors.BUTTON_HOVER;
		}

		private void Hover_Exit(object sender, PointerRoutedEventArgs e)
		{
			Expand.Background = App.Colors.BUTTON_IDLE_LEFT;
		}
	}

	public enum PageType
	{
		CHARACTER, BASE, COMBAT, SKILLS, FEATS, INVENTORY, SPELLS, PARTY, SETTINGS, EXPAND, BLANK
	}

    public enum LoadType
    {
        NEW, LOAD, DELETE, SORT, MENU
    }
    #endregion
}
