using Data.Models;

namespace Client.ViewModels
{
    public class CompetenciaViewModel
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public EstadoPersistencia Estado { get; set; }
    }
}
