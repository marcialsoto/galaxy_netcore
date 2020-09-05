using System;
using System.Collections.Generic;
using GALAXY_NETCORE.Models.DTO;
using GALAXY_NETCORE.Services;

namespace GALAXY_NETCORE.Manager
{
    public class TipoArticuloManager : ITipoArticuloManager
    {
        private readonly ITipoArticuloServices tipoArticuloServices;

        public TipoArticuloManager(ITipoArticuloServices tipoArticuloServices)
        {
            this.tipoArticuloServices = tipoArticuloServices;
        }


        public List<TipoArticulo> Listar()
        {
            return tipoArticuloServices.Listar();
        }
    }
}
