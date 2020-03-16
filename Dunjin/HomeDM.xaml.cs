using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Dunjin.Model;

namespace Dunjin
{
    
    public partial class HomeDM : TabbedPage
    {

        Campaigns campaign;
        Characters character;

        public HomeDM(Campaigns campaign)
        {
            InitializeComponent();

            this.campaign = campaign;
            campaignDetails.Text = campaign.CampaignName;
        }

        public HomeDM(Characters character)
        {
            this.character = character;
        }
    }
}
