using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class ExperienciaLaboral
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string PuestoOcupado { get; set; }

        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public double Salario { get; set; }

        public string CandidatoCedula { get; set; }
        public virtual Candidatos Candidato { get; set; }
        

    }
}
