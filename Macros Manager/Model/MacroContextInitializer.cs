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
                Type = UnityDefs.NodeTypes.Label,
                ChildNodes = 
                {
                    new tNode
                    {
                        Name = "First Dashboard",
                        CanBeDeleted = true,
                        RawDescription = "Dashboard description",
                        Type = UnityDefs.NodeTypes.Label,
                    },
                    new tNode
                    {
                        Name = "First Dashboard",
                        CanBeDeleted = true,
                        RawDescription = "Dashboard description",
                        Type = UnityDefs.NodeTypes.Label
                    }
                }
            };

            a_context.NodeData.Add(dashboards);

            var psController = new tController
            {
                Type = MacroControllerType.LoopMacro,
                TMacro = new tMacro
                {
                    Description = UnityDefs.Powershell.GetTypeData(),
                    Name = "powershell macro",
                    Script = "notepad",
                }
            };

            a_context.Controllers.Add(psController);

            var powershell = new tMarcoNode
            {
                Name = "Powershell",
                CanBeDeleted = true,
                RawDescription = "Powershell Description",
                Controller = psController,
                Type = UnityDefs.NodeTypes.Macro,
            };

            a_context.MacroNodes.Add(powershell);

            a_context.SaveChanges();
        }
    }
}