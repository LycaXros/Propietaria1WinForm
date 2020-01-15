using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Puestos
    {
        [Key]
        public int Id { get; set; }
        public string  Nombre { get; set; }
        public string Riesgo { get; set; }
        //Opciones [ Alto, Medio, Bajo ]
        
           
        public double SalarioMinimo { get; set; }

        public double SalarioMaximo { get; set; }

        public ICollection<Candidatos> Aspirantes { get; set; }

        public int DepartamentoID { get; set; }
        public virtual Departamentos Departamento { get; set; }
        public EstadoPersistencia Estado { get; set; }
    }
}
