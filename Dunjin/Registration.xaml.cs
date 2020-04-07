using System;
using System.Collections.Generic;
using Dunjin.Model;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using System.Text;

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

        //This through ByteArray is used to create a hash/salt combination for the password
        public string CreateSalt(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public string GenerateSHA256Hash(string input, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256HashString =
                new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256HashString.ComputeHash(bytes);

            return ByteArrayToHexString(hash);
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
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
                    //Used to store the full hashed password as well as just the salt separately.
                    string salt = CreateSalt(10);
                    string hashedPassword = GenerateSHA256Hash(password.Text, salt);

                   Users user = new Users()
                    {
                        Username = userName.Text,
                        Email = emailEntry.Text,
                        Password = hashedPassword,
                        Salt = salt
                    };

                    await App.MobileService.GetTable<Users>().InsertAsync(user);

                    await DisplayAlert("Success", "Account Successfully Created!", "Ok");

                    await Navigation.PushAsync(new MainPage());
                }
            }
        }
    }
}
