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
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloManager articuloManager;

        public ArticuloController(IArticuloManager articuloManager)
        {
            this.articuloManager = articuloManager;
        }

        [HttpGet]        public IActionResult Listar()        {            return Ok(articuloManager.Listar());        }

    }
}