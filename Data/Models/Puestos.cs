using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Puestos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string  Nombre { get; set; }
        public string Riesgo { get; set; }
        //Opciones [ Alto, Medio, Bajo ]
        
           
        public double SalarioMinimo { get; set; }

        public double SalarioMaximo { get; set; }

        public ICollection<Candidatos> Aspirantes { get; set; }
        
        public int DepartamentoID { get; set; }
        public virtual Departamentos Departamento { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool IsAvailable { get; set; }
        public EstadoPersistencia Estado { get; set; }
    }
}
