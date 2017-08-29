using System.Data.Entity;

namespace Macros_Manager.Model
{
    public static class ModelConfig
    {
        public static void Configure(DbModelBuilder a_modelBuilder)
        {
            ConfigureNodeData(a_modelBuilder);
            ConfigureMacroNodeData(a_modelBuilder);
            ConfigureControllerData(a_modelBuilder);
            ConfigureMacroData(a_modelBuilder);
            ConfigureTypeDescritptionData(a_modelBuilder);

        }

        private static void ConfigureNodeData(DbModelBuilder a_modelBuilder)
        {
            a_modelBuilder.Entity<NodeData>().ToTable("NodeData")
                .HasKey(a => a.Id);
        }

        private static void ConfigureMacroNodeData(DbModelBuilder a_modelBuilder)
        {
            a_modelBuilder.Entity<MacroNodeData>().ToTable("MacroNodeData")
                .HasRequired(a => a.Controller)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(false);
        }

        private static void ConfigureControllerData(DbModelBuilder a_modelBuilder)
        {
            a_modelBuilder.Entity<ControllerData>().ToTable("ControllerData")
                .HasKey(a => a.Id);

            a_modelBuilder.Entity<ControllerData>()
                .HasRequired(a => a.Macro)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(false);
        }

        private static void ConfigureMacroData(DbModelBuilder a_modelBuilder)
        {
            a_modelBuilder.Entity<MacroData>().ToTable("MacroData")
                .HasKey(a => a.Id);

            a_modelBuilder.Entity<MacroData>()
                .HasRequired(a => a.Description)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(false);
        }

        private static void ConfigureTypeDescritptionData(DbModelBuilder a_modelBuilder)
        {
            a_modelBuilder.Entity<TypeDescriptionData>().ToTable("TypeDescriptionData")
                .HasKey(a => a.Id);
        }
    }
}