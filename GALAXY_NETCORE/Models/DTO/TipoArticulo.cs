using System;
using System.Collections.Generic;

namespace GALAXY_NETCORE.Models.DTO
{
    public class TipoArticulo
    {
        public int IdTipoArticulo { get; set; }
        public string NombreTipoArticulo { get; set; }

        public virtual List<Articulo> Articulos { get; set; }
    }
}
