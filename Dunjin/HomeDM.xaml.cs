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

        }
        private void CharacterClicked(object sender, ItemTappedEventArgs e)
        {
            Characters character = (Characters)e.Item;

        }
    }
}
