using App4.Models;
using App4.ViewModels;
using App4.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    public partial class AssistantPage : ContentPage
    {
        public string HeadColorAss
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
        
            
            public AssistantPage()
        {
            InitializeComponent();

            
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            await Shell.Current.GoToAsync("MainPage");

        }

        async void SfButtonA2_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Page6");

        }

        async void SfButtonA3_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Page4");

        }

        async void SfButtonA4_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Page2");

        }
        async void SfButtonA6_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("port");

        }
        async void SfButtonBB_Clicked(object sender, EventArgs e)
        {

            await Launcher.OpenAsync("https://www.google.com");


        }

    }
}