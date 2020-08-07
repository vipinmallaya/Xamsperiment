using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamsperiment.ViewModel
{
    public class AppThemeViewModel : BaseViewModel
    {
        private string _themeName;

        public string ThemeName
        {
            get => _themeName;
            set => OnPropertyChanged(ref _themeName, value, nameof(ThemeName));
        }

        public Command DarkThemeCommand => new Command(DarkThemeAction);
        public Command LightThemeCommand=> new Command(LightThemeAction);

        public AppThemeViewModel()
        {     
            ThemeName = App.Current.RequestedTheme.ToString();
            App.Current.RequestedThemeChanged += Current_RequestedThemeChanged;
        }

        private void Current_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            ThemeName = e.RequestedTheme.ToString();
        }

        private void LightThemeAction(object obj)
        {
            App.Current.UserAppTheme = OSAppTheme.Light;           
        }

        private void DarkThemeAction(object obj)
        {
            App.Current.UserAppTheme = OSAppTheme.Dark;           
        }
    }
}
