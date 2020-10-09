using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GALAXY_NETCORE.Context;
using GALAXY_NETCORE.Models.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GALAXY_NETCORE.Services
{
    public class OpcionServices : IOpcionServices
    {
        private readonly GalaxyContext galaxyContext;

        public OpcionServices(GalaxyContext galaxyContext)
        {
            this.galaxyContext = galaxyContext;
        }

        public Opcion Actualizar(Opcion ent)
        {
            var entidad = galaxyContext.Opciones.Find(ent.IdOpcion);
            entidad.NombreOpcion = ent.NombreOpcion;
            entidad.UrlOpcion = ent.UrlOpcion;
            entidad.NombreIcono = ent.NombreIcono;

            galaxyContext.SaveChanges();
            return ent;
        }

        public async Task<List<Opcion>> Listar(Paginacion ent)
        {
            var query = (from x in galaxyContext.Opciones select x);

            if (!string.IsNullOrEmpty(ent.Filtro))
            {
                query = query.Where(t =>
                  (t.NombreOpcion)
                  .Contains(ent.Filtro, StringComparison.InvariantCultureIgnoreCase));
            }

            ent.NroRegTotal = await query.CountAsync();

            query = query.Skip(ent.NroPag * ent.RegPorPag).Take(ent.RegPorPag).AsNoTracking();
            return await query.ToListAsync();
        }
    }
}




