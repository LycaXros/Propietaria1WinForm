﻿using System;

namespace Client.ViewModels
{
    public class CapacitacionViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nivel { get; set; }
        //Opciones[ Grado,PostGrado, Maestria, Doctorado,  Tecnico,    Gestion]
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Institucion { get; set; }

        public string CandidatoCedula { get; set; }
    }
    public class CandidatoViewModel
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int PuestoId { get; set; }
        public string Departamento { get; set; }
        public int RecomiendaId { get; set; }
    }
}
