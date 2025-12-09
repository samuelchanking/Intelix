using App4.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace App4.Views
{

    public partial class Settings : ContentPage, INotifyPropertyChanged
    {
        public string HeadColorS
        {
            get
            {
                return App4.GlobalVariables.MyGlobalVariable;
            }
            set
            {
                App4.GlobalVariables.MyGlobalVariable = value;
                OnPropertyChanged();
            }
        }
        public Settings()
        {
            InitializeComponent();
            this.BindingContext = this;


            //RandomLabel.Text = Preferences.Get("RandomText", string.Empty);
            //RandomSwitch.IsToggled = Preferences.Get("RandomSwitch", false);

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            HeadColorS = App4.GlobalVariables.MyGlobalVariable;
        }


        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            await Shell.Current.GoToAsync("Accessibility");




        }

        async void Button_Clicked2(System.Object sender, System.EventArgs e)
        {

            await Shell.Current.GoToAsync("Client");


        }
        void Button_Clicked3(System.Object sender, System.EventArgs e)
        {
            //Preferences.Set("RandomText", RandomLabel.Text);
            //Preferences.Set("RandomSwitch", RandomSwitch.IsToggled);
        }


        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            Preferences.Clear();
        }

        async void ChangeFont(object sender, EventArgs args)
        {
            {
                await DisplayAlert("Change System Font", "With Intelix's focus on providing an accessible user experience, customised Font Sizes are compatible! Simply navigate to your System Settings, and change your Font Size in your Display/Accessibility Settings. Upon completion, Intelix will dynamically scale its interface to suit your needs!", "OK");
            }
        }
        async void Help(object sender, EventArgs args)
        {
            {
                await DisplayAlert("Help Required?", "Intelix is a secure, personal assistant. Therefore, System Administrators must be informed if there are ever any issues with Intelix. Please contact them for further guidance and support.", "OK");

            }
        }
        async void ChangeHC1(object sender, EventArgs args)
        {

            await DisplayAlert("Added", "The meeting minutes have been added", "OK");


        }
    }
}
