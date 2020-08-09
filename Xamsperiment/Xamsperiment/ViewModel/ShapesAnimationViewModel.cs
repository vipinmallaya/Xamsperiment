using System;
using System.Collections.Generic;
using System.Text;

namespace Xamsperiment.ViewModel
{
    public class ShapesAnimationViewModel : BaseViewModel
    {

        private bool isSignupVisible;

        public bool IsSignupVisible
        {
            get => isSignupVisible;
            set => OnPropertyChanged(ref isSignupVisible, value, nameof(IsSignupVisible));
        }

        private bool isLoginButtonVisible;

        public bool IsLoginButtonVisible
        {
            get => isLoginButtonVisible;
            set => OnPropertyChanged(ref isLoginButtonVisible, value, nameof(IsLoginButtonVisible));
        }

        internal void ViewInitializationCompleted()
        {
            IsLoginButtonVisible = true;
            IsSignupVisible = true;
        }
    }
}
