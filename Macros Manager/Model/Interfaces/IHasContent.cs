using System.Windows.Controls;
using Newtonsoft.Json;

namespace Macros_Manager.Model.Interfaces
{
    public interface IHasContent
    {
        [JsonIgnore]
        ContentControl Content { get; }
    }
}