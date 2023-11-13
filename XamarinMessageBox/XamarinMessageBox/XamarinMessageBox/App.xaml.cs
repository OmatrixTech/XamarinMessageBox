using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Custom.MessageBox;
using Xamarin.Forms;
using XamarinMessageBox.ViewModels;


namespace XamarinMessageBox
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            InitializeComponent();
           //Register modal popup setup
           ModalMessageBoxConfigurationSetup.SetupModalMessageBox(
           customMessageBoxTextColor: Color.White,
           customMessageBoxHeightRequest: 450,
           customMessageBoxWidthRequest: 400,
           customMessageBoxBackgroundColor: Color.FromHex("#000000"),
           customMessageBoxTitlePosition: LayoutOptions.CenterAndExpand,
           customMessageBoxButtonBackgroundColor: Color.FromHex("#0000FF"));
            // Initialize and configure services
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Build the service provider
            ServiceProvider = serviceCollection.BuildServiceProvider();
            MainPage = new AppShell();
        }
        private void ConfigureServices(IServiceCollection services)
        {
            // Register your services here
            services.AddSingleton<IModalMessageBoxServiceHandler, ModalMessageBoxServiceHandler>();
            services.AddSingleton<AboutViewModel>();
            services.AddSingleton<SelMessageBoxViewModel>();
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
