using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class RRHHContext : DbContext
    {
        public RRHHContext(): base("name=RRHH_Connection")
        {
            Database.SetInitializer(new RRHHContextInitializer());
        }

        public DbSet<Capacitaciones> Capacitaciones { get; set; }
        public DbSet<Idiomas> Idiomas { get; set; }
        public DbSet<Competencias> Competencias { get; set; }
        public DbSet<Puestos> Puestos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Candidatos> Candidatos { get; set; }
        public DbSet<ExperienciaLaboral> ExpLaborales { get; set; }
        public DbSet<Empleados> Empleados { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Puestos>()
                .HasRequired(d => d.Departamento)
                .WithMany(g => g.Puestos)
                .HasForeignKey(p=>p.DepartamentoID);

            modelBuilder.Entity<Candidatos>()
                .HasRequired(c => c.PuestoAspira)
                .WithMany(p => p.Aspirantes)
                .HasForeignKey(c => c.PuestoId);

            modelBuilder.Entity<Candidatos>()
                .HasMany(c => c.Competencias)
                .WithMany(cc => cc.Candidatos)
                .Map(Cc =>
                {
                    Cc.MapLeftKey("CandidatosRefKey");
                    Cc.MapRightKey("CompetenciasRefKey");
                    Cc.ToTable("CandidatosCompetencias");
                });
            modelBuilder.Entity<Capacitaciones>()
                .HasRequired(c => c.Candidato)
                .WithMany(c => c.Capacitaciones)
                .HasForeignKey(c => c.CandidatoId);

            modelBuilder.Entity<ExperienciaLaboral>()
                .ToTable("Experiencia_Laboral_Candidato");

            modelBuilder.Entity<ExperienciaLaboral>()
                .HasRequired(e => e.Candidato)
                .WithMany(c => c.ExperienciaLaborales)
                .HasForeignKey(e => e.CandidatoId);


        }
    }
}
