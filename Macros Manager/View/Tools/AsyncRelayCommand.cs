using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Macros_Manager.View.Tools
{

    public class AsyncRelayCommand : ICommand, IDisposable
    {
        private readonly BackgroundWorker _backgroundWorker = new BackgroundWorker { WorkerSupportsCancellation = true };
        private readonly Func<bool> _canExecute;

        public AsyncRelayCommand(Action a_action, Func<bool> a_canExecute = null, Action<object> a_completed = null,
                            Action<Exception> a_error = null)
        {
            _backgroundWorker.DoWork += (s, e) =>
            {
                CommandManager.InvalidateRequerySuggested();
                a_action();
            };

            _backgroundWorker.RunWorkerCompleted += (s, e) =>
            {
                if (a_completed != null && e.Error == null)
                    a_completed(e.Result);

                if (a_error != null && e.Error != null)
                    a_error(e.Error);

                CommandManager.InvalidateRequerySuggested();
            };

            _canExecute = a_canExecute;
        }

        public void Cancel()
        {
            if (_backgroundWorker.IsBusy)
                _backgroundWorker.CancelAsync();
        }

        public bool CanExecute(object a_parameter)
        {
            return _canExecute == null
                       ? !_backgroundWorker.IsBusy
                       : !_backgroundWorker.IsBusy && _canExecute();
        }

        public void Execute(object a_parameter)
        {
            _backgroundWorker.RunWorkerAsync();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool a_disposing)
        {
            if (!a_disposing) return;
            _backgroundWorker?.Dispose();
        }
    }

}
