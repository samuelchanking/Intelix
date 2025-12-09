using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Page4 : ContentPage
    {
        private Log tappedB;
        private string myStringProperty;
        public string MyStringProperty
        {
            get { return myStringProperty; }
            set
            {
                myStringProperty = value;
                OnPropertyChanged(nameof(MyStringProperty)); // Notify that there was a change on this property
            }
        }

        public Page4()
        {
            InitializeComponent();
            BindingContext = this;

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

            List<Client> clientlist = new List<Client>();

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
                clientlist.Add(c);
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
            List<SecurityRed> Security1 = new List<SecurityRed>();
            List<int> scoresList1 = new List<int>();



            reader = command.ExecuteReader();

            while (reader.Read())
            {
                scoresList1.Add(reader.GetInt32("price"));

            }

            reader.Close();

            // Calculate the mean and standard deviation
            double mean = scoresList1.Average();
            double stdDev = Math.Sqrt(scoresList1.Average(v => Math.Pow(v - mean, 2)));

            // Find the lower and upper bounds for outliers
            double lowerBound = mean - (3 * stdDev);
            double upperBound = mean + (3 * stdDev);


            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Security s = new Security();
                SecurityRed sRed = new SecurityRed();

                s.securityID = reader.GetInt32("SecurityID");
                s.securityCode = reader.GetString("Security Code");
                s.description = reader.GetString("Short Description");
                s.currency = reader.GetString("Currency");
                s.price = reader.GetInt32("Price");
                s.priceDate = reader.GetString("PriceDate");
                sRed.securityID = reader.GetInt32("SecurityID");
                sRed.securityCode = reader.GetString("Security Code");
                sRed.description = reader.GetString("Short Description");
                sRed.currency = reader.GetString("Currency");
                sRed.price = reader.GetInt32("Price");
                sRed.priceDate = reader.GetString("PriceDate");
                if (s.price > upperBound)
                {
                    Security1.Add(sRed);
                }
                else
                {
                    Securitylist.Add(s);
                }
            }
            reader.Close();
            listviewdemo12.ItemsSource = Security1;
            listviewdemo22.ItemsSource = Securitylist;

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

            // Set the label text to the name of the tapped person

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
    }
}