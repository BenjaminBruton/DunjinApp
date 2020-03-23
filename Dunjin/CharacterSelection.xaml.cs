using System;
using System.Collections.Generic;
using Dunjin.Model;
using Xamarin.Forms;

namespace Dunjin
{
    public partial class CharacterSelection : ContentPage
    {
        public CharacterSelection()
        {
            InitializeComponent();

            characterListView.ItemTapped += new EventHandler<ItemTappedEventArgs>(CharacterClicked);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var characters = await App.MobileService.GetTable<Characters>()
                    .Where(cha => cha.CampaignId == App.campaign.Id).ToListAsync();
            

            if (characters != null)
            {
                var updatedCharacter = await App.MobileService.GetTable<Characters>()
                    .Where(cha => cha.UserId == App.user.Id).ToListAsync();

                characterListView.ItemsSource = updatedCharacter;
            }

        }

        private async void joinCampaign_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new JoinCampaign());
        }

        private async void CharacterClicked(object sender, ItemTappedEventArgs e)
        {
            Characters character = (Characters)e.Item;
            await Navigation.PushAsync(new HomePlayer(character));
        }
    }
}
