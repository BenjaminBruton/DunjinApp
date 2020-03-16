using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dunjin.Model;
using Xamarin.Forms;

namespace Dunjin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            

            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                var user = (await App.MobileService.GetTable<Users>()
                .Where(u => u.Email == emailEntry.Text).ToListAsync()).FirstOrDefault();

                if(user != null)
                {
                    App.user = user;

                    if (user.Password == passwordEntry.Text)                       
                        await Navigation.PushAsync(new RoleSelection());
                    else
                        await DisplayAlert("Error", "Email or Password are Incorrect", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "There was an Error Logging You In", "Ok");
                }
                
            }
        }

        private async void RegisterButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Registration());
        }
    }
}
