using Data.Models;
using System.Collections.Generic;

namespace Client.ViewModels
{
    public class PuestoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Riesgo { get; set; }
        //Opciones [ Alto, Medio, Bajo ]
        public double SalarioMinimo { get; set; }
        public double SalarioMaximo { get; set; }
        public List<CandidatoViewModel> Aspirantes { get; set; }
        public List<CompetenciaViewModel> Competencias { get; set; }
        public int DepartamentoID { get; set; }
        public bool IsAvailable { get; set; }
        public EstadoPersistencia Estado { get; set; }
    }
}
