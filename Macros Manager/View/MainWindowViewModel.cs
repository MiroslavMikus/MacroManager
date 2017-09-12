using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Macros_Manager.Model;
using Macros_Manager.Node.Interfaces;
using Macros_Manager.View.PagePart.NewNodeDialog;
using Macros_Manager.View.Tools;
using MaterialDesignThemes.Wpf;
using System.Data.Entity;
using NewNodeView = Macros_Manager.View.PagePart.NewNodeDialog.NewNodeView;

namespace Macros_Manager.View
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            using (var context = new MacroContext())
            {
                var test2 = context.Macros.Count();

                foreach (var macro in context.MacroNodes.Include(a=>a.TController).Include(a=>a.TController.TMacro).ToList())
                {
                    var test = macro;
                }

                foreach (var macro in context.NodeData.ToList())
                {
                    var test = macro;
                }
            }

            Settings = AppSettings.GetSettings();
        }

        public AppSettings Settings { get; set; }

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
            var parentNode = a as INode;

            var view = new NewNodeView { DataContext = new NewNodeViewModel(parentNode) };

            INode result = await DialogHost.Show(view, "RootDialog") as INode;

            if (result != null)
                parentNode?.ChildNodes.Add(result);
        });

        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }
    }
}
