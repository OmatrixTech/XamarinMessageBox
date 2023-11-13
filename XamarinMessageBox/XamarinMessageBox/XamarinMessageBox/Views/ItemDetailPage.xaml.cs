using System.ComponentModel;
using Xamarin.Forms;
using XamarinMessageBox.ViewModels;

namespace XamarinMessageBox.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}