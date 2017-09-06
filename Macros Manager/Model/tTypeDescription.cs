using System.ComponentModel.DataAnnotations;
using Macros_Manager.Unity;

namespace Macros_Manager.Model
{
    public class tTypeDescription
    {
        public int Id { get; set; }
        public string Instance { get; set; }
        public MacroControllerTypes PossibleMacroControllersTypes { get; set; }
    }
}