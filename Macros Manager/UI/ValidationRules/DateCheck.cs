using System;
using System.Windows;

namespace Macros_Manager.UI.ValidationRules
{
    public class DateCheck : DependencyObject
    {
        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(DateTime), typeof(DateCheck));
    }
}