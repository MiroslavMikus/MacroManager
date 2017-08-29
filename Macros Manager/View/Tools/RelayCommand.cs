using System;
using System.Windows.Input;

namespace Macros_Manager.View.Tools
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute = null;
        private readonly Predicate<T> _canExecute = null;

        public RelayCommand(Action<T> a_execute)
            : this(a_execute, null)
        {
        }

        public RelayCommand(Action<T> a_execute, Predicate<T> a_canExecute)
        {
            if (a_execute == null)
                throw new ArgumentNullException(nameof(a_execute));

            _execute = a_execute;
            _canExecute = a_canExecute;
        }

        public bool CanExecute(object a_parameter)
        {
            return _canExecute?.Invoke((T)a_parameter) ?? true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object a_parameter)
        {
            _execute((T)a_parameter);
        }
    }
}