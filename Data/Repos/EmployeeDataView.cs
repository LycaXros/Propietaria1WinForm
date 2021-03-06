﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    [Table("[dbo].[V_EmployeePuesto]")]
    public class EmployeeDataView
    {
        [Key]
        public Int64 RowId { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public double Salario { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
    }
}
