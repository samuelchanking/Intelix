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
    public partial class Page5 : ContentPage
    {
        private kyc tappedB;
        private string myStringProperty1;
        private string gda;

        private string pep;
        private string sow;
        private DateTime dob;
        private string address;
        private string maddress;
        private string fname;
        private string sname;
        private string anum;
        private string ck;
        private string pm;
        private int id;
        private int score;


        public string MyStringProperty1
        {
            get { return myStringProperty1; }
            set
            {
                myStringProperty1 = value;
                OnPropertyChanged(nameof(MyStringProperty1)); // Notify that there was a change on this property
            }
        }
        public string GDA
        {
            get { return gda; }
            set
            {
                gda = value;
                OnPropertyChanged(nameof(GDA)); // Notify that there was a change on this property
            }
        }
        public string PEP
        {
            get { return pep; }
            set
            {
                pep = value;
                OnPropertyChanged(nameof(PEP)); // Notify that there was a change on this property
            }
        }
        public string SOW
        {
            get { return sow; }
            set
            {
                sow = value;
                OnPropertyChanged(nameof(SOW)); // Notify that there was a change on this property
            }
        }

        public DateTime DOB
        {
            get { return dob; }
            set
            {
                dob = value;
                OnPropertyChanged(nameof(DOB)); // Notify that there was a change on this property
            }

        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address)); // Notify that there was a change on this property
            }

        }
        public string Fname
        {
            get { return fname; }
            set
            {
                fname = value;
                OnPropertyChanged(nameof(Fname)); // Notify that there was a change on this property
            }

        }
        public string Sname
        {
            get { return sname; }
            set
            {
                sname = value;
                OnPropertyChanged(nameof(Sname)); // Notify that there was a change on this property
            }

        }
        public string MAddress
        {
            get { return maddress; }
            set
            {
                maddress = value;
                OnPropertyChanged(nameof(MAddress)); // Notify that there was a change on this property
            }

        }
        public string ANum
        {
            get { return anum; }
            set
            {
                anum = value;
                OnPropertyChanged(nameof(ANum)); // Notify that there was a change on this property
            }

        }
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(ID)); // Notify that there was a change on this property
            }

        }

        public string CK
        {
            get { return ck; }
            set
            {
                ck = value;
                OnPropertyChanged(nameof(CK)); // Notify that there was a change on this property
            }

        }

        public string PM
        {
            get { return pm; }
            set
            {
                pm = value;
                OnPropertyChanged(nameof(PM)); // Notify that there was a change on this property
            }

        }
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                OnPropertyChanged(nameof(Score)); // Notify that there was a change on this property
            }

        }


        public Page5(kyc tappedItem1)
        {
            InitializeComponent();
            tappedB = tappedItem1;

            // Set the label text to the name of the tapped person

            BindingContext = this;

            Fname = tappedB.Fname;
            Sname = tappedB.Sname;
            GDA = tappedB.GDA;
            PEP = tappedB.PEP;
            SOW = tappedB.SOW;
            DOB = tappedB.DOB;
            Address = tappedB.Address;
            MAddress = tappedB.MAddress;
            ANum = tappedB.ANum;
            ID = tappedB.ID;
            CK = tappedB.CK;
            PM = tappedB.PM;
            Score = tappedB.score;


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