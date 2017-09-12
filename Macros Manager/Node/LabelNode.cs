using System.Collections.Generic;
using System.Windows.Controls;
using Macros_Manager.Model;
using Macros_Manager.Tools;
using Macros_Manager.Unity;
using Macros_Manager.View.Tools;

namespace Macros_Manager.Node
{
    public class LabelNode : BaseTreeNode
    {
        public LabelNode(string a_name)
        {
            Name = a_name;
        }

        private string _name;

        public sealed override string Name
        {
            get { return _name; }
            set { this.MutateVerbose(ref _name, value, RaisePropertyChanged()); }
        }

        protected override ContentControl ContentCreator()
        {
            List<TabItem> items = new List<TabItem>()
            {
                new TabItem
                {
                    Header = UnityDefs.View.Description,
                    Content = VmcSingleton.VmcContainer.Container.Resolve<ContentControl>(UnityDefs.View.Description)
                }
            };
            return CreateViewWrapper(items);
        }
    }
}