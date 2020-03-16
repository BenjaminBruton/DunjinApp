using System;

using Xamarin.Forms;

namespace Dunjin
{
    public class JoinCampaign : ContentPage
    {
        public JoinCampaign()
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

