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
            a_modelBuilder.Entity<tNode>().ToTable("tNode")
                .HasKey(a => a.Id);
        }

        private static void ConfigureMacroNodeData(DbModelBuilder a_modelBuilder)
        {
            a_modelBuilder.Entity<tMarcoNode>().ToTable("tMacroNode")
                .HasRequired(a => a.Controller)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(false);
        }

        private static void ConfigureControllerData(DbModelBuilder a_modelBuilder)
        {
            a_modelBuilder.Entity<tController>().ToTable("tController")
                .HasKey(a => a.Id);

            a_modelBuilder.Entity<tController>()
                .HasRequired(a => a.TMacro)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(false);
        }

        private static void ConfigureMacroData(DbModelBuilder a_modelBuilder)
        {
            a_modelBuilder.Entity<tMacro>().ToTable("tMacro")
                .HasKey(a => a.Id);

            a_modelBuilder.Entity<tMacro>()
                .HasRequired(a => a.Description)
                .WithRequiredPrincipal()
                .WillCascadeOnDelete(false);
        }

        private static void ConfigureTypeDescritptionData(DbModelBuilder a_modelBuilder)
        {
            a_modelBuilder.Entity<tTypeDescription>().ToTable("tTypeDescription")
                .HasKey(a => a.Id);
        }
    }
}