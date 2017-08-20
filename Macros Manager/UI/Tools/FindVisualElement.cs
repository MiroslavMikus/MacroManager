using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Macros_Manager.UI.Tools
{
    public static class FindVisualElement
    {
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject a_depObj) where T : DependencyObject
        {
            if (a_depObj == null) yield break;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(a_depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(a_depObj, i);

                if (child is T)
                    yield return (T)child;

                foreach (T childOfChild in FindVisualChildren<T>(child))
                    yield return childOfChild;
            }
        }
    }
}
