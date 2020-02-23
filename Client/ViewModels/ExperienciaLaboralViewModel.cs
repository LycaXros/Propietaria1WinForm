using System;

namespace Client.ViewModels
{
    public class ExperienciaLaboralViewModel
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string PuestoOcupado { get; set; }

        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public double Salario { get; set; }

        public string CandidatoCedula { get; set; }
    }
}
