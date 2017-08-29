using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Macros_Manager.Node;

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

        public DbSet<NodeData> NodeData { get; set; }
        public DbSet<MacroNodeData> MacroNodes { get; set; }
        public DbSet<TypeDescriptionData> TypeDescriptions { get; set; }
        public DbSet<MacroData> Macros { get; set; }
        public DbSet<ControllerData> Controllers { get; set; }

        protected override void OnModelCreating(DbModelBuilder a_modelBuilder)
        {
            ModelConfig.Configure(a_modelBuilder);

            var initializer = new MacroContextInitializer(a_modelBuilder);

            Database.SetInitializer(initializer);

            base.OnModelCreating(a_modelBuilder);
        }
    }
}
