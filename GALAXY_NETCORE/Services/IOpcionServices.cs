using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GALAXY_NETCORE.Models.DTO;

namespace GALAXY_NETCORE.Services
{
    public interface IOpcionServices
    {
        Task<List<Opcion>> Listar(Paginacion ent);

        Opcion Actualizar(Opcion ent);

        Opcion Agregar(Opcion ent);

        Opcion Eliminar(Opcion ent);
    }
}
