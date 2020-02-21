using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Idiomas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Grado { get; set; }
        //Opciones [Bajo,Medio,Alto]
        public EstadoPersistencia Estado { get; set; }
        public virtual ICollection<Candidatos> Candidatos { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }

    }
}
