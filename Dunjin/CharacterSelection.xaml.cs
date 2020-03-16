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

        private async void newCampaign_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new JoinCampaign());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var characters = await App.MobileService.GetTable<Characters>()
                .Where(chara => chara.UserId == App.user.Id).ToListAsync();
            characterListView.ItemsSource = characters;

        }

        private async void CharacterClicked(object sender, ItemTappedEventArgs e)
        {
            Characters character = (Characters)e.Item;
            await Navigation.PushAsync(new HomeDM(character));
        }
    }
}
