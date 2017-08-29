using System.Linq;
using System.Windows.Controls;
using Macros_Manager.View.DependencyObjects;

namespace Macros_Manager.View.PagePart.Settings
{
    /// <summary>
    /// Interaction logic for FutureDatePicker.xaml
    /// </summary>
    public partial class FutureDatePicker : UserControl
    {
        public FutureDatePicker()
        {
            InitializeComponent();
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
