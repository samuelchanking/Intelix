using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    public partial class Home : ContentPage, INotifyPropertyChanged
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //shake event
            if (!Accelerometer.IsMonitoring)
            {
                Accelerometer.Start(SensorSpeed.UI);

            }
            Accelerometer.ShakeDetected += Accelormeter_ShakeDetected;
            
        }
        void Accelormeter_ShakeDetected(object sender, EventArgs e)
        {
            OnAlertClicked(null, null);
        }

        async void OnAlertClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Shake-to-Hide Activated", "Data hidden. Please log-in to reveal", "OK");
            Application.Current.MainPage = new NavigationPage(new login());


        }
        protected void GoGoogle(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("http://www.google.com"));
        }

        async void Button_Clicked3(System.Object sender, System.EventArgs e)
        {

            await Shell.Current.GoToAsync("profile");


        }

        async void Button_Clicked4(System.Object sender, System.EventArgs e)
        {

            await Shell.Current.GoToAsync("Client");

        }
    }
}