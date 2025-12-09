using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.ListView.XForms;
using Syncfusion.DataSource;
using Xamarin.Essentials;
using System.Collections;

// Get a reference to the Syncfusion ListView control



namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage, INotifyPropertyChanged
    {
        List<(string Name, int Score)> nameScores = new List<(string, int)>()
        {
            ("Portfolio", 0),
            ("KYC", 4),
            ("Trading Activity", 0),
            ("Security", 1),
            ("Client", 2)
        };

        public string HeadColorAAA
        {
            get
            {
                return App4.GlobalVariables.MyGlobalVariable;
            }
            set
            {
                App4.GlobalVariables.MyGlobalVariable = value;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = this;
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


            command = new MySqlCommand("SELECT COUNT(*) FROM log", conn);
            App.logcount = Convert.ToInt32(command.ExecuteScalar());
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

                string ltable = reader.GetString("table");
                string lID = reader.GetString("ID");
                string lcolumn = reader.GetString("column");
                string ltype = reader.GetString("type");
                string loldvalue = reader.GetString("oldValue");
                string lnewvalue = reader.GetString("newValue");
                string ltime = reader.GetString("time");
                if (ltype == "Update")
                {
                    string ltext = ltable + " " + lID + " " + lcolumn + " has been updated from " + loldvalue + " to " + lnewvalue;
                    l.text = ltext;
                }
                else if (ltype == "Delete")
                {
                    string ltext = ltable + " " + lID + " has been deleted";
                    l.text = ltext;
                }
                else
                {
                    string ltext = ltable + " " + lID + " has been onboarded";
                    l.text = ltext;
                }

                if (ltable == "Client")
                {
                    l.img = "client.png";
                    l.Score = nameScores.FirstOrDefault(x => x.Name == "Client").Score;


                }
                else if (ltable == "Portfolio")
                {
                    l.img = "book.png";
                    l.Score = nameScores.FirstOrDefault(x => x.Name == "Portfolio").Score;


                }
                else if (ltable == "Trading Activities")
                {
                    l.img = "money.png";
                    l.Score = nameScores.FirstOrDefault(x => x.Name == "Trading Activity").Score;


                }
                else if (ltable == "KYC")
                {
                    l.img = "client.png";
                    l.Score = nameScores.FirstOrDefault(x => x.Name == "KYC").Score;


                }
                else
                {
                    l.img = "sec.png";
                    l.Score = nameScores.FirstOrDefault(x => x.Name == "Security").Score;


                }

                log.Add(l);
                App.logcount++;

            }

            reader.Close();
            conn.Close();


            List<Log> SortedList = log
            .OrderByDescending(o => o.Score)
            .ThenByDescending(o => o.time)
            .ToList();


            listviewdemo4.ItemsSource = SortedList;


        }

        public Page3()
        {
            InitializeComponent();

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
        async void Button_Clicked3(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("profile");

        }

        async void listviewdemo4_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var temp = e.ItemData as Log;
            if (temp.table == "Client")
            {
                string nameToUpdate = "Client";

                var tupleToUpdate = nameScores.FirstOrDefault(x => x.Name == nameToUpdate);
                if (tupleToUpdate != default)
                {
                    var updatedTuple = (tupleToUpdate.Name, tupleToUpdate.Score + 1);
                    int index = nameScores.IndexOf(tupleToUpdate);
                    nameScores[index] = updatedTuple;
                }
                await Shell.Current.GoToAsync("MainPage");



            }
            
            //else if (temp.table == "Security")
            ////{
            //    lister["Security"] ++; // Updates Bob's score to 95

            //}
            else if (temp.table == "Security")
            {
                string nameToUpdate = "Security";

                var tupleToUpdate = nameScores.FirstOrDefault(x => x.Name == nameToUpdate);
                if (tupleToUpdate != default)
                {
                    var updatedTuple = (tupleToUpdate.Name, tupleToUpdate.Score + 1);
                    int index = nameScores.IndexOf(tupleToUpdate);
                    nameScores[index] = updatedTuple;
                }
                await Shell.Current.GoToAsync("Page4");

            }
            else if (temp.table == "Trading Activities")
            {
                string nameToUpdate = "Trading Activity";

                var tupleToUpdate = nameScores.FirstOrDefault(x => x.Name == nameToUpdate);
                if (tupleToUpdate != default)
                {
                    var updatedTuple = (tupleToUpdate.Name, tupleToUpdate.Score + 1);
                    int index = nameScores.IndexOf(tupleToUpdate);
                    nameScores[index] = updatedTuple;
                }
                await Shell.Current.GoToAsync("Page2");

            }
            else if (temp.table == "Portfolio")
            {
                string nameToUpdate = "Portfolio";

                var tupleToUpdate = nameScores.FirstOrDefault(x => x.Name == nameToUpdate);
                if (tupleToUpdate != default)
                {
                    var updatedTuple = (tupleToUpdate.Name, tupleToUpdate.Score + 1);
                    int index = nameScores.IndexOf(tupleToUpdate);
                    nameScores[index] = updatedTuple;
                }
                await Shell.Current.GoToAsync("port");

            }
            else
            {
                string nameToUpdate = "KYC";

                var tupleToUpdate = nameScores.FirstOrDefault(x => x.Name == nameToUpdate);
                if (tupleToUpdate != default)
                {
                    var updatedTuple = (tupleToUpdate.Name, tupleToUpdate.Score + 1);
                    int index = nameScores.IndexOf(tupleToUpdate);
                    nameScores[index] = updatedTuple;
                }
                await Shell.Current.GoToAsync("Page6");


            }

        }
    }
    }
