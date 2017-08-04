using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Macros_Manager.UI.Tools
{
    public static class NotifyPropertyChangedExtension
    {
        public static void MutateVerbose<TField>(this INotifyPropertyChanged a_instance, ref TField a_field,
            TField a_newValue, Action<PropertyChangedEventArgs> a_raise, [CallerMemberName] string a_propertyName = null)
        {
            if (EqualityComparer<TField>.Default.Equals(a_field, a_newValue)) return;
            a_field = a_newValue;
            a_raise?.Invoke(new PropertyChangedEventArgs(a_propertyName));
        }
    }
}
