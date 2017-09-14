using System.Data.Entity;
using Macros_Manager.Unity;
using Macros_Manager.Unity.Enums;
using SQLite.CodeFirst;

namespace Macros_Manager.Model
{
    public class MacroContextInitializer : SqliteDropCreateDatabaseAlways<MacroContext>
    {
        public MacroContextInitializer(DbModelBuilder a_modelBuilder)
            : base(a_modelBuilder)
        {
        }

        protected override void Seed(MacroContext a_context)
        {
            var dashboards = new tNode
            {
                Name = "Dashboards",
                CanBeDeleted = false,
                RawDescription = "Dashboard description",
                Type = NodeType.Label,
                ChildNodes = 
                {
                    new tNode
                    {
                        Name = "First Dashboard",
                        CanBeDeleted = true,
                        RawDescription = "Dashboard description",
                        Type = NodeType.Label,
                    },
                    new tNode
                    {
                        Name = "First Dashboard",
                        CanBeDeleted = true,
                        RawDescription = "Dashboard description",
                        Type = NodeType.Label
                    }
                }
            };

            a_context.NodeData.Add(dashboards);

            var psController = new tController
            {
                Type = MacroControllerType.LoopMacro,
                Macro = new tMacro
                {
                    Type = MacroType.Powershell,
                    Script = "notepad",
                }
            };

            a_context.Controllers.Add(psController);

            var powershell = new tMarcoNode
            {
                Name = "Powershell",
                CanBeDeleted = true,
                RawDescription = "Powershell Type",
                Controller = psController,
                Type = NodeType.Macro,
            };

            a_context.MacroNodes.Add(powershell);

            a_context.SaveChanges();
        }
    }
}