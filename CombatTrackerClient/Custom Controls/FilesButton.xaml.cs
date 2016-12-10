using CombatTrackerClient.Tools;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CombatTrackerClient
{
	public sealed partial class FilesButton : UserControl
	{
		public Type Type { get; private set; }
		public bool IsActive { get; private set; }
        public Action Function { get; private set; }

		public FilesButton()
		{
			this.InitializeComponent();
		}

		private void FilesGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
		{
			if(!IsActive && !MainPage.IsClicking)
				FilesGrid.Background = App.Colors.BUTTON_HOVER;
			else if(MainPage.IsClicking && MainPage.BeingClicked == this)
				FilesGrid.Background = App.Colors.BUTTON_CLICK;
		}

		private void FilesGrid_PointerExited(object sender, PointerRoutedEventArgs e)
		{
			if(!IsActive)
				FilesGrid.Background = App.Colors.BUTTON_IDLE_LEFT;
		}

		public void SetLoadType(LoadType type)
		{
            switch (type)
            {//https://msdn.microsoft.com/en-us/windows/uwp/style/segoe-ui-symbol-font
                case LoadType.NEW: Symbol.Text = "\xE1E2"; Text.Text = "New"; Function = new Action(Create); break;
                case LoadType.LOAD: Symbol.Text = "\xE8DA"; Text.Text = "Load"; Function = new Action(Load); break;
                case LoadType.DELETE: Symbol.Text = "\xE74D"; Text.Text = "Delete"; Function = new Action(Delete); break;
                case LoadType.SORT: Symbol.Text = "\xE174"; Text.Text = "Sort Options"; Function = new Action(Sort); break;
                case LoadType.MENU: Symbol.Text = "\xE10F"; Text.Text = "Load Menu"; Function = new Action(Menu); break;
            }
		}

		public void MakeActive(bool isActive)
		{
			FilesGrid.Background = isActive ? App.Colors.BUTTON_SELECTED : App.Colors.BUTTON_IDLE_LEFT;
			IsActive = isActive;
		}

		public void Clicked(bool clickDown)
		{
			FilesGrid.Background = App.Colors.BUTTON_CLICK;
		}

        private async void Create()
        {
            Character character = new Character();

            character.ID = CharacterSerializer.GenerateID();

            CharacterSerializer.AddCharacterToSerializationList(character);
            await CharacterSerializer.Serialize();

            MainPage.MAINPAGE.SwitchCharacter(character);
            
            //System.Diagnostics.Debug.WriteLine("Created!");
        }

        private void Load()
        {
            MainPage.MAINPAGE.SwitchCharacter();

            //System.Diagnostics.Debug.WriteLine("Load!");
        }

        private void Delete()
        {
            MainPage.MAINPAGE.DeleteChar();
        }

        private void Menu()
        {
            MainPage.MAINPAGE.LoadMenu();
        }

        private void Sort()
        {
            System.Diagnostics.Debug.WriteLine("Sorted!");
        }
    }
}
