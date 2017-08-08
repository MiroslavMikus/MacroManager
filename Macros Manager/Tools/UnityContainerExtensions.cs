using Microsoft.Practices.Unity;

namespace Macros_Manager.Tools
{
    public static class UnityContainerExtensions
    {
        public static T Resolve<T>(this UnityContainer a_container, string a_def, params ResolverOverride[] a_overrides) where T : class
        {
            return a_container.Resolve(typeof(T), a_def, a_overrides) as T;
        }
    }
}
