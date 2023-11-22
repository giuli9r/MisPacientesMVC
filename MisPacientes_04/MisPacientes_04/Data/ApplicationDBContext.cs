using Microsoft.EntityFrameworkCore;
using MisPacientes_04.Models;

namespace MisPacientes_04.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :
           base(options)
        {
        }

        /*Agregar los modelos*/

        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Anamnesis> Anamnesis { get; set; }
        public virtual DbSet<AntecedenteFamiliar> AntecedenteFamiliar { get; set; }
        //public virtual DbSet<AntecedentesPersonales> AntecedentesPersonales { get; set; }
        //public virtual DbSet<EstudioComplementario> EstudioComplementario { get; set; }
        public virtual DbSet<ExamenFisico> ExamenFisico { get; set; }
        public virtual DbSet<ObraSocial> ObraSocial { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anamnesis>()
                .HasOne(e => e.AntecedenteFamiliar)
                .WithOne(ed => ed.Anamnesis)
                .HasForeignKey<AntecedenteFamiliar>(ed => ed.AnamnesisRefId);
           
            modelBuilder.Entity<Anamnesis>()
                .HasMany(a => a.ExamenFisico)             // Anamnesis has many ExamenFisico
                .WithOne(ef => ef.Anamnesis)                 // ExamenFisico has one Anamnesis
                .HasForeignKey(ef => ef.AnamnesisId);        // Foreign key is AnamnesisId in ExamenFisico
        }


    }
}
