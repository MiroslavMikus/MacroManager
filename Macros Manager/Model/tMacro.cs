using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Macros_Manager.Macro;
using Macros_Manager.Node.Interfaces;
using Macros_Manager.Unity;
using Macros_Manager.Unity.Enums;
using Microsoft.Practices.Unity;

namespace Macros_Manager.Model
{
    public class tMacro  
    {
        public int Id { get; set; }
        public MacroType Type { get; set; }
        public ICollection<string> ImportedSettings { get; set; }
        public string Script { get; set; }

        public IMacro Instance() => MacroContainer.Container.Resolve<IMacro>(Type.ToString(), new ParameterOverride("a_definition", this));
    }
}