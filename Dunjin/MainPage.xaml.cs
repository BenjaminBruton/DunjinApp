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
        string hashedPassword;

        public MainPage()
        {
            InitializeComponent();
        }

        //used for hashing/salting again
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


                if (user != null)
                {
                    App.user = user;

                    //Used for 'legacy' accounts made before the hashing/salt was adding (they don't have security)
                    if (App.user.Salt == null)
                    {
                        hashedPassword = passwordEntry.Text;
                    }
                    else
                    {
                        hashedPassword = GenerateSHA256Hash(passwordEntry.Text, App.user.Salt);
                    }
                    
                    if (user.Password == hashedPassword)                       
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
