using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Candidatos
    {
        public Candidatos()
        {
            Competencias = new HashSet<Competencias>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(15,ErrorMessage = "Formato de la Cedula 000-0000000-0 ")]
        [Index("CedulaCandidato", IsUnique = true)]
        public string Cedula { get; set; }
        public string Nombre { get; set; }

               
        public int PuestoId { get; set; }
        public virtual Puestos PuestoAspira { get; set; }

        public string Departamento { get; set; }

        public virtual ICollection<Competencias> Competencias { get; set; }

        public ICollection<Capacitaciones> Capacitaciones { get; set; }
        public ICollection<ExperienciaLaboral> ExperienciaLaborales { get; set; }

        public int RecomiendaId { get; set; }
        public virtual Empleados RecomendadoPor { get; set; }
    }
}
