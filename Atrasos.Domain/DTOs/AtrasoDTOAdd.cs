using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrasos.Domain.DTOs
{
    public class AtrasoDTOAdd
    {
        public required string Nombre { get; set; }
        public bool Permiso { get; set; }
        public DateTime FechaHora { get; set; }
        public bool EstadoDeuda { get; set; } //1: Pagado; 0: Debe
    }
}
