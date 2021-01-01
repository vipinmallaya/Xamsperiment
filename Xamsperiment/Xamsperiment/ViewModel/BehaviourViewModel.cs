using System;
using System.Collections.Generic;
using System.Text;

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

        private bool isValid;

        public bool IsValid
        {
            get => isValid;
            set => OnPropertyChanged(ref isValid, value, nameof(IsValid));
        }


    }
}
