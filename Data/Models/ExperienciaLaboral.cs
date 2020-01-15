using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class ExperienciaLaboral
    {
        [Key]
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string PuestoOcupado { get; set; }

        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public double Salario { get; set; }

        public int CandidatoId { get; set; }
        public virtual Candidatos Candidato { get; set; }
        

    }
}
