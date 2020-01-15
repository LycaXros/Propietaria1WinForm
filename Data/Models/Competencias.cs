using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Competencias
    {
        public Competencias()
        {
            Candidatos = new HashSet<Candidatos>();
        }

        [Key]
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public EstadoPersistencia Estado { get; set; }
        public virtual ICollection<Candidatos> Candidatos { get;  set; }
    }
}
