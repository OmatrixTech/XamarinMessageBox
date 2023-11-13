using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMessageBox.ViewModels;

namespace XamarinMessageBox.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = App.ServiceProvider.GetRequiredService<AboutViewModel>();
        }
    }
}