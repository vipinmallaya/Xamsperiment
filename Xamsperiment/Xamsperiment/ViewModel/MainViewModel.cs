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
        public Command ShapesCommand { get; set; }
        public Command AppThemeCommand { get; set; }
        private NavigationPage NavigationPage
        {
            get
            {
                return App.Current.MainPage as NavigationPage;
            }
        }
        public MainViewModel()
        {
            MultiBindingCommand = new Command(MultiBindingAction);
            AppThemeCommand = new Command(AppThemeAction);
        }

        private async void AppThemeAction(object obj)
        {
            await NavigationPage.PushAsync(new AppThemePage());
        }

        private async void MultiBindingAction(object obj)
        {
            await NavigationPage.PushAsync(new MultiBindingPage());
        }

        private async void ShapesAction(object obj)
        {
            await (App.Current.MainPage as NavigationPage).PushAsync(new MultiBindingPage());
        }
    }
}
