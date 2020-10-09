using System;
namespace GALAXY_NETCORE.Models.DTO
{
    public class Paginacion
    {
        public string Filtro { get; set; }
        public int NroPag { get; set; }
        public int RegPorPag { get; set; }
        public int NroRegTotal { get; set; }
    }
}
