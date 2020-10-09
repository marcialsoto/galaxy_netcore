using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GALAXY_NETCORE.Models.BE;
using GALAXY_NETCORE.Models.DTO;

namespace GALAXY_NETCORE.Manager
{
    public interface IOpcionManager
    {
        Task<OpcionListar> Listar(Paginacion ent);
        OpcionBE Actualizar(OpcionBE ent);
    }
}
