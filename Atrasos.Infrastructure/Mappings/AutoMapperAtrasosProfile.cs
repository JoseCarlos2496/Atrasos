using AutoMapper;
using Atrasos.Domain.DTOs;
using Atrasos.Domain.Entities;

namespace Atrasos.Infrastructure.Mappings
{
    public class AutoMapperAtrasosProfile : Profile
    {
        public AutoMapperAtrasosProfile()
        {
            CreateMap<Atraso, AtrasoDTO>().ReverseMap();
            CreateMap<Atraso, AtrasoDTOAdd>().ReverseMap();
        }
    }
}
