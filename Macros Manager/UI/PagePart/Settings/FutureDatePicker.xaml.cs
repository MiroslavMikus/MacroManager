using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Macros_Manager.UI.ValidationRules;
using MahApps.Metro.Controls;

namespace Macros_Manager.UI.PagePart.Settings
{
    /// <summary>
    /// Interaction logic for FutureDatePicker.xaml
    /// </summary>
    public partial class FutureDatePicker : UserControl
    {
        public FutureDatePicker()
        {
            InitializeComponent();
            FuturePickerDate.BlackoutDates.AddDatesInPast();
        }

        private void FuturePickerDate_OnSelectedDateChanged(object a_sender, SelectionChangedEventArgs a_e)
        {
            var check = this.Resources.Values.OfType<DateCheck>().FirstOrDefault();

            if (check == null) return;

            if (FuturePickerDate.SelectedDate != null)
                check.Date = FuturePickerDate.SelectedDate.Value;

            // cheap binding and validation update
            FuturePickerTime.SelectedTime = FuturePickerTime.SelectedTime;
        }
    }
}
