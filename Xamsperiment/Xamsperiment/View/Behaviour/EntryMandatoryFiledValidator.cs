using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamsperiment.ViewModel;

namespace Xamsperiment.View.Behaviour
{
    public class EntryMandatoryFiledValidator : Behavior<Entry>
    {
        public static readonly BindableProperty ValidatorIsValidProperty =
            BindableProperty.Create("ValidatorIsValid",
                typeof(bool?),
                typeof(EmailValidatorBehaviour),
                null, BindingMode.TwoWay,
                null,
                propertyChanged: propertyChanged
                );
        private static void propertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var validator = bindable as EntryMandatoryFiledValidator;

            var result = validator.Validate(validator.currentControl.Text ?? string.Empty);
            validator.ShowValidationMessage(result, validator.validationMessageLabel);
        }

        protected Entry currentControl;
        private Label validationMessageLabel;

        public string ValidatorTextLabelName { get; set; }
        public string ValidationMessage { get; set; }

        public bool ValidatorIsValid
        {
            get { return (bool)GetValue(ValidatorIsValidProperty); }
            set { SetValue(ValidatorIsValidProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            currentControl = bindable;
            currentControl.BindingContextChanged += CurrentControl_BindingContextChanged;

            base.OnAttachedTo(bindable);
        }

        protected virtual bool Validate(string data)
        {
            ValidationMessage = "Enter Valid Data";
            return data.Length > 0;
        }

        protected virtual void ShowValidationMessage(bool isValid, Label label)
        {
            label.IsVisible = !isValid;
            label.Text = ValidationMessage;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void CurrentControl_BindingContextChanged(object sender, EventArgs e)
        {
            BindingContext = currentControl.BindingContext;
            var parentLayout = currentControl.Parent;
            validationMessageLabel = parentLayout.FindByName(ValidatorTextLabelName) as Label;
        }

        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                validationMessageLabel.IsVisible = false;
                return;
            }

            bool IsValid = Validate(e.NewTextValue);
            ValidatorIsValid = IsValid;
            currentControl.TextColor = IsValid ? Color.Default : Color.Red;

            ShowValidationMessage(IsValid, validationMessageLabel);

        }
    }
}
