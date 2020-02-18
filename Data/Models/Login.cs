using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Login
    {
        [Key]
        public int EmpleadoId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public EstadoPersistencia Estado { get; set; }

        public virtual Empleados DatosEmpleado { get; set; }
    }
}
