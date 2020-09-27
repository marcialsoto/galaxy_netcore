using System;
using System.Collections.Generic;
using System.Linq;
using GALAXY_NETCORE.Context;
using GALAXY_NETCORE.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace GALAXY_NETCORE.Services
{
    public class ArticuloServices : IArticuloServices
    {
        private readonly GalaxyContext galaxyContext;

        public ArticuloServices(GalaxyContext galaxyContext)
        {
            this.galaxyContext = galaxyContext;
        }


        public List<Articulo> Listar()
        {
            var result = galaxyContext.Articulos.Include("TipoArticulo").ToList();

            return result;
        }
    }
}
