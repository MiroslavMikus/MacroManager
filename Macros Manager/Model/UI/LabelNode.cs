using System.Collections.Generic;
using System.Windows.Controls;
using Macros_Manager.UI.Tools;
using Macros_Manager.Tools;
using Macros_Manager.Unity;
using static Macros_Manager.Unity.VmcSingeltion;


namespace Macros_Manager.Model.UI
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
                    Content = VmcContainer.Container.Resolve<ContentControl>(UnityDefs.View.Description)
                }
            };
            return CreateViewWrapper(items);
        }
    }
}