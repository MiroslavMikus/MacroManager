using System.Collections.Generic;
using System.Windows.Controls;

namespace Macros_Manager.UI.PagePart.ViewFrame
{
    /// <summary>
    /// Interaction logic for ViewFrame.xaml
    /// </summary>
    public partial class ViewFrame : UserControl
    {
        public ViewFrame(ICollection<TabItem> a_items)
        {
            InitializeComponent();
            MainViewFrame.ItemsSource = a_items;
        }
    }
}
