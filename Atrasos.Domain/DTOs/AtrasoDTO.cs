namespace Atrasos.Domain.DTOs
{
    public class AtrasoDTO
    {
        public required string Nombre { get; set; }
        public bool Permiso { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Valor { get; set; }
        public bool EstadoDeuda { get; set; } //1: Pagado; 0: Debe
        public bool EsActivo { get; set; }
    }
}
