using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;

namespace Xamsperiment.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void OnPropertyChanged<T>(ref T obj, T value, string fieldName)
        {
            if (value == null || obj.Equals(value))
            {
                return;
            }
            obj = value;
            if (string.IsNullOrEmpty(fieldName))
            {
                if (MainThread.IsMainThread)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(fieldName));
                }
                else
                {
                    MainThread.BeginInvokeOnMainThread(() => PropertyChanged(this, new PropertyChangedEventArgs(fieldName)));
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
