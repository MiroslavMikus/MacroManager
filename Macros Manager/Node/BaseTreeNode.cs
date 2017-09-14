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

        protected BaseTreeNode(INodeModel a_definition)
        {
            _nodeData = a_definition;

            ChildNodes = new ObservableCollection<INode>();

            Description = new DescriptionViewModel {RawDescripiton = a_definition.RawDescription};

            CanBeDeleted = _nodeData.CanBeDeleted;
        }

        protected virtual INodeModel _nodeData { get; set; }

        public virtual string Name
        {
            get { return _nodeData.Name; }
            set
            {
                if (_nodeData.Name.Equals(value)) return;
                _nodeData.Name = value;
                OnPropertyChanged();
            }
        }

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