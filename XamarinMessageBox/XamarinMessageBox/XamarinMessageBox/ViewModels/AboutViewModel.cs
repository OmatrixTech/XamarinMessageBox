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
            //Dependency injection service
             await modalMessageBoxServiceHandler.ShowSelfCreatedMessageBox(new SelMessageBox());

            //Wthout instance method
            //ModalMessageBoxHandler.ShowSelfCreatedMessageBox(new SelMessageBox());
        }
        private async Task OpenConfirmDiaog()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                //Dependency injection service
                CustomConfirmMessageBox customConfirmMessageBox = await modalMessageBoxServiceHandler.GetConfirmationMessageBox(messageTitle: "Confirmation messagebox", messageText: "The MIT License (MIT)\r\n\r\nCopyright (c) [2023] [Sanjay kumar jha]\r\n\r\nPermission is hereby granted, free of charge, to any person obtaining a copy\r\nof this software and associated documentation files (the \"Software\"), to deal\r\nin the Software without restriction, including without limitation the rights\r\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\r\ncopies of the Software, and to permit persons to whom the Software is\r\nfurnished to do so, subject to the following conditions:\r\n\r\nThe above copyright notice and this permission notice shall be included in all\r\ncopies or substantial portions of the Software.\r\n\r\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\r\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\r\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\r\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\r\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\r\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\r\nSOFTWARE.\r\n\r\n\r\n\r\nA Xamarin message box, often referred to as a dialog box or alert box, is a user interface element in software \r\napplications used to display information, prompt the user for input, or provide notifications. \r\nIt serves specific functions and has distinct requirements to enhance user interaction. \r\n", messageBoxFirstButtonText: "Pos", messageBoxButtonSecondText: "Neg");
                customConfirmMessageBox.YesButtonEventHandler += (sender, obj) =>
                {

                };
                customConfirmMessageBox.NoButtonEventHandler += (sender, obj) =>
                {

                };
                //Wthout instance method
                //CustomConfirmMessageBox customConfirmMessageBox = await ModalMessageBoxHandler.GetConfirmationMessageBox(messageTitle: "Confirmation", messageText: "If you want to set the text of a Xamarin.Forms button with the first letter capitalized and the rest in small caps dynamically in code-behind, you can achieve this by manipulating the button's Text property in your C# code", messageBoxFirstButtonText: "Ok", messageBoxButtonSecondText: "Cancel");
                //customConfirmMessageBox.YesButtonEventHandler += (sender, obj) =>
                //{

                //};
                //customConfirmMessageBox.NoButtonEventHandler += (sender, obj) =>
                //{

                //};
            });
        }

        private void OpenAlertDiaog()
        {
            //Dependency injection service
            Device.BeginInvokeOnMainThread(async () =>
            {
                CustomAlertMessageBox customAlertMessageBox = await modalMessageBoxServiceHandler.GetCustomMessageBox(messageTitle: "Question", messageText: "The MIT License (MIT)\r\n\r\nCopyright (c) [2023] [Sanjay kumar jha]\r\n\r\nPermission is hereby granted, free of charge, to any person obtaining a copy\r\nof this software and associated documentation files (the \"Software\"), to deal\r\nin the Software without restriction, including without limitation the rights\r\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\r\ncopies of the Software, and to permit persons to whom the Software is\r\nfurnished to do so, subject to the following conditions:\r\n\r\nThe above copyright notice and this permission notice shall be included in all\r\ncopies or substantial portions of the Software.\r\n\r\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\r\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\r\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\r\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\r\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\r\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\r\nSOFTWARE.\r\n\r\n\r\n\r\nA Xamarin message box, often referred to as a dialog box or alert box, is a user interface element in software \r\napplications used to display information, prompt the user for input, or provide notifications. \r\nIt serves specific functions and has distinct requirements to enhance user interaction. \r\n", messageBoxButtonText: "Well");
                customAlertMessageBox.OkButtonEventHandler += (sender, obj) =>
                {

                };
            });

            //Wthout instance method
            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    CustomAlertMessageBox customAlertMessageBox = await ModalMessageBoxHandler.GetCustomMessageBox(messageTitle: "Information", messageText: "If you want to set the text of a Xamarin.Forms button with the first letter capitalized and the rest in small caps dynamically in code-behind, you can achieve this by manipulating the button's Text property in your C# code", messageBoxButtonText: "Demo");
            //    customAlertMessageBox.OkButtonEventHandler += (sender, obj) =>
            //    {

            //    };
            //});
        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenAlertdialogCommand { get; }
        public ICommand OpenConfirmDialogCommand { get; }
        public ICommand OpenSelfDialogCommand { get; }
    }
}