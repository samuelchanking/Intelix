using App4.ViewModels;
using Syncfusion.GridCommon.ScrollAxis;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public string HeadColorIDP
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

        public int a;
      
        public ItemDetailPage()
        {
            InitializeComponent();
        }

        private void GridTapped(RowColumnIndex rowColIndex, object rowData)
        {
            
            
        }

        async void Button(RowColumnIndex rowColIndex, object rowData)
        {

        }
    }
}