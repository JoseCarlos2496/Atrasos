using Atrasos.Domain.Exceptions;

namespace Atrasos.Domain.Entities
{
    public class Atraso : BaseEntity<int>
    {
        public required string Nombre { get; set; }
        public bool Permiso { get; set; } = false;
        public DateTime FechaHora { get; set; }

        /// <summary>
        /// Valor > 0
        /// </summary>
        public double Valor { get; set; }

        /// <summary>
        /// F:0: Debe
        /// T:1: Pagado 
        /// </summary>
        public bool EstadoDeuda { get; set; } = false;
        public bool EsActivo { get; set; } = true;
        public DateTime Creado { get; set; }
        public DateTime? Actualizado { get; set; }
    }
}
