using Atrasos.Domain.Entities;

namespace Atrasos.Domain.Interface
{
    public interface IAtrasoRepository
    {
        Task<IEnumerable<Atraso>> GetAtrasosByNombreAsync(string nombre);
    }
}
