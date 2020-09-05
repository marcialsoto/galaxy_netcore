using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GALAXY_NETCORE.Manager;
using Microsoft.AspNetCore.Mvc;

namespace GALAXY_NETCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoArticuloController : ControllerBase
    {
        private readonly ITipoArticuloManager tipoArticuloManager;

        public TipoArticuloController(ITipoArticuloManager tipoArticuloManager)
        {
            this.tipoArticuloManager = tipoArticuloManager;
        }


        [HttpGet]        public IActionResult Listar()        {            return Ok(tipoArticuloManager.Listar());        }
    }
}