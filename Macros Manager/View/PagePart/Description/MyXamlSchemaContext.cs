using System.Reflection;
using System.Xaml;

namespace Macros_Manager.View.PagePart.Description
{
    public class MyXamlSchemaContext : XamlSchemaContext
    {
        public override bool TryGetCompatibleXamlNamespace(string a_xamlNamespace, out string a_compatibleNamespace)
        {
            if (!a_xamlNamespace.Equals("clr-namespace:Markdig.Wpf"))
                return base.TryGetCompatibleXamlNamespace(a_xamlNamespace, out a_compatibleNamespace);

            a_compatibleNamespace = $"clr-namespace:Markdig.Wpf;assembly={Assembly.GetAssembly(typeof(Markdig.Wpf.Styles)).FullName}";

            return true;
        }
    }
}