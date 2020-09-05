using System;
using System.Collections.Generic;
using GALAXY_NETCORE.Models.DTO;

namespace GALAXY_NETCORE.Manager
{
    public interface ITipoArticuloManager
    {
        List<TipoArticulo> Listar();
    }
}
