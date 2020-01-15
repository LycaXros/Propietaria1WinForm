using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Competencias
    {
        public Competencias()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public EstadoPersistencia Estado { get; set; }
        public virtual ICollection<Candidatos> Candidatos { get;  set; }
    }

    public class Candidatos
    {
        public Candidatos()
        {
            Competencias = new HashSet<Competencias>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(15,ErrorMessage = "Formato de la Cedula 000-0000000-0 ")]
        public string Cedula { get; set; }
        public string Nombre { get; set; }

               
        public int PuestoId { get; set; }
        public virtual Puestos PuestoAspira { get; set; }

        public string Departamento { get; set; }

        public virtual ICollection<Competencias> Competencias { get; set; }

        public ICollection<Capacitaciones> Capacitaciones { get; set; }
        public ICollection<ExperienciaLaboral> ExperienciaLaborales { get; set; }

        public int RecomiendaId { get; set; }
        public virtual Empleado RecomendadoPor { get; set; }
    }

    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Departamento { get; set; }
        
        public int PuestoId { get; set; }
        public virtual Puestos Puesto { get; set; }
        
        public double Salario { get; set; }
        public EstadoPersistencia Estado { get; set; }
    }

    public class ExperienciaLaboral
    {
        [Key]
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string PuestoOcupado { get; set; }

        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public double Salario { get; set; }

        public int CandidatoId { get; set; }
        public virtual Candidatos Candidato { get; set; }
        

    }
}
