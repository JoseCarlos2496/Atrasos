using Atrasos.Application.Interfaces;
using Atrasos.Domain.Entities;
using Atrasos.Domain.Exceptions;
using Atrasos.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atrasos.Application.Services
{
    public class AtrasoService(IAtrasoRepository atrasoRepository, IBaseRepository<Atraso, int> baseRepository) : IAtrasoService
    {

        private readonly IAtrasoRepository _atrasoRepository = atrasoRepository;
        private readonly IBaseRepository<Atraso, int> _baseRepository = baseRepository;



        public async Task<IEnumerable<Atraso>> GetAllAtrasosAsync()
        {
            IEnumerable<Atraso> atrasos = await _baseRepository.GetAllAsync();

            return atrasos;
        }

        public async Task<IEnumerable<Atraso>> GetAtrasosByNombreAsync(string nombre)
        {
            IEnumerable<Atraso> atrasosByNombre = await _atrasoRepository.GetAtrasosByNombreAsync(nombre);

            return atrasosByNombre;
        }

        public async Task<Atraso> GetAtrasoByIdAsync(int id)
        {
            Atraso atraso = await _baseRepository.GetByIdAsync(id);

            return atraso;
        }

        public async Task<Atraso> AddAtrasoAsync(Atraso atraso)
        {
            Atraso? nuevoAtraso;
            
            int dia = DateTime.Now.Day;
            int mes = DateTime.Now.Month;
            int anio = DateTime.Now.Year;
            int min050 = 45;
            int min100 = 1;
            int hora050 = 8;
            int hora100 = 9;

            DateTime fechaInicio050 = new(anio, mes, dia, hora050, min050, 0, DateTimeKind.Local);
            DateTime fechaInicio100 = new(anio, mes, dia, hora100, min100, 0, DateTimeKind.Local);

            if (!string.IsNullOrEmpty(atraso.Nombre))
            {
                if (atraso.FechaHora > fechaInicio050 && atraso.FechaHora < fechaInicio100)
                {
                    atraso.Valor = 0.50;
                }
                else if (atraso.FechaHora > fechaInicio100)
                {
                    atraso.Valor = 1;
                }

                if (atraso.Permiso)
                {
                    atraso.Valor /= 2;
                }

                atraso.Creado = DateTime.Now;
                atraso.Actualizado = null;
                nuevoAtraso = await _baseRepository.AddAsync(atraso);
            }
            else
            {
                throw new BusinessException(Constants.OBJECTISNULL);
            }

            return nuevoAtraso;
        }

        public async Task<bool> UpdateCuentaAsync(Atraso atraso)
        {
            await _baseRepository.GetByIdAsync(atraso.Id);
            
            atraso.Actualizado = DateTime.Now;
            var atrasoActualizado = await _baseRepository.UpdateAsync(atraso);

            return atrasoActualizado;
        }

        public async Task<bool> DeleteCuentaAsync(int id)
        {
            await _baseRepository.GetByIdAsync(id);

            var atrasoEliminado = await _baseRepository.DeleteAsync(id);

            return atrasoEliminado;
        }
    }
}
