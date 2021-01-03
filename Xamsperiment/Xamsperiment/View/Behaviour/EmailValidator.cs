using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Xamsperiment.View.Behaviour
{
    public class EmailValidatorBehaviour : EntryMandatoryFiledValidator
    { 
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
          
        protected override bool Validate(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                ValidationMessage = "Enter Email"; //Set it from localization
                return false;
            }
            if (base.Validate(data))
            {
                ValidationMessage = "Enter Valid Email";
                return (Regex.IsMatch(data, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            }
            return false;
        } 
    }
}
