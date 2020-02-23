using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Empleados
    {
        public Empleados()
        {
            Recomendados = new HashSet<Candidatos>();
            Idiomas = new HashSet<Idiomas>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaIngreso { get; set; }
        public string Departamento { get; set; }
        
        public int PuestoId { get; set; }
        
        public double Salario { get; set; }
        public EstadoPersistencia Estado { get; set; }
        public ICollection<Candidatos> Recomendados { get; set; }

        public virtual Login LoginData { get; set; }
        
        public virtual ICollection<Idiomas> Idiomas { get; set; }
    }
}
