using System.Data.Entity;
using Macros_Manager.Unity;
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
                ChildNodes = 
                {
                    new tNode
                    {
                        Name = "First Dashboard",
                        CanBeDeleted = true,
                        RawDescription = "Dashboard description"
                    },
                    new tNode
                    {
                        Name = "First Dashboard",
                        CanBeDeleted = true,
                        RawDescription = "Dashboard description",
                    }
                }
            };

            a_context.NodeData.Add(dashboards);

            var psController = new tController
            {
                Type = MacroControllerTypes.LoopMacro,
                TMacro = new tMacro
                {
                    Description = UnityDefs.Powershell.GetTypeData(),
                    Name = "powershell macro",
                    Script = "notepad",
                }
            };

            a_context.Controllers.Add(psController);

            var powershell = new TMacroTNode
            {
                Name = "Powershell",
                CanBeDeleted = true,
                RawDescription = "Powershell Description",
                TController = psController
            };

            a_context.MacroNodes.Add(powershell);

            a_context.SaveChanges();
        }
    }
}