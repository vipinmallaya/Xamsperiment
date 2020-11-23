using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamsperiment.Models;

namespace Xamsperiment.View.TemplateSelectors
{
    public class MarksTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PassTemplate { get; set; }
        public DataTemplate FailTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Student)item).TotalMarks >= 40 ? PassTemplate : FailTemplate;
        }
    }
}
