using System.ComponentModel.DataAnnotations;
using Macros_Manager.MacroController;
using Macros_Manager.Unity;
using Macros_Manager.Unity.Enums;
using Macros_Manager.Tools;
using Microsoft.Practices.Unity;

namespace Macros_Manager.Model
{
    public class tController
    {
        public int Id { get; set; }
        public MacroControllerType Type { get; set; }
        public tMacro Macro { get; set; }

        public IMacroController Instance()
        {
            var macro = Macro.Instance();

            return MacroContainer.Container.Resolve<IMacroController>(Type.ToString(), new ParameterOverride("a_macro", macro));
        }
    }
}