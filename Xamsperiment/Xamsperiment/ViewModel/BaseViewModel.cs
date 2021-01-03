using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace Xamsperiment.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool? isValid;

        public bool? IsValid
        {
            get => isValid;
            set => OnPropertyChanged(ref isValid, value, nameof(IsValid));
        }

        protected void OnPropertyChanged<T>(ref T obj, T value, string fieldName)
        {
             
            obj = value;
            if (!string.IsNullOrEmpty(fieldName))
            {
                if (MainThread.IsMainThread)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fieldName));
                }
                else
                {
                    MainThread.BeginInvokeOnMainThread(() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(fieldName)));
                }
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
