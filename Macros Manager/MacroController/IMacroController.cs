using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Macros_Manager.Macro;
using Macros_Manager.Unity;

namespace Macros_Manager.MacroController
{
    public interface IMacroController
    {
        IMacro Macro { get; set; }
        MacroType MType { get; set; }
        ICommand Execute { get; set; }

        bool IsRunning { get; set; }
        bool IsActive { get; set; }
    }
}
