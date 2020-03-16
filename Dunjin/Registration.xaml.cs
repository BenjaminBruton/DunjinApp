using System;
using System.Collections.Generic;
using Dunjin.Model;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

namespace Dunjin
{
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }

        void cancelButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private async void registerButton_Clicked(System.Object sender, System.EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(password.Text);
            bool isPasswordEmpty1 = string.IsNullOrEmpty(passwordConfirm.Text);

            if (isEmailEmpty || isPasswordEmpty || isPasswordEmpty1)
            {
                await DisplayAlert("Error", "Fields cannot be empty", "Ok");
            }
            else
            {
                if (password.Text != passwordConfirm.Text)
                {
                    await DisplayAlert("Error", "Passwords do not match.", "Ok");
                }
                else
                {
                   Users user = new Users()
                    {
                        Username = userName.Text,
                        Email = emailEntry.Text,
                        Password = password.Text                        
                    };

                    await App.MobileService.GetTable<Users>().InsertAsync(user);

                    await Navigation.PushAsync(new MainPage());
                }
            }
        }
    }
}
