using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Dunjin.Model;

namespace Dunjin
{
    
    public partial class HomeDM : TabbedPage
    {

        Campaigns campaign;
        Characters character;

        public HomeDM(Campaigns campaign)
        {
            InitializeComponent();

            this.campaign = campaign;
            campaignDetails.Text = campaign.CampaignName;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var characters = await App.MobileService.GetTable<Characters>()
                .Where(cha => cha.UserId == App.user.Id).ToListAsync();
            characterListView.ItemsSource = characters;

        }
    }
}
