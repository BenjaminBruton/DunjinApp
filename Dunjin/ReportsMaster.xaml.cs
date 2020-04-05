using System;
using System.Collections.Generic;
using Dunjin.Model;
using Xamarin.Forms;

namespace Dunjin
{
    public partial class ReportsMaster : ContentPage
    {
        Campaigns campaign;
        public ReportsMaster(Campaigns campaign)
        {
            InitializeComponent();
            this.campaign = campaign;
        }

        async void highRolls_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Reports.HighRollsReport(campaign));
        }

        async void dmgRolls_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Reports.DamageRollsReport(campaign));
        }

        async void charStats_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Reports.CharacterStatsReport(campaign));
        }

        async void highRollsToday_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Reports.HighRollsToday(campaign));
        }
    }
}
