using App4.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Page1 : ContentPage
    {
        private Client tappedA;
        private string myStringProperty;
        private string myStringProperty2a;
        private string myStringProperty2;
        private int myStringProperty3;
        private string myStringProperty4;
        private string myStringProperty5;
        private string myStringProperty6;
        private string myStringProperty6a;

        public string LastName
        {
            get { return myStringProperty6a; }
            set
            {
                myStringProperty6a = value;
                OnPropertyChanged(nameof(LastName)); // Notify that there was a change on this property
            }
        }

        public string MyStringProperty
        {
            get { return myStringProperty; }
            set
            {
                myStringProperty = value;
                OnPropertyChanged(nameof(MyStringProperty)); // Notify that there was a change on this property
            }
        }

        public string MyStringProperty2
        {
            get { return myStringProperty2a; }
            set
            {
                myStringProperty2a = value;
                OnPropertyChanged(nameof(MyStringProperty2)); // Notify that there was a change on this property
            }
        }

        public int Score
        {
            get { return myStringProperty3; }
            set
            {
                myStringProperty3 = value;
                OnPropertyChanged(nameof(Score)); // Notify that there was a change on this property
            }
        }

        public string Domicile
        {
            get { return myStringProperty4; }
            set
            {
                myStringProperty4 = value;
                OnPropertyChanged(nameof(Domicile)); // Notify that there was a change on this property
            }
        }

        public string Sector
        {
            get { return myStringProperty5; }
            set
            {
                myStringProperty5 = value;
                OnPropertyChanged(nameof(Sector)); // Notify that there was a change on this property
            }
        }

        public string Currency
        {
            get { return myStringProperty6; }
            set
            {
                myStringProperty6 = value;
                OnPropertyChanged(nameof(Currency)); // Notify that there was a change on this property
            }
        }


        public Page1(Client tappedItem)
        {
            InitializeComponent();
            tappedA = tappedItem;

            // Set the label text to the name of the tapped person

            this.BindingContext = this;

            MyStringProperty = (tappedA.Fname +' '+ tappedA.LName);
            Currency = (tappedA.Currency);
            Score = (tappedA.Score);
            Sector = (tappedA.sector);
            Domicile = (tappedA.Domicile);
            MyStringProperty2 = (tappedA.Nationality);
            LastName = (tappedA.LName);


            // Populate the Picker control with scores
            for (int i = 0; i <= 18; i++)
            {
                picker.Items.Add((i*5).ToString());
            }

            // Set the default value of the Picker control to 0
            picker.SelectedIndex = 0;

            if (!Accelerometer.IsMonitoring)
            {
                Accelerometer.Start(SensorSpeed.UI);

            }
            Accelerometer.ShakeDetected += Accelormeter_ShakeDetected;

        }
        void Accelormeter_ShakeDetected(object sender, EventArgs e)
        {
            OnAlertClicked(null, null);
            Accelerometer.Stop();
        }

        async void OnAlertClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Shake-to-Hide Activated", "Data hidden. Please log-in to reveal", "OK");
            await Navigation.PushAsync(new login());


        }

        async void OnAddScoreClicked(object sender, EventArgs e)
        {
            // Get the score to add from a user input, e.g. a numeric entry control
            int scoreToAdd = int.Parse(picker.SelectedItem.ToString());


            // Find the player score object in the Scores list with the selected name
            var playerScore = ScoreData.clientlist.FirstOrDefault(s => s.LName == myStringProperty6a);

            playerScore.Score = scoreToAdd + playerScore.Score;
            if (playerScore.Score > 75)
            {
                playerScore.IM = "g";

            }
            else if (playerScore.Score > 50)
            {
                playerScore.IM = "s";
            }
            else 
            {
                playerScore.IM = "b";
            }
            // Display an alert pop-up
            await DisplayAlert("Added", "The meeting minutes have been added", "OK");


        }



    }
        }

