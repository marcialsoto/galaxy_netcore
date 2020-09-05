using System;
namespace GALAXY_NETCORE.Models.DTO
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public int IdTipoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }

        public virtual TipoArticulo TipoArticulo { get; set; }
    }
}
