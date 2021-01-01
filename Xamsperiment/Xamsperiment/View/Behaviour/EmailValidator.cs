using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Xamsperiment.View.Behaviour
{
    public class EmailValidatorBehaviour : Behavior<Entry>
    {

        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public static readonly BindableProperty ValidatorIsValidProperty = 
            BindableProperty.Create("ValidatorIsValid",
                typeof(bool), 
                typeof(EmailValidatorBehaviour), 
                null,BindingMode.TwoWay,
                null,
                propertyChanged:propertyChanged);

        private static void propertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
             
        }

        public bool ValidatorIsValid
        {
            get { return (bool)GetValue(ValidatorIsValidProperty); }
            set { SetValue(ValidatorIsValidProperty, value); }
        }

        public string ValidatorTextLabelName { get; set; }
        private Entry currentControl;
        protected override void OnAttachedTo(Entry bindable)
        {
            currentControl = bindable;
            var parentView = bindable.Parent;
            bindable.TextChanged += HandleTextChanged;
            
            base.OnAttachedTo(bindable);
        }  

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {

            BindingContext = BindingContext ?? currentControl.BindingContext;
            var parentLayout = currentControl.Parent;
            var label = parentLayout.FindByName(ValidatorTextLabelName) as Label;
            bool IsValid = false;
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
            label.IsVisible = !IsValid;
            ValidatorIsValid = IsValid;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }


    }
}
