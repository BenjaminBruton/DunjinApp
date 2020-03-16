using System;
using System.Collections.Generic;
using System.Linq;
using Dunjin.Model;
using Xamarin.Forms;

namespace Dunjin
{
    public partial class JoinCampaign : ContentPage
    {
        Characters character;
        public JoinCampaign()
        {
            InitializeComponent();
        }

        private async void JoinButton_Clicked(System.Object sender, System.EventArgs e)
        {
            bool isCampNameEmpty = string.IsNullOrEmpty(campNameEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isCampNameEmpty || isPasswordEmpty)
            {

            }
            else
            {
                var campaign = (await App.MobileService.GetTable<Campaigns>()
                .Where(u => u.CampaignName == campNameEntry.Text).ToListAsync()).FirstOrDefault();

                if (campaign != null)
                {
                    App.campaign = campaign;

                    if (campaign.Password == passwordEntry.Text)
                        await Navigation.PushAsync(new HomePlayer(character));
                    else
                        await DisplayAlert("Error", "Campaign Name or Password are Incorrect", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "There was an Error Logging You In", "Ok");
                }

            }
        }
    }
}
