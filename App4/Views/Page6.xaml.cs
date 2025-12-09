using System.Collections.ObjectModel;
using System.Net.Http;
using Xamarin.Forms;
using MySqlConnector;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Syncfusion.SfDataGrid.XForms;
using System.Linq;
using Xamarin.Essentials;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
// ...


namespace App4.Views
{
    public partial class Page6 : ContentPage, INotifyPropertyChanged
    {
        private const string monkeyUrl = "https://montemagno.com/monkeys.json";
        private readonly HttpClient httpClient = new HttpClient();
        public Portfolio[] p;
        public string longi;
        public string latit;

        async void Nav(System.Object sender, System.EventArgs e)
        {

            await Shell.Current.GoToAsync("Page6");




        }



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
        public Page6()
        {
            InitializeComponent();

            BindingContext = this;

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


        private async void listView_ItemTapped1(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            // Get the tapped item from the event arguments
            var tappedItem1 = e.ItemData as kyc;

            // Navigate to the new page and pass the tapped item as a parameter
            await Navigation.PushAsync(new Page5(tappedItem1));
        }

        private void listView_ItemDoubleTapped(object sender, Syncfusion.ListView.XForms.ItemDoubleTappedEventArgs e)
        {
            var person = e.ItemData as Client;
            //HeadColor = (person.Longitude + "," + person.Latitude);


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = this;
            this.BindingContext = this;

            string connString = "server = dbhost.cs.man.ac.uk; User=s53162sj; Password=Jumper7872; Database=s53162sj ";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            List<Portfolio> portfoliolist = new List<Portfolio>();

            MySqlCommand command = new MySqlCommand("SELECT * FROM portfolio", conn);
            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                Portfolio p = new Portfolio();
                p.proID = reader.GetString("Portfolio_ID");
                p.status = reader.GetString("Status");
                p.type = reader.GetString("Type");
                p.feecode = reader.GetString("Fee_Code");
                //p.inival = reader.GetString("InitialValue");
                p.currency = reader.GetString("Currency");
                p.clientid = reader.GetInt32("Client_ClientID");
                portfoliolist.Add(p);
            }

            reader.Close();

            command = new MySqlCommand("SELECT * FROM client", conn);

            List<Client> clientlist = new List<Client>();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Client c = new Client();
                c.UserID = reader.GetInt32("User_User ID");
                c.clientID = reader.GetInt32("ClientID");
                c.Fname = reader.GetString("Firstname");
                c.LName = reader.GetString("LastName");
                //c.DateOfBirth = reader.GetString("DateOfBirth");
                c.Nationality = reader.GetString("Nationality");
                c.Domicile = reader.GetString("Domicile");
                c.Language = reader.GetString("LanguagePreference");
                c.sector = reader.GetString("Sector");
                c.Status = reader.GetString("CustomerStatus");
                c.BankService = reader.GetString("BankingService");
                c.Currency = reader.GetString("ReportCurrency");
                //c.Longitude = reader.GetString("Longitude");
                //c.Latitude = reader.GetString("Latitude");
                clientlist.Add(c);
            }



            reader.Close();
            command = new MySqlCommand("SELECT * FROM kyc", conn);

            List<kyc> kyc1 = new List<kyc>();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                kyc k = new kyc();
                k.PEP = reader.GetString("PEP check");
                int count = 0;
                if (k.PEP == " ")
                {
                    count = count + 1;
                }
                k.GDA = reader.GetString("GovernmentDocumentAttached");
                if (k.GDA == " ")
                {
                    count = count + 1;
                }
                k.SOW = reader.GetString("Source of Wealth");
                if (k.SOW == " ")
                {
                    count = count + 1;
                }
                k.DOB = reader.GetDateTime("Date Of Birth");
                k.PM = reader.GetString("Paper Mailing");
                if (k.PM == " ")
                {
                    count = count + 1;
                }
                k.Address = reader.GetString("Address");
                if (k.Address == " ")
                {
                    count = count + 1;
                }
                k.MAddress = reader.GetString("Mailing Address");
                if (k.MAddress == " ")
                {
                    count = count + 1;
                }
                k.CK = reader.GetString("Client Knowledge");
                if (k.CK == " ")
                {
                    count = count + 1;
                }
                k.ANum = reader.GetString("Account Number");
                if (k.ANum == " ")
                {
                    count = count + 1;
                }
                k.Fname = reader.GetString("First Name");
                if (k.Fname == " ")
                {
                    count = count + 1;
                }
                k.Sname = reader.GetString("Last Name");
                if (k.Sname == " ")
                {
                    count = count + 1;
                }
                k.ID = reader.GetInt32("kyc_ClientID");
                k.score = (12 - count) * 100;
                k.score = k.score / 12;

                //c.Longitude = reader.GetString("Longitude");
                //c.Latitude = reader.GetString("Latitude");
                kyc1.Add(k);
            }



            reader.Close();

            command = new MySqlCommand("SELECT * FROM `trading activities`", conn);

            List<TradingActivities> Tradinglist = new List<TradingActivities>();
            List<TradingActivitiesRed> TradinglistRed = new List<TradingActivitiesRed>();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                TradingActivities t = new TradingActivities();
                TradingActivitiesRed tRed = new TradingActivitiesRed();
                t.TID = reader.GetInt32("TradingActivitiesID");
                t.securityCode = reader.GetString("Security code");
                //t.TDate = reader.GetString("Date of Transaction");
                t.TType = reader.GetString("Type of Transaction");
                t.TAmount = reader.GetInt32("Amount");
                t.PortfolioID = reader.GetString("Portfolio_ID");
                tRed.TID = reader.GetInt32("TradingActivitiesID");
                tRed.securityCode = reader.GetString("Security code");
                //t.TDate = reader.GetString("Date of Transaction");
                tRed.TType = reader.GetString("Type of Transaction");
                tRed.TAmount = reader.GetInt32("Amount");
                tRed.PortfolioID = reader.GetString("Portfolio_ID");
                if (t.TAmount > 220)
                {
                    TradinglistRed.Add(tRed);
                }
                else
                {
                    Tradinglist.Add(t);
                }




            }

            reader.Close();

            conn.Close();
            //listviewdemo1.ItemsSource = Tradinglist;
            //listviewdemo2.ItemsSource = TradinglistRed;

            listviewdemo13.ItemsSource = kyc1;
        }



        }
}
