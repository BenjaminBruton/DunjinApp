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

        async void initRoll_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            int randomRoll = rand.Next(1, 21);
            int randomDexMod = Convert.ToInt32(dexMod.Text);
            int randomInitMod = character.CharInit;
            int initRoll = randomRoll + randomDexMod + randomInitMod;
            rollOutput.Text = initRoll.ToString();

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Initiative",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Initiative";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);
        }
        async void attackRoll1_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            int randomRoll = rand.Next(1, 21);
            int randomDexMod = Convert.ToInt32(dexMod.Text);
            int randomStrMod = Convert.ToInt32(strMod.Text);
            

            if (w1attackBonus.Text == null)
            {
                w1attackBonus.Text = 0.ToString();
            }

            int randomAttMod = Convert.ToInt32(w1attackBonus.Text);
            int dexAttRoll = randomRoll + randomDexMod + randomAttMod;
            int strAttRoll = randomRoll + randomStrMod + randomAttMod;

            if (dexSwitch.IsToggled)
            {
                rollOutput.Text = dexAttRoll.ToString();
            }
            else
            {
                rollOutput.Text = strAttRoll.ToString();
            }

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Attack1",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Attack1";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);
        }
        async void dmgRoll1_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            string dice = w1dmg.Text;
            string[] splitDice = dice.Split('d');
            int numDice = Convert.ToInt32(splitDice[0]);
            int sizeDice = Convert.ToInt32(splitDice[1]);

            //This is the damage calculated with weapon before MODS
            int dmgNoMod = numDice * rand.Next(1, sizeDice + 1);

            int randomDexMod = Convert.ToInt32(dexMod.Text);
            int randomStrMod = Convert.ToInt32(strMod.Text);

            int dexDmgRoll = dmgNoMod + randomDexMod;
            int strDmgRoll = dmgNoMod + randomStrMod;

            if (dexSwitch.IsToggled)
            {
                rollOutput.Text = dexDmgRoll.ToString();
            }
            else
            {
                rollOutput.Text = strDmgRoll.ToString();
            }

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Damage1",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Damage1";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);

        }
        async void attackRoll2_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            int randomRoll = rand.Next(1, 21);
            int randomDexMod = Convert.ToInt32(dexMod.Text);
            int randomStrMod = Convert.ToInt32(strMod.Text);


            if (w2attackBonus.Text == null)
            {
                w2attackBonus.Text = 0.ToString();
            }

            int randomAttMod = Convert.ToInt32(w2attackBonus.Text);
            int dexAttRoll = randomRoll + randomDexMod + randomAttMod;
            int strAttRoll = randomRoll + randomStrMod + randomAttMod;

            if (dexSwitch.IsToggled)
            {
                rollOutput.Text = dexAttRoll.ToString();
            }
            else
            {
                rollOutput.Text = strAttRoll.ToString();
            }

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Attack2",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Attack2";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);
        }
        async void dmgRoll2_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            string dice = w2dmg.Text;
            string[] splitDice = dice.Split('d');
            int numDice = Convert.ToInt32(splitDice[0]);
            int sizeDice = Convert.ToInt32(splitDice[1]);

            //This is the damage calculated with weapon before MODS
            int dmgNoMod = numDice * rand.Next(1, sizeDice + 1);

            int randomDexMod = Convert.ToInt32(dexMod.Text);
            int randomStrMod = Convert.ToInt32(strMod.Text);

            int dexDmgRoll = dmgNoMod + randomDexMod;
            int strDmgRoll = dmgNoMod + randomStrMod;

            if (dexSwitch.IsToggled)
            {
                rollOutput.Text = dexDmgRoll.ToString();
            }
            else
            {
                rollOutput.Text = strDmgRoll.ToString();
            }

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Damage2",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Damage2";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);
        }
        async void strRoll_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            int randomRoll = rand.Next(1, 21);
            int randomStrMod = Convert.ToInt32(strMod.Text);
            int strengthRoll = randomRoll + randomStrMod;
            rollOutput.Text = strengthRoll.ToString();

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Strength",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Strength";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);
        }
        async void dexRoll_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            int randomRoll = rand.Next(1, 21);
            int randomDexMod = Convert.ToInt32(dexMod.Text);
            int dexterityRoll = randomRoll + randomDexMod;
            rollOutput.Text = dexterityRoll.ToString();

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Dexterity",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Dexterity";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);
        }
        async void conRoll_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            int randomRoll = rand.Next(1, 21);
            int randomConMod = Convert.ToInt32(conMod.Text);
            int constitutionRoll = randomRoll + randomConMod;
            rollOutput.Text = constitutionRoll.ToString();

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Constitution",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Constitution";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);
        }
        async void intRoll_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            int randomRoll = rand.Next(1, 21);
            int randomIntMod = Convert.ToInt32(intMod.Text);
            int intelligenceRoll = randomRoll + randomIntMod;
            rollOutput.Text = intelligenceRoll.ToString();

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Intelligence",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Intelligence";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);
        }
        async void wisRoll_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            int randomRoll = rand.Next(1, 21);
            int randomWisMod = Convert.ToInt32(wisMod.Text);
            int wisdomRoll = randomRoll + randomWisMod;
            rollOutput.Text = wisdomRoll.ToString();

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Wisdom",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Wisdom";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);
        }
        async void chaRoll_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            int randomRoll = rand.Next(1, 21);
            int randomChaMod = Convert.ToInt32(chaMod.Text);
            int charismaRoll = randomRoll + randomChaMod;
            rollOutput.Text = charismaRoll.ToString();

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Charisma",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Charisma";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);
        }
        async void manualRoll_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();

            if (d2Multiple.Text == null)
            {
                d2Multiple.Text = 0.ToString();
            }
            if (d3Multiple.Text == null)
            {
                d3Multiple.Text = 0.ToString();
            }
            if (d4Multiple.Text == null)
            {
                d4Multiple.Text = 0.ToString();
            }
            if (d6Multiple.Text == null)
            {
                d6Multiple.Text = 0.ToString();
            }
            if (d8Multiple.Text == null)
            {
                d8Multiple.Text = 0.ToString();
            }
            if (d10Multiple.Text == null)
            {
                d10Multiple.Text = 0.ToString();
            }
            if (d12Multiple.Text == null)
            {
                d12Multiple.Text = 0.ToString();
            }
            if (d20Multiple.Text == null)
            {
                d20Multiple.Text = 0.ToString();
            }
            if (modsEntry.Text == null)
            {
                modsEntry.Text = 0.ToString();
            }
            /*
            int d2 = (rand.Next(1, 3));
            int d3 = (rand.Next(1, 4));
            int d4 = (rand.Next(1, 5));
            int d6 = (rand.Next(1, 7));
            int d8 = (rand.Next(1, 9));
            int d10 = (rand.Next(1, 11));
            int d12 = (rand.Next(1, 13));
            int d20 = (rand.Next(1, 21));
            */
            int d2m = Convert.ToInt32(d2Multiple.Text);
            int d3m = Convert.ToInt32(d3Multiple.Text);
            int d4m = Convert.ToInt32(d4Multiple.Text);
            int d6m = Convert.ToInt32(d6Multiple.Text);
            int d8m = Convert.ToInt32(d8Multiple.Text);
            int d10m = Convert.ToInt32(d10Multiple.Text);
            int d12m = Convert.ToInt32(d12Multiple.Text);
            int d20m = Convert.ToInt32(d20Multiple.Text);

            int d2wX = 0;
            int d3wX = 0;
            int d4wX = 0;
            int d6wX = 0;
            int d8wX = 0;
            int d10wX = 0;
            int d12wX = 0;
            int d20wX = 0;


            for (int i = d2m; i > 0; i--)
            {
                d2wX += (rand.Next(1, 3));
            }

            for (int i = d3m; i > 0; i--)
            {
                d3wX += (rand.Next(1, 4));
            }

            for (int i = d4m; i > 0; i--)
            {
                d4wX += (rand.Next(1, 5));
            }

            for (int i = d6m; i > 0; i--)
            {
                d6wX += (rand.Next(1, 7));
            }

            for (int i = d8m; i > 0; i--)
            {
                d8wX += (rand.Next(1, 9));
            }

            for (int i = d10m; i > 0; i--)
            {
                d10wX += (rand.Next(1, 11));
            }

            for (int i = d12m; i > 0; i--)
            {
                d12wX += (rand.Next(1, 13));
            }

            for (int i = d20m; i > 0; i--)
            {
                d20wX += (rand.Next(1, 21));
            }


            int finalTally = d2wX + d3wX + d4wX + d6wX + d8wX + d10wX + d12wX + d20wX + Convert.ToInt32(modsEntry.Text);

            rollOutput.Text = finalTally.ToString();

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Custom",
                CharacterId = App.character.Id,
                CampaignId = App.character.CampaignId,
                UserId = App.character.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            character.CharRoll = Convert.ToInt32(rollOutput.Text);
            character.CharRollType = "Custom";

            await App.MobileService.GetTable<Characters>().UpdateAsync(character);
        }
    }
}
