using System;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Macros_Manager.Node;
using SQLite.CodeFirst;

namespace Macros_Manager.Model
{
    public class MacroContext : DbContext
    {
        public MacroContext()
            : base("MacroDb")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<NodeData> NodeDatas { get; set; }
        public DbSet<MacroNodeData> MacroNodes { get; set; }
        public DbSet<TypeDescriptionData> TypeDescriptions{ get; set; }
        public DbSet<MacroData> Macros { get; set; }
        public DbSet<ControllerData> Controllers { get; set; }

        protected override void OnModelCreating(DbModelBuilder a_modelBuilder)
        {
            var initializer = new MacroContextInitializer(a_modelBuilder);

            Database.SetInitializer(initializer);

            base.OnModelCreating(a_modelBuilder);
        }
    }

    public class MacroContextInitializer : SqliteDropCreateDatabaseWhenModelChanges<MacroContext>
    {
        public MacroContextInitializer(DbModelBuilder a_modelBuilder) 
            : base(a_modelBuilder)
        {
        }

        protected override void Seed(MacroContext a_context)
        {
            var dashboards = new NodeData {Name = "Dashboards",CanBeDeleted = false,RawDescription = "Dashboard description"};

            base.Seed(a_context);
        }
    }

    public static class Modelconfig
    {
        public static void Configure(MacroContext a_context)
        {
            
        }
    }
}
