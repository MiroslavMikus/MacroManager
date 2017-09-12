using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Macros_Manager.Model;
using Macros_Manager.Node.Interfaces;
using Macros_Manager.Unity;
using Macros_Manager.View.PagePart.Description;
using Macros_Manager.View.Tools;
using Microsoft.Practices.Unity;

namespace Macros_Manager.Node
{
    public abstract class BaseTreeNode : BaseNotifyPropertyChanged, INode
    {
        private ICollection<INode> _childNodes;

        protected BaseTreeNode()
        {
            ChildNodes = new ObservableCollection<INode>();
            Description = new DescriptionViewModel();
            CanBeDeleted = true;
        }

        public abstract string Name { get; set; }

        public DescriptionViewModel Description { get; set; }

        public ICollection<INode> ChildNodes
        {
            get { return _childNodes; }
            set { this.MutateVerbose(ref _childNodes, value, RaisePropertyChanged()); }
        }

        public bool CanBeDeleted { get; set; }

        public void Delete(INode a_nodeToDelete)
        {
            if (ChildNodes != null)
                foreach (INode node in ChildNodes)
                    node.Delete(a_nodeToDelete);

            if (ChildNodes != null && ChildNodes.Contains(a_nodeToDelete))
                ChildNodes.Remove(a_nodeToDelete);
        }

        public ContentControl Content => ContentCreator();
        protected abstract ContentControl ContentCreator();
        protected ContentControl CreateViewWrapper(IEnumerable<TabItem> a_tabItems)
        {
            var view = VmcSingleton.VmcContainer.Container.Resolve<ContentControl>(UnityDefs.View.Frame, new ParameterOverride("a_items", a_tabItems));

            if (view != null) view.DataContext = this;

            return view;
        }
    }
}