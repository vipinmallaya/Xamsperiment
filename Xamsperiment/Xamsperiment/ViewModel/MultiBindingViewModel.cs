using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;
using Xamsperiment.Core;

namespace Xamsperiment.ViewModel
{
    public class MultiBindingViewModel : BaseViewModel
    {
        private string _firstName = string.Empty;
        private string _middleName = string.Empty;
        private string _fallbackTest;
        private string _state = string.Empty;
        private string _vehicleNumber = string.Empty;
        private Employee _employee;

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

        public string FallbackTest
        {
            get => _fallbackTest;
            set
            {
                try
                {
                    OnPropertyChanged(ref _fallbackTest, value, nameof(FallbackTest));
                }
                catch
                {
                    //Expecting null exception
                }
            }
        }

        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                OnPropertyChanged(ref _state, value, nameof(State));
            }
        }

        public string VehicleNumber
        {
            get
            {
                return _vehicleNumber;
            }
            set
            {
                OnPropertyChanged(ref _vehicleNumber, value, nameof(VehicleNumber));
            }
        }

        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                OnPropertyChanged(ref _employee, value, nameof(Employee));
            }
        }

        public Command UpdateBindingCommand => new Command(OnUpdateTextBindingAction);
        public MultiBindingViewModel()
        {
            FirstName = "Test";
            MiddleName = "Name"; 
            Employee = new Employee()
            {
                FirstName = "Initial First",
                LastName = "Initial Last"
            };
        }

        private void OnUpdateTextBindingAction(object obj)
        {
            FirstName = "New Value";
            MiddleName = "New Middle Name";
            Employee = new Employee()
            {
                FirstName = "FirstName",
                LastName = "LastName"
            };
        }
    }
}
