using System;
namespace GALAXY_NETCORE.Models.BE
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string TipoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public decimal Margen { get; set; }
    }
}
