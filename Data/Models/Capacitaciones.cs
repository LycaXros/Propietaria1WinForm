﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Capacitaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nivel { get; set; }
        //Opciones[ Grado,PostGrado, Maestria, Doctorado,  Tecnico,    Gestion]
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Institucion { get; set; }

        public string CandidatoCedula { get; set; }
        public virtual Candidatos Candidato { get; set; }
    }
}
