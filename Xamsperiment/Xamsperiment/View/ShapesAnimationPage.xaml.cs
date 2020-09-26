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
            await Task.Delay(2000);
            await InitialCircleFormationAnimation(); 
            await ShowTickMark(); 
            //viewModel.ViewInitializationCompleted();
        }
        private Task InitialCircleFormationAnimation()
        {

            return InitialCircle.FadeTo(1, 1000,Easing.Linear);

                InitialCircleSegment.Animate<Point>(nameof(InitialCircleSegment.Point3),
                transform: (input) =>
                {
                    Point newPoint = new Point(150, 50);
                    if (InitialCircleSegment.Point3.X < 280)
                    {
                        newPoint.X = InitialCircleSegment.Point3.X + 1;
                    }
                    if (InitialCircleSegment.Point3.Y < 100)
                    {
                        newPoint.Y = InitialCircleSegment.Point3.Y + 1;
                    }
                    return newPoint;
                }, 
                callback:(inputPoint)=>
                {     
                    InitialCircleSegment.Point3 = inputPoint;
                },
                repeat: () =>
                {
                    return InitialCircleSegment.Point3.X != 280 && InitialCircleSegment.Point3.Y != 100;
                 }) ;
        }

        private async Task ShowTickMark()
        {
            //InitialCircleSegment 
            InitialCircle.FadeTo(0, 250);
            await LongTickHandle.FadeTo(1, 1000);
            
            await ShortHandle.FadeTo(1, 1000); 
        }
    }
}