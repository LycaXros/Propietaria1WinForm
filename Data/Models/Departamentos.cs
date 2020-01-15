using System.Collections.Generic;

namespace Data.Models
{
    public class Departamentos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Puestos> Puestos { get; set; }

        public EstadoPersistencia Estado { get; set; }


    }
}
