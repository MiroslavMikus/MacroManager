using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Macros_Manager.Node;
using Macros_Manager.Node.Interfaces;
using Macros_Manager.Tools;
using Macros_Manager.Unity;
using Microsoft.Practices.Unity;

namespace Macros_Manager.Model
{
    public static class FakeTreeModel
    {
        public static ICollection<INode> GetNodes()
        {
            ObservableCollection<INode> result = new ObservableCollection<INode>
            {
                new LabelNode("Dashboards")
                {
                    CanBeDeleted = false,
                    ChildNodes = new ObservableCollection<INode>()
                    {
                        new LabelNode("Second MacroNode")
                        {
                            CanBeDeleted = true,
                            ChildNodes = new ObservableCollection<INode>() {new LabelNode("Third MacroNode") {CanBeDeleted = true} }
                        },
                        MacroContainer.Container.Resolve<INode>(UnityDefs.Label.Instance, new ParameterOverride("a_name","Fourth MacroNode")),
                    }
                },
                CreateFakePowershellNode(),
                MacroContainer.Container.Resolve<INode>(UnityDefs.Label.Instance, new ParameterOverride("a_name","AHK")),
                MacroContainer.Container.Resolve<INode>(UnityDefs.Label.Instance, new ParameterOverride("a_name","SQL")),
            };
            return result;
        }

        private static IMacroNode CreateFakePowershellNode()
        {
            string script =
@"$itemPath = 'C:\temp';

$tempExist = Test-Path $tempPath;

if (!$tempExist){
    New-Item -Path $itemPath -ItemType Directory;
}

$pathToFile = Join-Path -Path $itemPath -ChildPath temp.txt;

ipconfig /all > $pathToFile;

Start-Process $pathToFile -Wait;

Remove-Item -Path $pathToFile;

if (!$tempExist){
    Remove-Item -Path $itemPath;
}";

            string description = 
@"## Comment
Easy script which shows IpConfig in Notepad.
> Note this notepad will be stored on HDD in C:\temp and after closing notepad will be automatically deleted";

            var ps = MacroContainer.Container.Resolve<IMacroNode>();

            ps.Name = "Powershell";

            ps.Description.RawDescripiton = description;

            ps.MController.Macro.Script = script;

            ps.MController.Macro.Definition = UnityDefs.Powershell.Copy(MacroControllerTypes.Macro);

            return ps;
        }
    }
}
