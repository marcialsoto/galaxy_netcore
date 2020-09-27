using System;
using System.Collections.Generic;
using System.Linq;
using GALAXY_NETCORE.Services;
using BE = GALAXY_NETCORE.Models.BE;
using DTO = GALAXY_NETCORE.Models.DTO;

namespace GALAXY_NETCORE.Manager
{
    public class ArticuloManager : IArticuloManager
    {
        private readonly IArticuloServices articuloServices;
        public ArticuloManager(IArticuloServices articuloServices)
        {
            this.articuloServices = articuloServices;
        }


        public List<BE.Articulo> Listar()
        {
            List<DTO.Articulo> list = articuloServices.Listar();

            List<BE.Articulo> listResult = (from item in list
                                        select new BE.Articulo()
                                        {
                                            IdArticulo = item.IdArticulo,
                                            TipoArticulo = item.TipoArticulo.NombreTipoArticulo,
                                            NombreArticulo = item.NombreArticulo,
                                            Margen = item.PrecioVenta - item.Costo
                                        }
                                        ).ToList();

            return listResult;
        }
    }
}
