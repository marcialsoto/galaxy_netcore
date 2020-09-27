using System;
using System.Collections.Generic;
using System.Linq;
using GALAXY_NETCORE.Context;
using GALAXY_NETCORE.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GALAXY_NETCORE.Services
{
    public class TipoArticuloServices : ITipoArticuloServices
    {
        private readonly GalaxyContext galaxyContext;
        private readonly ILogger<TipoArticuloServices> logger;


        public TipoArticuloServices(GalaxyContext galaxyContext, ILogger<TipoArticuloServices> logger)
        {
            this.galaxyContext = galaxyContext;
            this.logger = logger;
        }

        public List<TipoArticulo> Listar()
        {
            logger.LogTrace("Llegó al método Listar");
            var result = galaxyContext.TipoArticulos.Include("Articulos").ToList();

            return result;
        }
    }
}
