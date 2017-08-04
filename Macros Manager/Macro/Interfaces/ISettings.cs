using Macros_Manager.Model.Interfaces;

namespace Macros_Manager.Macro.Interfaces
{
    public interface ISettings : IHasContent
    {
        bool IsValid();
    }
}
