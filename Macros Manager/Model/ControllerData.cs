using System.ComponentModel.DataAnnotations;
using Macros_Manager.Unity;

namespace Macros_Manager.Model
{
    public class ControllerData
    {
        public int Id { get; set; }
        public MacroControllerTypes Type { get; set; }
        public MacroData Macro { get; set; }
    }
}