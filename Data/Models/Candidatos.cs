using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Candidatos
    {
        public Candidatos()
        {
            Capacitaciones = new HashSet<Capacitaciones>();
            ExperienciaLaborales = new HashSet<ExperienciaLaboral>();
            Idiomas = new HashSet<Idiomas>();
        }

        [Key]
        [Index("CedulaCandidato", IsUnique = true)]
        public string Cedula { get; set; }
        public string Nombre { get; set; }

               
        public int PuestoId { get; set; }
        public virtual Puestos PuestoAspira { get; set; }

        public string Departamento { get; set; }


        public virtual ICollection<Capacitaciones> Capacitaciones { get; set; }
        public virtual ICollection<ExperienciaLaboral> ExperienciaLaborales { get; set; }

        public int RecomiendaId { get; set; }
        public virtual Empleados RecomendadoPor { get; set; }

        public virtual ICollection<Idiomas> Idiomas { get; set; }
    }
}
