using System.Data.Entity;
using Macros_Manager.Unity;
using SQLite.CodeFirst;

namespace Macros_Manager.Model
{
    public class MacroContextInitializer : SqliteDropCreateDatabaseWhenModelChanges<MacroContext>
    {
        public MacroContextInitializer(DbModelBuilder a_modelBuilder)
            : base(a_modelBuilder)
        {
        }

        protected override void Seed(MacroContext a_context)
        {
            var dashboards = new NodeData
            {
                Name = "Dashboards",
                CanBeDeleted = false,
                RawDescription = "Dashboard description",
                ChildNodes = 
                {
                    new NodeData
                    {
                        Name = "First Dashboard",
                        CanBeDeleted = true,
                        RawDescription = "Dashboard description"
                    },
                    new NodeData
                    {
                        Name = "First Dashboard",
                        CanBeDeleted = true,
                        RawDescription = "Dashboard description",
                    }
                }
            };

            a_context.NodeData.Add(dashboards);

            var powershell = new MacroNodeData
            {
                Name = "Powershell",
                CanBeDeleted = true,
                RawDescription = "Powershell Descripttion",
                Controller = new ControllerData
                {
                    Type = MacroControllerTypes.LoopMacro,
                    Macro = new MacroData
                    {
                        Description = UnityDefs.Powershell.GetTypeData(),
                        Name = "powershell macro",
                        Script = "notepad",
                    }
                }
            };

            a_context.MacroNodes.Add(powershell);

            base.Seed(a_context);
        }
    }
}