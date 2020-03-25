using System;
using System.Collections.Generic;
using Dunjin.Model;
using Xamarin.Forms;

namespace Dunjin
{
    public partial class HomePlayer : TabbedPage
    {
        Characters character;
        public HomePlayer(Characters character)
        {
            InitializeComponent();

            this.character = character;
            characterDetails.Text = character.CharName;
            BindingContext = character;
        }

        void updateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (confirmButton.IsVisible == false)
            {
                confirmButton.IsVisible = true;
            }
        }

        void cancelButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (confirmButton.IsVisible == true)
            {
                confirmButton.IsVisible = false;
            }
        }

        private async void confirmButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (charLevel.Text == null)
            {
                charLevel.Text = character.CharLevel.ToString();
            }
            if (characterDetails.Text == null)
            {
                characterDetails.Text = character.CharName;
            }
            if (charClass.Text == null)
            {
                charClass.Text = character.CharClass;
            }
            if (charRace.Text == null)
            {
                charRace.Text = character.CharRace;
            }
            if (charStr.Text == null)
            {
                charStr.Text = character.CharStr.ToString();
            }
            if (charDex.Text == null)
            {
                charDex.Text = character.CharDex.ToString();
            }
            if (charCon.Text == null)
            {
                charCon.Text = character.CharCon.ToString();
            }
            if (charInt.Text == null)
            {
                charInt.Text = character.CharInt.ToString();
            }
            if (charWis.Text == null)
            {
                charWis.Text = character.CharWis.ToString();
            }
            if (charCha.Text == null)
            {
                charCha.Text = character.CharCha.ToString();
            }
            if (charInit.Text == null)
            {
                charInit.Text = character.CharInit.ToString();
            }
            if (charAC.Text == null)
            {
                charAC.Text = character.CharAC.ToString();
            }
            if (charHP.Text == null)
            {
                charHP.Text = character.CharHP.ToString();
            }
            if (charTempHP.Text == null)
            {
                charTempHP.Text = character.CharTempHP.ToString();
            }

            character.CharName = characterDetails.Text;
            character.CharClass = charClass.Text;
            character.CharRace = charRace.Text;
            character.CharLevel = int.Parse(charLevel.Text);
            character.CharStr = int.Parse(charStr.Text);
            character.CharDex = int.Parse(charDex.Text);
            character.CharCon = int.Parse(charCon.Text);
            character.CharInt = int.Parse(charInt.Text);
            character.CharWis = int.Parse(charWis.Text);
            character.CharCha = int.Parse(charCha.Text);
            character.CharInit = int.Parse(charInit.Text);
            character.CharAC = int.Parse(charAC.Text);
            character.CharHP = int.Parse(charHP.Text);
            character.CharTempHP = int.Parse(charTempHP.Text);
            

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);

            await DisplayAlert("Success", "Character Stats Updated", "Ok");
        }
    }
}
