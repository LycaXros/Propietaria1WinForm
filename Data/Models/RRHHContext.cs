﻿using Data.Repos;
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
        public RRHHContext() : base("name=RRHH_Connection")
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
        public DbSet<EmployeeDataView> V_EmployeePuesto { get; set; }
        public DbSet<Login> Credenciales { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Puestos>()
                .HasRequired(d => d.Departamento)
                .WithMany(g => g.Puestos)
                .HasForeignKey(p => p.DepartamentoID);

            modelBuilder.Entity<Candidatos>()
                .HasRequired(c => c.PuestoAspira)
                .WithMany(p => p.Aspirantes)
                .HasForeignKey(c => c.PuestoId);

            modelBuilder.Entity<Capacitaciones>()
                .HasRequired(c => c.Candidato)
                .WithMany(c => c.Capacitaciones)
                .HasForeignKey(c => c.CandidatoCedula);

            modelBuilder.Entity<ExperienciaLaboral>()
                .ToTable("Experiencia_Laboral_Candidato");

            modelBuilder.Entity<ExperienciaLaboral>()
                .HasRequired(e => e.Candidato)
                .WithMany(c => c.ExperienciaLaborales)
                .HasForeignKey(e => e.CandidatoCedula);

            modelBuilder.Entity<Empleados>()
                .HasMany(e => e.Recomendados)
                .WithRequired(e => e.RecomendadoPor)
                .HasForeignKey(e => e.RecomiendaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleados>()
                .HasOptional(e => e.LoginData)
                .WithRequired(e => e.DatosEmpleado);

            modelBuilder.Entity<Empleados>()
                .HasMany(e => e.Idiomas)
                .WithMany(e => e.Empleados)
                .Map(ee =>
                {
                    ee.MapLeftKey("EmpleadoRef");
                    ee.MapRightKey("IdiomasRef");
                    ee.ToTable("EmpleadosIdiomas");
                });

            modelBuilder.Entity<Candidatos>()
                .HasMany(e => e.Idiomas)
                .WithMany(e => e.Candidatos)
                .Map(ee =>
                {
                    ee.MapLeftKey("CandidatoRef");
                    ee.MapRightKey("IdiomasRef");
                    ee.ToTable("CandidatosIdiomas");
                });

            modelBuilder.Entity<Competencias>()
                .HasRequired(e => e.Puesto)
                .WithMany(e => e.Competencias)
                .HasForeignKey(e => e.PuestoId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Empleados>()
                .HasOptional(e => e.Puesto)
                .WithMany(e => e.Empleados)
                .HasForeignKey(e => e.PuestoId)
                .WillCascadeOnDelete(false);

        }
    }
}
