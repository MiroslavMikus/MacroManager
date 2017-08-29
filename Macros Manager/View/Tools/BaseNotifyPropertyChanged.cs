using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Macros_Manager.View.Tools
{
    public abstract class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string a_propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(a_propertyName));
        }

        protected virtual void OnPropertyChanged(params string[] a_propertyName)
        {
            foreach (var property in a_propertyName)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }
    }
}
