using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Custom.MessageBox;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinMessageBox.Views;

namespace XamarinMessageBox.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        IModalMessageBoxServiceHandler modalMessageBoxServiceHandler = null;
        public AboutViewModel(IModalMessageBoxServiceHandler modalMessageBoxServiceHandler)
        {
            this.modalMessageBoxServiceHandler = modalMessageBoxServiceHandler;
            Title = "About";
            OpenSelfDialogCommand = new Command(async () => OpenSelfModalMessageBox());
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            OpenAlertdialogCommand = new Command(async () => OpenAlertDiaog());
            OpenConfirmDialogCommand = new Command(async () => await OpenConfirmDiaog());
        }
        private async Task OpenSelfModalMessageBox()
        {
            await modalMessageBoxServiceHandler.ShowSelfCreatedMessageBox(new SelMessageBox());
        }
        private async Task OpenConfirmDiaog()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //Dependency injection service
                //CustomConfirmMessageBox customConfirmMessageBox = await modalMessageBoxServiceHandler.GetConfirmationMessageBox(messageTitle: "", messageText: "If you want to set the text of a Xamarin.Forms button with the first letter capitalized and the rest in small caps dynamically in code-behind, you can achieve this by manipulating the button's Text property in your C# code", messageBoxFirstButtonText: "Yes", messageBoxButtonSecondText: "No");
                //customConfirmMessageBox.YesButtonEventHandler += (sender, obj) =>
                //{

                //};
                //customConfirmMessageBox.NoButtonEventHandler += (sender, obj) =>
                //{

                //};
                //Wthout instance method
                CustomConfirmMessageBox customConfirmMessageBox = await ModalMessageBoxHandler.GetConfirmationMessageBox(messageTitle: "Warning", messageText: "If you want to set the text of a Xamarin.Forms button with the first letter capitalized and the rest in small caps dynamically in code-behind, you can achieve this by manipulating the button's Text property in your C# code", messageBoxFirstButtonText: "Yes", messageBoxButtonSecondText: "No");
                customConfirmMessageBox.YesButtonEventHandler += (sender, obj) =>
                {

                };
                customConfirmMessageBox.NoButtonEventHandler += (sender, obj) =>
                {

                };
            });
        }

        private void OpenAlertDiaog()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                CustomAlertMessageBox customAlertMessageBox = await modalMessageBoxServiceHandler.GetCustomMessageBox(messageTitle: "Warning", messageText: "If you want to set the text of a Xamarin.Forms button with the first letter capitalized and the rest in small caps dynamically in code-behind, you can achieve this by manipulating the button's Text property in your C# code", messageBoxButtonText: "OK");
                customAlertMessageBox.OkButtonEventHandler += (sender, obj) =>
                {

                };
            });
        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenAlertdialogCommand { get; }
        public ICommand OpenConfirmDialogCommand { get; }
        public ICommand OpenSelfDialogCommand { get; }
    }
}