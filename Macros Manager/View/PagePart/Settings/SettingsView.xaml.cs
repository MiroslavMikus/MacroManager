using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Macros_Manager.View.PagePart.Settings
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void ComboBox_OnDropDownClosed(object a_sender, EventArgs a_e)
        {
            TgEnable.IsChecked = false;
        }

        /// <summary>
        /// Accept only numbers
        /// </summary>
        private void NumberValidationTextBox(object a_sender, TextCompositionEventArgs a_e)
        {
            Regex regex = new Regex("[^0-9]+$");

            a_e.Handled = regex.IsMatch(a_e.Text);
        }

        /// <summary>
        /// Disable Space
        /// </summary>
        private void UIElement_OnPreviewKeyDown(object a_sender, KeyEventArgs a_e)
        {
            if (a_e.Key == Key.Space)
                a_e.Handled = true;
        }

        /// <summary>
        /// Disable Paste
        /// </summary>
        private void CommandBinding_OnCanExecute(object a_sender, CanExecuteRoutedEventArgs a_e)
        {
            a_e.CanExecute = false;
            a_e.Handled = true;
        }
    }
}
