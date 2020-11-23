using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Com.Xamarin.Textcounter;
using Xamarin.Forms;
using Xamsperiment.Droid;

[assembly: Dependency(typeof(TextAnalyserHelper))]
namespace Xamsperiment.Droid
{
    public class TextAnalyserHelper : ITextAnalyserHelper
    {
        public int NumConsonants(string text)
        {
            return TextCounter.NumConsonants(text);
        }

        public int NumVowels(string text)
        {
            return TextCounter.NumVowels(text);
        }
    }
}