using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.SimpleModels
{
    public class EmpleadoDataModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }


        public string ProfileInfo => $"{UserName} [{Nombre}]";
    }
}
