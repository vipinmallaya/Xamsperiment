using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamsperiment.View;

namespace Xamsperiment.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public Command MultiBindingCommand { get; set; }
        public MainViewModel()
        {
            MultiBindingCommand = new Command(multiBindingAction);
        }

        private async void multiBindingAction(object obj)
        {
            await (App.Current.MainPage as NavigationPage).PushAsync(new MultiBindingPage());
        }
    }
}
