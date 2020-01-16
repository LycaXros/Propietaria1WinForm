using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Empleados
    {
        [Key]
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime FechaIngreso { get; set; }
        public string Departamento { get; set; }
        
        public int PuestoId { get; set; }
        
        public double Salario { get; set; }
        public EstadoPersistencia Estado { get; set; }
    }
}
