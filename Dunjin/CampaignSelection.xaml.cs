using System;
using System.Collections.Generic;
using Dunjin.Model;
using Xamarin.Forms;

namespace Dunjin
{
    public partial class CampaignSelection : ContentPage
    {       

        public CampaignSelection()
        {
            InitializeComponent();

            campaignListView.ItemTapped += new EventHandler<ItemTappedEventArgs>(CampaignClicked);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var campaigns = await App.MobileService.GetTable<Campaigns>()
                .Where(camp => camp.UserId == App.user.Id).ToListAsync();
            campaignListView.ItemsSource = campaigns;

        }

        private async void newCampaign_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewCampaign());
        }

        private async void CampaignClicked(object sender, ItemTappedEventArgs e)
        {
            Campaigns campaign = (Campaigns)e.Item;
            await Navigation.PushAsync(new HomeDM(campaign));
        }
    }
}
