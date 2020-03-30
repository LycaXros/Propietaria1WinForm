using Data.Models;

namespace Client.ViewModels
{
    public class IdiomaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Grado { get; set; }
        //Opciones [Bajo,Medio,Alto]
        public EstadoPersistencia Estado { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Nombre} \tGrado: {Grado}\tEstado: {Estado}";
        }
    }
}
