using Atrasos.Application.Interfaces;
using Atrasos.Domain.DTOs;
using Atrasos.Domain.Entities;
using Atrasos.Domain.Interface;
using Atrasos.Domain.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Atrasos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtrasoController(IMapper mapper, IAtrasoService atrasoService) : Controller
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAtrasoService _atrasoService = atrasoService;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var lstAtrasos = await _atrasoService.GetAllAtrasosAsync();
                ApiResponse<IEnumerable<AtrasoDTO>> res = new()
                {
                    Success = true,
                    Message = "OK",
                    Data = _mapper.Map<IEnumerable<AtrasoDTO>>(lstAtrasos)
                };

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("ByNombre/{nombre}", Name = "GetAtrasosByNombre")]
        public async Task<IActionResult> GetAtrasosByNombreAsync(string nombre)
        {
            try
            {
                var lstAtrasos = await _atrasoService.GetAtrasosByNombreAsync(nombre);
                ApiResponse<IEnumerable<AtrasoDTO>> res = new()
                {
                    Success = true,
                    Message = "OK",
                    Data = _mapper.Map<IEnumerable<AtrasoDTO>>(lstAtrasos)
                };

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("ById/{id}", Name = "GetAtrasosById")]
        public async Task<IActionResult> GetAtrasosByIdAsync(int id)
        {
            try
            {
                var atraso = await _atrasoService.GetAtrasoByIdAsync(id);
                ApiResponse<IEnumerable<AtrasoDTO>> res = new()
                {
                    Success = true,
                    Message = "OK",
                    Data = _mapper.Map<IEnumerable<AtrasoDTO>>(atraso)
                };

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddMovimientoAsync(AtrasoDTOAdd atrasoDTO)
        {
            try
            {

                var movimiento = _mapper.Map<Atraso>(atrasoDTO);
                Atraso atrasoNuevo = await _atrasoService.AddAtrasoAsync(movimiento);
                ApiResponse<AtrasoDTOAdd> res = new()
                {
                    Success = true,
                    Message = "OK",
                    Data = _mapper.Map<AtrasoDTOAdd>(atrasoNuevo)
                };

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateMovimientoAsync([FromBody] AtrasoDTO atrasoDto)
        {
            try
            {
                var atraso = _mapper.Map<Atraso>(atrasoDto);
                bool success = await _atrasoService.UpdateCuentaAsync(atraso);
                ApiResponse<bool> res = new()
                {
                    Success = true,
                    Data = success,
                    Message = success ? "OK" : "Error al actualizar"
                };

                return Ok(res);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimientoAsync(int id)
        {
            try
            {
                bool success = await _atrasoService.DeleteCuentaAsync(id);
                ApiResponse<bool> res = new()
                {
                    Success = true,
                    Data = success,
                    Message = success ? "OK" : "Error al eliminar"
                };
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
