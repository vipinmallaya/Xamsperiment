using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamsperiment.ViewModel;

namespace Xamsperiment.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShapesAnimationPage : ContentPage
    {
        private ShapesAnimationViewModel viewModel;

        public ShapesAnimationPage()
        {
            InitializeComponent();

            viewModel = BindingContext as ShapesAnimationViewModel;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private async void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(ShapesAnimationViewModel.IsSignupVisible):
                    await AnimateSignupLayout();
                    break;
                case nameof(ShapesAnimationViewModel.IsLoginButtonVisible):
                    await AnimateLoginLayout();
                    break;
                default:
                    break;
            }
        }

        private Task AnimateLoginLayout()
        {
            return LoginLayout.FadeTo(1, 500);
        }

        private Task AnimateSignupLayout()
        {
            return SignupLayout.FadeTo(1, 500);
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            await ShowTickMark();
            await Task.Delay(2000);
            viewModel.ViewInitializationCompleted();
        }

        private Task ShowTickMark()
        {
            return Task.CompletedTask;
        }
    }
}