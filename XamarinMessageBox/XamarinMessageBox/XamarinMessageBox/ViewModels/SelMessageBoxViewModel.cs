using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Custom.MessageBox;
using Xamarin.Forms;

namespace XamarinMessageBox.ViewModels
{
    public class SelMessageBoxViewModel
    {
        public ICommand CloseSelfPopupCommand { get; }
        IModalMessageBoxServiceHandler modalMessageBoxServiceHandler = null;
        public SelMessageBoxViewModel(IModalMessageBoxServiceHandler modalMessageBoxServiceHandler)
        {
            this.modalMessageBoxServiceHandler = modalMessageBoxServiceHandler;
            CloseSelfPopupCommand = new Command(async () => OpenSelfModalMessageBox());
        }

        private void OpenSelfModalMessageBox()
        {
            //Dependency Injection service
            modalMessageBoxServiceHandler.HideSelfCreatedMessageBox();

            //Without instance method
           // ModalMessageBoxHandler.HideSelfCreatedMessageBox();
        }
    }
}
