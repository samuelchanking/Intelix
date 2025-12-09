using App4.Models;
using App4.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{

    public partial class Accessibility : ContentPage, INotifyPropertyChanged
    {
        public string HeadColor
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
        public Item Item { get; set; }

        public Accessibility()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        async void ChangeCB(object sender, EventArgs args)
        {
            {
                await DisplayAlert("Colourblind Compatibility", "Intelix is designed to be readable to a large demographic of managers. Interface elements and colours were implemented with high contrast in mind, making Intelix accessible to a variety of colour vision deficiencies.", "OK");
            }
        }
        async void ChangeText(object sender, EventArgs args)
        {
            {
                await DisplayAlert("Text Options", "Intelix is built with accessibility and readability in mind. If you require Bold Text, navigate to your System Settings. In your Display or Accessibility settings, toggle Bold Text and Intelix will automatically update to make the text throughout the app more discernible!", "OK");

            }
        }
        async void ChangeHC(object sender, EventArgs args)
        {

            await DisplayAlert("High Contrast", "With Intelix's priority on making the user experience accessible, High Contrast is compatible. Navigate to your System Settings, select High/Increase Contrast from your Display or Accessibility Settings, and Intelix will automatically update to make all interface elements more readable.", "OK");


        }

    }
}