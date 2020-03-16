using System;

using Xamarin.Forms;

namespace Dunjin
{
    public class CampaignPage : ContentPage
    {
        public CampaignPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

