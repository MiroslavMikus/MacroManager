using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Macros_Manager.Annotations;
using Macros_Manager.Model;
using Macros_Manager.Model.Interfaces;
using Macros_Manager.Model.UI;
using Macros_Manager.Repository.LocalStorage;
using Macros_Manager.UI.Content;
using Macros_Manager.UI.Tools;
using MaterialDesignThemes.Wpf;

namespace Macros_Manager.UI
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Settings = AppSettings.GetSettings();
        }

        public AppSettings Settings { get; set; }

        public ICommand Sync => new RelayCommand<object>(a => Thread.Sleep(5000));

        public ICommand Async => new AsyncRelayCommand(() => Thread.Sleep(5000));

        public ICommand Delete => new RelayCommand<object>(a =>
        {
            var nodeToDelete = a as INode;

            if (nodeToDelete == null) return;

            if (Settings.Nodes.Contains(nodeToDelete))
            {
                Settings.Nodes.Remove(nodeToDelete);
            }
            else
            {
                foreach (var node in Settings.Nodes)
                    node.Delete(nodeToDelete);
            }
        });

        public ICommand AddNode => new RelayCommand<object>(async a =>
        {
            var view = new NewNodeView { DataContext = new NewNodeViewModel() };

            INode result = await DialogHost.Show(view, "RootDialog") as INode;

            (a as INode)?.ChildNodes.Add(result);
        });

        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }
    }
}
