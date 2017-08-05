using System;
using System.Windows;
using System.Windows.Threading;

namespace Macros_Manager.Tools
{
    public static class FuncTool
    {
        public static void SyncWithUi(this Action a_action)
        {
            if (Application.Current.Dispatcher.CheckAccess())
                a_action.Invoke();
            else
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(a_action.Invoke));
        }

        public static void SyncWithUi<TInput>(this Action<TInput> a_action, TInput a_input)
        {
            if (Application.Current.Dispatcher.CheckAccess())
                a_action.Invoke(a_input);
            else
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => a_action.Invoke(a_input)));
        }
    }
}