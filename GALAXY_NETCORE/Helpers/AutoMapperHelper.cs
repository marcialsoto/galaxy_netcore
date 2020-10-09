using System;
using AutoMapper;
using GALAXY_NETCORE.Models.BE;
using GALAXY_NETCORE.Models.DTO;

namespace GALAXY_NETCORE.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Opcion, OpcionBE>()
                .ForMember(t => t.Codigo, u => u.MapFrom(src => src.IdOpcion))
                .ForMember(t => t.Nombre, u => u.MapFrom(src => src.NombreOpcion))
                .ForMember(t => t.Enlace, u => u.MapFrom(src => src.UrlOpcion))
                .ForMember(t => t.Icono, u => u.MapFrom(src => src.NombreIcono));
        }
    }
}
