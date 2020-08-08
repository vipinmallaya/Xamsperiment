using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;
using Xamsperiment.ViewModel;

namespace Xamsperiment.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShapesPage : ContentPage
    {
        private ShapesViewModel pageViewModel;

        public ShapesPage()
        {
            InitializeComponent();
            (pageViewModel = BindingContext as ShapesViewModel).PropertyChanged += ShapesPage_PropertyChanged;
        }

        private void ShapesPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ShapesViewModel.LineX2))
            {
                if (pageViewModel.LineX2 > SimpleLine.X2)
                {
                    SimpleLine.Animate<double>(nameof(SimpleLine.X2), (val1) =>
                     {
                         return pageViewModel.LineX2 > SimpleLine.X2 ? SimpleLine.X2 + 1: SimpleLine.X2;
                     }, (newValue) => SimpleLine.X2 = newValue,repeat:()=> pageViewModel.LineX2 >= SimpleLine.X2);
                }
            }
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {

        }
    }
}