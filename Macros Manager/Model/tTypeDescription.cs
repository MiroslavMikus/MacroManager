using System.ComponentModel.DataAnnotations;
using Macros_Manager.Unity;
using Macros_Manager.Unity.Enums;

namespace Macros_Manager.Model
{
    public class tTypeDescription
    {
        public int Id { get; set; }
        public string Instance { get; set; }
        public MacroControllerType PossibleMacroControllersType { get; set; }
    }
}