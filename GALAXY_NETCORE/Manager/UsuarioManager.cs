using System;
using System.Collections.Generic;
using System.Linq;
using GALAXY_NETCORE.Models.BE;
using GALAXY_NETCORE.Models.DTO;
using GALAXY_NETCORE.Services;

namespace GALAXY_NETCORE.Manager
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUserAppServices userAppServices;

        public UsuarioManager(IUserAppServices userAppServices)
        {
            this.userAppServices = userAppServices;
        }


        public List<Usuario> Listar()
        {
            List<UserApp> list = userAppServices.Listar();

            List<Usuario> listResult = (from item in list
                                            select new Usuario()
                                            {
                                                Codigo = item.UserId,
                                                Credencial = item.Credential,
                                                Clave = item.Password,
                                                Nombres = item.FullName
                                            }
                                        ).ToList();

            return listResult;
        }
    }
}
