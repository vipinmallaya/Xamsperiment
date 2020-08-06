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

        public Command DarkThemeCommand { get; set; }
        public Command LightThemeCommand { get; set; }

        public AppThemeViewModel()
        {
            DarkThemeCommand = new Command(DarkThemeAction);
            LightThemeCommand = new Command(LightThemeAction);
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
