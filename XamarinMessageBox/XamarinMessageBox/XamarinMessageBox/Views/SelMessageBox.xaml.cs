using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMessageBox.ViewModels;

namespace XamarinMessageBox.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelMessageBox : ContentView
    {
        public SelMessageBox()
        {
            InitializeComponent();
            BindingContext = App.ServiceProvider.GetRequiredService<SelMessageBoxViewModel>();
        }
    }
}