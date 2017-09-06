﻿using System;
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

        public DbSet<tNode> NodeData { get; set; }
        public DbSet<TMacroTNode> MacroNodes { get; set; }
        public DbSet<tTypeDescription> TypeDescriptions { get; set; }
        public DbSet<tMacro> Macros { get; set; }
        public DbSet<tController> Controllers { get; set; }

        protected override void OnModelCreating(DbModelBuilder a_modelBuilder)
        {
            ModelConfig.Configure(a_modelBuilder);

            var initializer = new MacroContextInitializer(a_modelBuilder);

            Database.SetInitializer(initializer);

            base.OnModelCreating(a_modelBuilder);
        }
    }
}
