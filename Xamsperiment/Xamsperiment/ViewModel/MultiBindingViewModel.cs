using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Xamsperiment.ViewModel
{
    public class MultiBindingViewModel : BaseViewModel
    {
        string _firstName = string.Empty;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                OnPropertyChanged(ref _firstName, value, nameof(FirstName));
            }
        }

        string _middleName = string.Empty;
        public string MiddleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                OnPropertyChanged(ref _middleName, value, nameof(MiddleName));
            }
        }

        public MultiBindingViewModel()
        {
            FirstName = "Test";
            MiddleName = "Name";
        }
    }
}
