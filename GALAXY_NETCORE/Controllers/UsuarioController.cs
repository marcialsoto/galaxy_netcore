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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioManager usuarioManager;

        public UsuarioController(IUsuarioManager usuarioManager)
        {
            this.usuarioManager = usuarioManager;
        }

        [HttpGet]        public IActionResult Listar()        {            return Ok(usuarioManager.Listar());        }
    }
}