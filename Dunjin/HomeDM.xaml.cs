using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Dunjin.Model;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Dunjin
{
    
    public partial class HomeDM : TabbedPage
    {
        Campaigns campaign;
        private int d20CritChance;
        private string criticalRoll;

        public HomeDM(Campaigns campaign)
        {
            InitializeComponent();

            this.campaign = campaign;

            charactersListView.ItemTapped += new EventHandler<ItemTappedEventArgs>(CharacterClicked);
            //campaignDetails.Text = campaign.CampaignName;           
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var characters = await App.MobileService.GetTable<Characters>()
                .Where(cha => cha.CampaignId == campaign.Id).ToListAsync();

            charactersListView.ItemsSource = characters;
            characterRollsListView.ItemsSource = characters;
            characterInitRollsListView.ItemsSource = characters;

        }
        private void CharacterClicked(object sender, ItemTappedEventArgs e)
        {
            Characters character = (Characters)e.Item;

        }

        async void initRoll_Clicked(System.Object sender, System.EventArgs e)
        {
            Random rand = new Random();
            int randomRoll = rand.Next(1, 21);
            int randomDexMod = Convert.ToInt32(modsEntry.Text);
            int initRoll = randomRoll + randomDexMod;
            rollOutput.Text = initRoll.ToString();
            dmInitRoll.Text = initRoll.ToString();

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Initiative",
                CharacterId = "DUNGEON MASTER",
                CampaignId = App.campaign.Id,
                UserId = App.campaign.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            campaign.DMRoll = Convert.ToInt32(rollOutput.Text);
            campaign.DMRollType = "Initiative";

            await App.MobileService.GetTable<Campaigns>().UpdateAsync(campaign);
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
                d20CritChance = rand.Next(1, 21);
                d20wX += d20CritChance;
                if (d20CritChance == 20)
                {
                    criticalRoll = "HIT";
                    await DisplayAlert("CRIT", "YOU MADE A CRITICAL HIT", "OK");
                }
                if (d20CritChance == 1)
                {
                    criticalRoll = "MISS";
                    await DisplayAlert("MISS", "YOU MADE A CRITICAL MISS", "OK");
                }
            }


            int finalTally = d2wX + d3wX + d4wX + d6wX + d8wX + d10wX + d12wX + d20wX + Convert.ToInt32(modsEntry.Text);

            rollOutput.Text = finalTally.ToString();
            dmRoll.Text = finalTally.ToString();

            Rolls roll = new Rolls()
            {
                RollNum = Convert.ToInt32(rollOutput.Text),
                RollType = "Custom",
                CharacterId = "DUNGEON MASTER",
                CampaignId = App.campaign.Id,
                UserId = App.campaign.UserId
            };

            await App.MobileService.GetTable<Rolls>().InsertAsync(roll);

            campaign.DMRoll = Convert.ToInt32(rollOutput.Text);
            campaign.DMRollType = "Custom";

            await App.MobileService.GetTable<Campaigns>().UpdateAsync(campaign);
        }

        async void charReports_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ReportsMaster());
        }
    }
}
