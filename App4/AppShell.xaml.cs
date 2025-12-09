using App4.ViewModels;
using App4.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace App4
{
    public partial class AppShell : Xamarin.Forms.Shell, INotifyPropertyChanged
    {
        public string hd
        {
            get { return App4.GlobalVariables.MyGlobalVariable; }
            set { App4.GlobalVariables.MyGlobalVariable = value; NotifyPropertyChanged("hd"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(Accessibility), typeof(Accessibility));
            Routing.RegisterRoute(nameof(Settings), typeof(Settings));
            Routing.RegisterRoute(nameof(Home), typeof(Home));
            Routing.RegisterRoute(nameof(AssistantPage), typeof(AssistantPage));
            Routing.RegisterRoute(nameof(profile), typeof(profile));
            Routing.RegisterRoute(nameof(Client), typeof(Client));
            Routing.RegisterRoute(nameof(port), typeof(port));

            Routing.RegisterRoute(nameof(Page1), typeof(Page1));
            Routing.RegisterRoute(nameof(Page2), typeof(Page2));
            Routing.RegisterRoute(nameof(Page3), typeof(Page3));
            Routing.RegisterRoute(nameof(Page4), typeof(Page4));
            Routing.RegisterRoute(nameof(Page6), typeof(Page6));
            Routing.RegisterRoute(nameof(Page5), typeof(Page5));



            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));




        }

    }
}
