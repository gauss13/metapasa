using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Meta.Entities.Modelos;
using Meta.Entities.Extenciones;
using Meta.Repository;


namespace MetaPasarela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger loggerdb;
        private readonly ILogger<Transaccion> loggertxt;

        public PaisController(IRepositorioWrapper rep, ILogger<Transaccion> logger, Serilog.ILogger seriLog)
        {
            Repositorio = rep;
            this.loggertxt = logger;
            this.loggerdb = seriLog;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaises()
        {
            try
            {
                var lista = await this.Repositorio.Grupos.GetAllAsyc();

                if (!lista.Any())
                {
                    return Ok(new { ok = false, mensaje = "No se encontró paises registrados." });
                }

                return Ok(new { ok = true, pais = lista, total = lista.Count() });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = $"Se produjo un error al obtener los paises",
                    errors = new { mensaje = ex.Message }
                });

            }
        }

    }
}