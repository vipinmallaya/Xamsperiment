using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Xamsperiment.View.Converter
{
    public class MultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format($"{values[0]}-{values[1]}");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var inputString = value.ToString().Trim();
            if (inputString.Length <= 2)
            {
                var result = value.ToString().Split('-');
                return result;
            }
            else if(inputString.Length >= 4)
            {
                var firstitem = inputString.Substring(0, 4);
                var secondString = inputString.Substring(4);
                return new string[] { firstitem, secondString };
            }
            return null;
        }
    }
}
