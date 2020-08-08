using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace Xamsperiment.ViewModel
{
    public class ShapesViewModel : BaseViewModel
    {
        private string _selectedPage;
        private List<string> _shapes;

        private int lineX2;

        public int LineX2
        {
            get => lineX2; 
            set => OnPropertyChanged(ref lineX2, value, nameof(LineX2));
        }

        private bool _lineVisible;

        public bool LineVisible
        {
            get => _lineVisible; 
            set=> OnPropertyChanged(ref _lineVisible, value, nameof(LineVisible));
        }


        public List<string> Shapes
        {
            get => _shapes;
            set => OnPropertyChanged(ref _shapes, value, nameof(Shapes));
        }

        public string SelectedShape
        {
            get => _selectedPage;
            set
            {
                OnPropertyChanged(ref _selectedPage, value, nameof(SelectedShape));
                ShapeSelectionAction();
            }
        }  

        public ShapesViewModel()
        {
            Shapes = new List<string>()
            { 
                "Ellipse",
                "Line",
                "Path",
                "Polygon",
                "Polyline",
                "Rectangle"
            };

            LineX2 = 10;
            LineVisible = false;
        }

        private void ShapeSelectionAction()
        {
            switch (SelectedShape)
            {
                case "Line":
                    LineX2 = 300;
                    LineVisible = true;
                    break;
                default:
                    LineVisible = false;
                    break;
            }
        }
    }
}
