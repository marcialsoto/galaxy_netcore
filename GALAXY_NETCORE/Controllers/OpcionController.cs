﻿using System;
using System.Threading.Tasks;
using GALAXY_NETCORE.Manager;
using GALAXY_NETCORE.Models.BE;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GALAXY_NETCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpcionController : ControllerBase
    {
        private readonly IOpcionManager opcionManager;

        public OpcionController(IOpcionManager opcionManager)
        {
            this.opcionManager = opcionManager;
        }

        [HttpGet]
        //[EnableCors("PublicApi")]
        public async Task<IActionResult> Listar(int NroPag, int RegPorPag, string filtro = "")
        {
            var res = await opcionManager.Listar(new Models.DTO.Paginacion { NroPag = NroPag, RegPorPag = RegPorPag, Filtro = filtro });
            return Ok(res);
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] OpcionBE a)
        {
            if (string.IsNullOrEmpty(a.Nombre))
            {
                return BadRequest("Debe enviar el nombre");
            }
            opcionManager.Actualizar(a);
            return Ok(a);

        }

        [HttpPost]
        public IActionResult Agregar([FromBody] OpcionBE a)
        {
            if (string.IsNullOrEmpty(a.Nombre))
            {
                return BadRequest("Debe enviar el nombre");
            }
            opcionManager.Agregar(a);
            return Ok(a);

        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var result = opcionManager.Eliminar(new OpcionBE() { Codigo = id });

            if (result == null)
            {
                return BadRequest("No existe");
            }

            return Ok(result);

        }
    }
}
