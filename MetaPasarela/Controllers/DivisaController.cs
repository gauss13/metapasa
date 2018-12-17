using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Meta.Entities.Modelos;
using Meta.Repository;

namespace MetaPasarela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisaController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger loggerdb;
        private readonly ILogger<Entidad> loggertxt;

        public DivisaController(IRepositorioWrapper rep, ILogger<Entidad> logger, Serilog.ILogger seriLog)
        {
            Repositorio = rep;
            this.loggertxt = logger;
            this.loggerdb = seriLog;

        }

        [HttpGet]
        public async Task<IActionResult> GetDivisas()
        {
            var lista = await this.Repositorio.Divisas.GetAllAsyc();

            return Ok(new { ok=true, mensaje="Divisas sistema", divisa=lista });
        }
    }
}