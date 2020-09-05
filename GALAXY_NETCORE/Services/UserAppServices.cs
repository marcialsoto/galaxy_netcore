using System;
using System.Collections.Generic;
using System.Linq;
using GALAXY_NETCORE.Context;
using GALAXY_NETCORE.Models.DTO;
using Microsoft.Extensions.Logging;

namespace GALAXY_NETCORE.Services
{
    public class UserAppServices : IUserAppServices
    {
        private readonly GalaxyContext galaxyContext;
        private readonly ILogger<UserAppServices> logger;

        public UserAppServices(GalaxyContext galaxyContext, ILogger<UserAppServices> logger)
        {
            this.galaxyContext = galaxyContext;
            this.logger = logger;
        }


        public List<UserApp> Listar()
        {
            logger.LogError("Llegó al método Listar de Usuario");
            var result = galaxyContext.UserApps.ToList();

            return result;
        }
    }
}
