//using AutoMapper;
using System;
using System.Threading.Tasks;
using GALAXY_NETCORE.Models.BE;
using GALAXY_NETCORE.Services;
using GALAXY_NETCORE.Models.DTO;
using System.Collections.Generic;

namespace GALAXY_NETCORE.Manager
{
    public class OpcionManager : IOpcionManager
    {
        private readonly IOpcionServices opcionServices;
        //private readonly IMapper mapper;

        public OpcionManager(IOpcionServices opcionServices)
        {
            this.opcionServices = opcionServices;
            //this.mapper = mapper;
        }

        public OpcionBE Actualizar(OpcionBE ent)
        {
            var request = new Opcion()
            {
                IdOpcion = ent.Codigo,
                NombreOpcion = ent.Nombre,
                UrlOpcion = ent.Enlace,
                NombreIcono = ent.Icono
            };

            var res = opcionServices.Actualizar(request);

            var result = new OpcionBE()
            {
                Codigo = res.IdOpcion,
                Nombre = res.NombreOpcion,
                Enlace = res.UrlOpcion,
                Icono = res.NombreIcono
            };

            return result;
        }

        public async Task<OpcionListar> Listar(Paginacion ent)
        {

            List<Opcion> opciones = await opcionServices.Listar(ent);
            var listaRes = new List<OpcionBE>();

            foreach (var item in opciones)
            {
                var elem = new OpcionBE()
                {
                    Codigo = item.IdOpcion,
                    Nombre = item.NombreOpcion,
                    Enlace = item.UrlOpcion,
                    Icono = item.NombreIcono
                };

                listaRes.Add(elem);
            }
            OpcionListar res = new OpcionListar { Opciones = listaRes, TotalReg = ent.NroRegTotal };
            return res;
        }

    }
}
