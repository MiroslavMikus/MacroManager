using System.ComponentModel.DataAnnotations;
using Macros_Manager.Unity;
using Macros_Manager.Unity.Enums;

namespace Macros_Manager.Model
{
    public class tController
    {
        public int Id { get; set; }
        public MacroControllerType Type { get; set; }
        public tMacro TMacro { get; set; }
    }
}