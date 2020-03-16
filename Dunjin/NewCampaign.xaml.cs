using System;
using System.Collections.Generic;
using Dunjin.Model;
using Xamarin.Forms;

namespace Dunjin
{
    public partial class NewCampaign : ContentPage
    {
        public NewCampaign()
        {
            InitializeComponent();
        }

        private async void createButton_Clicked(System.Object sender, System.EventArgs e)
        {
            bool isCampaignNameEmpty = string.IsNullOrEmpty(campaignNameEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);
            bool isPasswordEmpty1 = string.IsNullOrEmpty(passwordConfirm.Text);

            if (isCampaignNameEmpty || isPasswordEmpty || isPasswordEmpty1)
            {
                await DisplayAlert("Error", "Fields cannot be empty", "Ok");
            }
            else
            {
                try
                {
                    if (passwordEntry.Text != passwordConfirm.Text)
                    {
                        await DisplayAlert("Error", "Passwords do not match.", "Ok");
                    }
                    else
                    {
                        Campaigns campaign = new Campaigns()
                        {
                            CampaignName = campaignNameEntry.Text,
                            Password = passwordEntry.Text,
                            UserId = App.user.Id,
                            UserName = App.user.Username
                        };

                        await App.MobileService.GetTable<Campaigns>().InsertAsync(campaign);

                        await DisplayAlert("Success", "Campaign Successfully Created", "Ok");

                        await Navigation.PushAsync(new CampaignSelection());
                    }
                }
                catch (NullReferenceException)
                {
                    await DisplayAlert("Failure", "Campaign Was Not Created, nullRev", "Ok");
                }
                catch (Exception)
                {
                    await DisplayAlert("Failure", "Campaign Was Not Created", "Ok");
                }
            }
        }
    }
}
