using System;
using System.Collections.Generic;
using GALAXY_NETCORE.Models.BE;

namespace GALAXY_NETCORE.Manager
{
    public interface IArticuloManager
    {
        List<Articulo> Listar();
    }
}
