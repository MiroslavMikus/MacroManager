using System.Windows.Controls;
using Newtonsoft.Json;

namespace Macros_Manager.Node.Interfaces
{
    public interface IHasContent
    {
        [JsonIgnore]
        ContentControl Content { get; }
    }
}