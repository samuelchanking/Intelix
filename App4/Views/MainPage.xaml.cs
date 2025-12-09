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
using App4.Views;
// ...


namespace App4.Views

{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient httpClient = new HttpClient();
        public Portfolio[] p;
        public string longi;
        public string latit;
        SearchBar searchBar = null;
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (listviewdemo.DataSource != null)
            {
                this.listviewdemo.DataSource.Filter = FilterContacts;
                this.listviewdemo.DataSource.RefreshFilter();
            }
        }

        private bool FilterContacts(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var client = obj as Client;
            if ((client.Fname.ToLower() + " " + client.LName.ToLower()).Contains(searchBar.Text.ToLower())
                 || (client.Fname.ToLower() + " " + client.LName.ToLower()).Contains(searchBar.Text.ToLower()))
                return true;
            else
                return false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ScoreData.clientlist = ScoreData.clientlist.OrderByDescending(s => s.Score).ToList();

            listviewdemo.ItemsSource = ScoreData.clientlist;


        }





        public MainPage()
        {

            InitializeComponent();
            string connString = "server = dbhost.cs.man.ac.uk; User = s53162sj; Password = Jumper7872; Database = s53162sj";
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


            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Client c = new Client();
                c.UserID = reader.GetInt32("User_User ID");
                c.clientID = reader.GetInt32("ClientID");
                c.Fname = reader.GetString("Firstname");
                c.LName = reader.GetString("LastName");
                c.DateOfBirth = reader.GetString("DateOfBirth");
                c.Nationality = reader.GetString("Nationality");
                c.Domicile = reader.GetString("Domicile");
                c.Language = reader.GetString("LanguagePreference");
                c.sector = reader.GetString("Sector");
                c.Status = reader.GetString("CustomerStatus");
                c.BankService = reader.GetString("BankingService");
                c.Currency = reader.GetString("ReportCurrency");
                c.Score = reader.GetInt32("score");
                int s = reader.GetInt32("score");
                if (s < 45)
                {
                    c.IM = "b";
                }
                else if (s < 90)
                {
                    c.IM = "s";
                }
                else
                {
                    c.IM = "g";

                }
                //c.IM = 
                if (ScoreData.clientlist.Any(x => x.Fname == c.Fname))
                {
                    // Name already exists, don't add to the list
                }
                else
                {
                    // Name doesn't exist, add to the list
                    ScoreData.clientlist.Add(c);

                }


            }


            reader.Close();

            command = new MySqlCommand("SELECT * FROM `trading activities`", conn);

            List<TradingActivities> Tradinglist = new List<TradingActivities>();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                TradingActivities t = new TradingActivities();
                t.TID = reader.GetInt32("TradingActivitiesID");
                t.securityCode = reader.GetString("Security code");
                t.TDate = reader.GetString("Date of Transaction");
                t.TType = reader.GetString("Type of Transaction");
                t.TAmount = reader.GetInt32("Amount");
                t.PortfolioID = reader.GetString("Portfolio_ID");

                Tradinglist.Add(t);
            }

            reader.Close();

            command = new MySqlCommand("SELECT * FROM `security`", conn);

            List<Security> Securitylist = new List<Security>();

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Security s = new Security();
                s.securityID = reader.GetInt32("SecurityID");
                s.securityCode = reader.GetString("Security Code");
                s.description = reader.GetString("Short Description");
                s.currency = reader.GetString("Currency");
                s.price = reader.GetInt32("Price");
                s.priceDate = reader.GetString("PriceDate");

                Securitylist.Add(s);
            }
            reader.Close();

            command = new MySqlCommand("SELECT * FROM `log`", conn);

            List<Log> log = new List<Log>();



            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Log l = new Log();
                l.table = reader.GetString("table");
                l.ID = reader.GetString("ID");
                l.column = reader.GetString("column");
                l.type = reader.GetString("type");
                l.oldvalue = reader.GetString("oldValue");
                l.newvalue = reader.GetString("newValue");
                l.time = reader.GetString("time");
                log.Add(l);
            }
            reader.Close();

            conn.Close();
            listviewdemo.ItemsSource = ScoreData.clientlist;



        }


        async void Nav(System.Object sender, System.EventArgs e)
        {

            await Navigation.PushAsync(new Page3());
        }






        private async void OnTap(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            // handle the item tapped event here
            var tappedItem1 = e.ItemData as Client;

            // update the age of the tapped person
            tappedItem1.clientID += 1;


            // refresh the list view to reflect the changes made

        }

        private async void listView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            // Get the tapped item from the event arguments
            var tappedItem = e.ItemData as Client;

            // Navigate to the new page and pass the tapped item as a parameter
            await Navigation.PushAsync(new Page1(tappedItem));
        }

        private void listView_ItemDoubleTapped(object sender, Syncfusion.ListView.XForms.ItemDoubleTappedEventArgs e)
        {
            var person = e.ItemData as Client;
            // HeadColor = (person.Longitude +  "," + person.Latitude);


        }



    }
}

