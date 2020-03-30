using System;
using System.Collections.Generic;
using System.Net.Http;
using Dunjin.Model;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Dunjin
{
    public partial class HomePlayer : TabbedPage
    {
        Characters character;
        Weapons weapons;

        private string _weaponName;
        private string _weaponDmg;

        public HomePlayer(Characters character)
        {
            InitializeComponent();

            this.character = character;
            characterDetails.Text = character.CharName;
            BindingContext = character;
            CharacterMods();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            if (weapon1.Text == null && weapon2.Text == null)
            {

                character.CharWeap1 = "add weap";
                character.CharWeap2 = "add weap";
                character.CharWeap1Dmg = "0d0";
                character.CharWeap2Dmg = "0d0";

                await App.MobileService.GetTable<Characters>().UpdateAsync(character);
            }

        }

        //Calculates ability modifiers based on ability scores
        public void CharacterMods()
        {
            var strengthMod = Convert.ToInt32(decimal.Floor((character.CharStr - 10) / 2));
            var dexterityMod = Convert.ToInt32(decimal.Floor((character.CharDex - 10) / 2));
            var constitutionMod = Convert.ToInt32(decimal.Floor((character.CharCon - 10) / 2));           
            var wisdomMod = Convert.ToInt32(decimal.Floor((character.CharWis - 10) / 2));
            var intelligenceMod = Convert.ToInt32(decimal.Floor((character.CharInt - 10) / 2));
            var charismaMod = Convert.ToInt32(decimal.Floor((character.CharCha - 10) / 2));


            strMod.Text = strengthMod.ToString();
            dexMod.Text = dexterityMod.ToString();
            conMod.Text = constitutionMod.ToString();
            wisMod.Text = wisdomMod.ToString();
            intMod.Text = intelligenceMod.ToString();
            chaMod.Text = charismaMod.ToString();
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

        //Pulls results from pre-made list
        void OnTextChanged(object sender, EventArgs e)
        {

            SearchBar searchBar = (SearchBar)sender;
            
            searchResults.ItemsSource = Persistence.DataService.GetSearchResults(searchBar.Text);
        }


        public async void addWeap1Button_Clicked(System.Object sender, System.EventArgs e)
        {
            string url = "http://dnd5eapi.co/api/equipment/" + searchResults.SelectedItem;
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string result = await client.GetStringAsync(url);

            var resultObject = JObject.Parse(result);
            string weaponName = resultObject["name"].ToString();
            string weaponDmg = resultObject["damage"]["damage_dice"].ToString();

            weapon1.Text = weaponName;
            w1dmg.Text = weaponDmg;
        }

        public async void addWeap2Button_Clicked(System.Object sender, System.EventArgs e)
        {
            string url = "http://dnd5eapi.co/api/equipment/" + searchResults.SelectedItem;
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string result = await client.GetStringAsync(url);

            var resultObject = JObject.Parse(result);
            string weaponName = resultObject["name"].ToString();
            string weaponDmg = resultObject["damage"]["damage_dice"].ToString();

            weapon2.Text = weaponName;
            w2dmg.Text = weaponDmg;
        }

        public async void saveWeaps_Clicked(System.Object sender, System.EventArgs e)
        {
            /*weapons.WeaponName = weapon1.Text;
            weapons.WeaponDamage = w1dmg.Text;
            weapons.WeaponName2 = weapon2.Text;
            weapons.WeaponDamage2 = w2dmg.Text;
            weapons.UserId = App.user.Id;
            weapons.CharacterId = App.character.Id;
            weapons.CampaignId = App.campaign.Id;

            await App.MobileService.GetTable<Weapons>().UpdateAsync(weapons);*/

            character.CharWeap1 = weapon1.Text;
            character.CharWeap1Dmg = w1dmg.Text;
            character.CharWeap2 = weapon2.Text;
            character.CharWeap2Dmg = w2dmg.Text;

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);

            await DisplayAlert("Success", "Weapons Updated", "Ok");
            await Navigation.PushAsync(new HomePlayer(character));
        }



        public async void DD_API()
        {
            string url = "http://dnd5eapi.co/api/equipment/" + searchResults.SelectedItem;
            var handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            string result = await client.GetStringAsync(url);

            var resultObject = JObject.Parse(result);
            string weaponName = resultObject["name"].ToString();
            string weaponDmg = resultObject["damage"]["damage_dice"].ToString();

            _weaponName = weaponName;
            _weaponDmg = weaponDmg;
         }

        //Updates DB with character info
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
            await Navigation.PushAsync(new HomePlayer(character));
        }


    }
}
