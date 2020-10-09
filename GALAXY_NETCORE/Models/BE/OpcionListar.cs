using System;
using System.Collections.Generic;
using GALAXY_NETCORE.Models.DTO;

namespace GALAXY_NETCORE.Models.BE
{
    public class OpcionListar
    {
        public int TotalReg { get; set; }
        public List<OpcionBE>  Opciones { get; set; }
    }
}
