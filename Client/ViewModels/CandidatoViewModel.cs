using System.Collections.Generic;

namespace Client.ViewModels
{
    public class CandidatoViewModel
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int PuestoId { get; set; }
        public string Departamento { get; set; }
        public int RecomiendaId { get; set; }
        public List<CompetenciaViewModel> Competencias { get; set; }
        public List<CapacitacionViewModel> Capacitaciones { get; set; }
        public List<ExperienciaLaboralViewModel> ExperienciaLaborales { get; set; }

        public List<IdiomaViewModel> Idiomas { get; set; }
    }
}
