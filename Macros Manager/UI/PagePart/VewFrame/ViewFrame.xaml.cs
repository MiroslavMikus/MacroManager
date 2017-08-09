using System.Windows.Controls;
using Microsoft.Practices.ObjectBuilder2;

namespace Macros_Manager.UI.PagePart.VewFrame
{
    /// <summary>
    /// Interaction logic for ViewFrame.xaml
    /// </summary>
    public partial class ViewFrame : UserControl
    {
        public ViewFrame()
        {
            InitializeComponent();
        }

        public TabItem ContentItems
        {
            set
            {
                MainViewFrame.Items.Add(value);
            }
        }
    }
}
