using Atrasos.Domain.Entities;
using Atrasos.Domain.Interface;
using Atrasos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Atrasos.Infrastructure.Exceptions;

namespace Atrasos.Infrastructure.Repositories
{
    public class AtrasoRepository(AtrasosDBContext db) : IAtrasoRepository
    {
        private readonly AtrasosDBContext _db = db;

        public async Task<IEnumerable<Atraso>> GetAtrasosByNombreAsync(string nombre)
        {
            IEnumerable<Atraso>? atrasos = await _db.Atraso.Where(x => x.Nombre == nombre).OrderBy(x => !x.EstadoDeuda).ToListAsync();
            return atrasos ?? throw new NotFoundException(Constants.MULTIPLENOTFOUND);
        }
    }
}
