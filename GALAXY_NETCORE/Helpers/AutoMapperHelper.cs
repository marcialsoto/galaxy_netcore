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

            CreateMap<OpcionBE, Opcion>()
                .ForMember(t => t.IdOpcion, u => u.MapFrom(src => src.Codigo))
                .ForMember(t => t.NombreOpcion, u => u.MapFrom(src => src.Nombre))
                .ForMember(t => t.UrlOpcion, u => u.MapFrom(src => src.Enlace))
                .ForMember(t => t.NombreIcono, u => u.MapFrom(src => src.Icono));
        }
    }
}
