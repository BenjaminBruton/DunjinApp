using System;
using System.Collections.Generic;
using System.Linq;
using Dunjin.Model;
using Xamarin.Forms;

namespace Dunjin
{
    public partial class JoinCampaign : ContentPage
    {

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
                await DisplayAlert("Error", "Fields cannot be empty", "Ok");
            }
            else
            {
                var campaign = (await App.MobileService.GetTable<Campaigns>()
                .Where(u => u.CampaignName == campNameEntry.Text).ToListAsync()).FirstOrDefault();

                if (campaign != null)
                {
                    App.campaign = campaign;
                      
                    if (campaign.Password == passwordEntry.Text)
                    {
                            
                    Characters character = new Characters()
                    {
                        UserId = App.user.Id.ToString(),
                        CampaignId = App.campaign.Id.ToString(),
                        CharName = "Name Here",
                        CharClass = "Type Class",
                        CharRace = "Type Race",
                        CharLevel = 10,
                        CharXP = 10,
                        CharStr = 10,
                        CharDex = 10,
                        CharCon = 10,
                        CharInt = 10,
                        CharWis = 10,
                        CharCha = 10,
                        CharInit = 0,
                        CharRoll = 0,
                        CharAC = 10,
                        CharHP = 10,
                        CharTempHP = 10
                    };

                     await App.MobileService.GetTable<Characters>().InsertAsync(character);

                     await DisplayAlert("Success", "Campaign Successfully Joined", "Ok");

                     await Navigation.PushAsync(new CharacterSelection());
                     }
                     else
                     {
                         await DisplayAlert("Error", "There was an Error Joining Campaign", "Ok");
                     }
                }
                
                else
                {
                    await DisplayAlert("Error", "Campaign Name or Password are Incorrect", "Ok");
                }
            }
        }
    }
}
