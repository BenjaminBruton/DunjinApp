using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Dunjin
{
    public partial class RoleSelection : ContentPage
    {
        public RoleSelection()
        {
            InitializeComponent();
        }

        private async void dungeonMaster_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CampaignSelection());
        }

        private async void playerCharacter_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CharacterSelection());
        }
    }
}
