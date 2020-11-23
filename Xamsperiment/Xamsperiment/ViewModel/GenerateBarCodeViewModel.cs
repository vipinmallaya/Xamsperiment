using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamsperiment.ViewModel
{
    public class GenerateBarCodeViewModel : BaseViewModel
    {
        private long barcode;

        public long Barcode
        {
            get => barcode;
            set
            {     
                OnPropertyChanged(ref barcode, value, nameof(Barcode));
            }
        }
        public GenerateBarCodeViewModel()
        {
            Barcode = 0;
        }

        public Command SetBarcodeCommand => new Command(GenerateBarcodeAction);

        private void GenerateBarcodeAction(object obj)
        {
            Barcode = 12345678;
        }
    }
}
