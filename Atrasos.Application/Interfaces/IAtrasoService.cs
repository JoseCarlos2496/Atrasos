using Atrasos.Domain.Entities;

namespace Atrasos.Application.Interfaces
{
    public interface IAtrasoService
    {
        Task<IEnumerable<Atraso>> GetAllAtrasosAsync();
        Task<IEnumerable<Atraso>> GetAtrasosByNombreAsync(string nombre);
        Task<Atraso> GetAtrasoByIdAsync(int id);
        Task<Atraso> AddAtrasoAsync(Atraso atraso);
        Task<bool> UpdateCuentaAsync(Atraso atraso);
        Task<bool> DeleteCuentaAsync(int id);
    }
}
