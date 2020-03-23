using System;
using System.Collections.Generic;
using Dunjin.Model;
using Xamarin.Forms;

namespace Dunjin
{
    public partial class HomePlayer : TabbedPage
    {
        Characters character;
        public HomePlayer(Characters character)
        {
            InitializeComponent();

            this.character = character;
            characterDetails.Text = character.CharName;
            BindingContext = character;
        }


    }
}
