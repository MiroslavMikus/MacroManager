using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace Macros_Manager.UI.DependencyObjects
{
    public class AttachedProperties : DependencyObject
    {
        public static DependencyProperty BlockPastDatesProperty = 
            DependencyProperty.RegisterAttached("BlockPastDates", typeof(bool), typeof(AttachedProperties), new PropertyMetadata(false, (a_sender, a_event) =>
                {
                    if (!(bool) a_event.NewValue) return;

                    var element = a_sender as DatePicker;

                    element?.BlackoutDates.AddDatesInPast();
                }));

        public static void SetBlockPastDates(UIElement a_element, CalendarBlackoutDatesCollection a_value)
        {
            a_element?.SetValue(BlockPastDatesProperty, a_value);
        }

        public static CalendarBlackoutDatesCollection GetBlockPastDates(UIElement a_element)
        {
            return (CalendarBlackoutDatesCollection)a_element?.GetValue(BlockPastDatesProperty);
        }
    }
}
