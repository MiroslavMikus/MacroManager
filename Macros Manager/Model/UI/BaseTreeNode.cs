using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Macros_Manager.Model.Interfaces;
using Macros_Manager.UI.PagePart;
using Macros_Manager.UI.PagePart.Description;
using Macros_Manager.UI.Tools;
using Macros_Manager.Unity;
using Microsoft.Practices.Unity;
using static Macros_Manager.Unity.VmcSingleton;


namespace Macros_Manager.Model.UI
{
    public abstract class BaseTreeNode : BaseNotifyPropertyChanged, INode
    {
        private ICollection<INode> _childNodes;

        protected BaseTreeNode()
        {
            ChildNodes = new ObservableCollection<INode>();
            Description = new DescriptionViewModel();
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
            var view = VmcContainer.Container.Resolve<ContentControl>(UnityDefs.View.Frame, new ParameterOverride("a_items", a_tabItems));

            if (view != null) view.DataContext = this;

            return view;
        }
    }
}