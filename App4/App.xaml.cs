using App4.Services;
using App4.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Timers;
using Plugin.LocalNotification;
using MySqlConnector;
using System.Collections.Generic;

namespace App4
{
    public static class GlobalVariables
    {
        public static string MyGlobalVariable = "31507F";
    }
    public partial class App : Application
    {

        public static int count = 0, logcount = 0;
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTg4Mjg2M0AzMjMxMmUzMTJlMzMzNUV3dkUxU1hmL0ZOeXZPYmhGRC81L1QrUk52RE5tMDNxbWREWENqcmFWSmc9");

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(10);

            var timer = new System.Threading.Timer((e) =>
            {
                string connString2 = "server = dbhost.cs.man.ac.uk; User = s53162sj; Password = Jumper7872; Database = s53162sj";
                MySqlConnection conn2 = new MySqlConnection(connString2);
                conn2.Open();
                MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM log", conn2);
                count = Convert.ToInt32(command.ExecuteScalar());
                if (count != logcount)
                {
                    command = new MySqlCommand("SELECT * FROM log", conn2);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<Log> log = new List<Log>();
                    string title = "", type = "";
                    string ID = "", column = "";
                    while (reader.Read())
                    {
                        Log l = new Log();
                        l.table = reader.GetString("table");
                        title = reader.GetString("table");
                        l.ID = reader.GetString("ID");
                        ID = reader.GetString("ID");
                        l.column = reader.GetString("column");
                        column = reader.GetString("column");
                        l.type = reader.GetString("type");
                        type = reader.GetString("type");
                        l.oldvalue = reader.GetString("oldValue");
                        l.newvalue = reader.GetString("newValue");
                        l.time = reader.GetString("time");
                        log.Add(l);
                    }

                    char[] censor = ID.ToCharArray();
                    for (int i = 0; i < censor.Length / 2; i++)
                    {
                        censor[i] = 'X';
                    }
                    string censorID = new string(censor);

                    if (type == "Update")
                    {
                        var notification = new NotificationRequest
                        {
                            BadgeNumber = 1,
                            Description = title + " " + censorID + " has " + type + "d " + column,
                            Title = "You have a " + title + " " + type,
                            //NotifyTime = DateTime.Now.AddSeconds(5)
                        };
                        NotificationCenter.Current.Show(notification);
                    }
                    else if (type == "Insert")
                    {

                        var notification = new NotificationRequest
                        {
                            BadgeNumber = 1,
                            Description = title + " " + censorID + " has been " + type + "ed ",
                            Title = "You have a " + title + " " + type + "ion",
                            //NotifyTime = DateTime.Now.AddSeconds(5),
                        };
                        NotificationCenter.Current.Show(notification);
                    }
                    else
                    {

                        var notification = new NotificationRequest
                        {
                            BadgeNumber = 1,
                            Description = title + " " + censorID + " has been " + type + "d ",
                            Title = "You have a " + title + " " + "Deletion",
                            //NotifyTime = DateTime.Now.AddSeconds(5) 
                        };
                        NotificationCenter.Current.Show(notification);
                    }
                    reader.Close();
                    logcount = count;
                }
                conn2.Close();
            }, null, startTimeSpan, periodTimeSpan);

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
