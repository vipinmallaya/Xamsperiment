using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamsperiment.ViewModel
{
    public class BehaviourViewModel : BaseViewModel
    {
        private string email;

        public string Email
        {
            get => email;
            set => OnPropertyChanged(ref email, value, nameof(Email));
        }

        private string phone;

        public string Phone
        {
            get => phone;
            set => OnPropertyChanged(ref phone, value, nameof(Phone));
        }


        public Command SubmitCommand { get; set; }

        public BehaviourViewModel()
        {
            SubmitCommand = new Command(SubmitAction);
        }

        private void SubmitAction(object obj)
        {
            if(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Phone))
            {
                IsValid = false;
            }
        }
    }
}
