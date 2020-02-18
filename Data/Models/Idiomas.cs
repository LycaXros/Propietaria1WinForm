using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Idiomas
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Grado { get; set; }
        //Opciones [Bajo,Medio,Alto]
        public EstadoPersistencia Estado { get; set; }
        public Collection<Empleados> Empleados { get; set; }
        public Collection<Candidatos> Candidatos { get; set; }
    }
}
