using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public int[] id;
        public string[] n;
        public string[] pw;

        public static UserInfo[] useriD;
        public login()
        {
            InitializeComponent();
        }
        void Button_Clicked(object sender, EventArgs e)
        {
            int user = Convert.ToInt32(Userentry.Text);

            if (string.IsNullOrEmpty(Convert.ToString(Userentry.Text)))
            {
                mtid.IsVisible = true;
            }
            else
            {
                mtid.IsVisible = false;
            }

            if (string.IsNullOrEmpty(Convert.ToString(Pass.Text)))
            {
                mtpw.IsVisible = true;
            }
            else { mtpw.IsVisible = false; }

            if (!string.IsNullOrEmpty(Convert.ToString(Pass.Text)) && !string.IsNullOrEmpty(Convert.ToString(Userentry.Text)))
            {

                if (pw[user - 1] == Pass.Text)
                {
                    Home d = new Home();
                    Navigation.PushAsync(d);
                }
                else
                {
                    pwstaus.IsVisible = true;
                }


            }


        }

        async void Button_Clicked1(object sender, EventArgs e)
        {
            var availability = await CrossFingerprint.Current.IsAvailableAsync();
            if (!availability)
            {
                await DisplayAlert("Warning!", "No biometric available", "OK");
                return;
            }
            var authResult = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("Heads Up!", "I would like to use your biometric, please!"));

            if (authResult.Authenticated)
            {
                await Navigation.PushAsync(new Page3());
            }

        }




        public class UserInfo
        {
            public string Name { get; set; }
            public string Password { get; set; }

        }
    }
}