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
    public class EntidadesController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger loggerdb;
        private readonly ILogger<Entidad> loggertxt;

        public EntidadesController(IRepositorioWrapper rep, ILogger<Entidad> logger, Serilog.ILogger seriLog)
        {
            Repositorio = rep;
            this.loggertxt = logger;
            this.loggerdb = seriLog;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lista = await this.Repositorio.Entidades.GetAllAsyc();
                
                if (!lista.Any())
                {
                    return Ok(new { ok = false, mensaje = "No se encontró entidades registradas." });
                }
                return Ok(new { ok = true, entidad = lista, total = lista.Count() });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = $"Se produjo un error al obtener los roles",
                    errors = new { mensaje = ex.Message }
                });

            }
        }

        [HttpGet("{idu}")]
        public async Task<IActionResult> GetAllByUsuario(int idu)
        {
            var mensaje = "";

            try
            {
                var lista = await this.Repositorio.UsuarioEntidades.FindAsyc(x => x.UsuarioId == idu);

                if(!lista.Any())
                {
                    mensaje = "No se encontró entidades asignadas al usuario";
                    return Ok(new { ok=false, mensaje });
                }

                var arrayId = lista.Select(x => x.EntidadId).ToArray();

                var eu = this.Repositorio.Entidades.FindAsyc(x => arrayId.Contains(x.Id));

                return Ok(new { ok=true, entidades = eu });

            }
            catch (Exception ex)
            {
                mensaje = $"Se produjo un error al buscar las entidades";

                this.loggertxt.LogError(mensaje);

                return BadRequest(new
                {
                    ok = false,
                    mensaje,
                    errors = new { mensaje = ex.Message }
                });
            }

        }

        [HttpPut("{idu:int}/{ide:int}")]
        public async Task<IActionResult> AsignarEntidad(UsuarioEntidad item)
        {
            var mensaje = "";
            try
            {
                await this.Repositorio.UsuarioEntidades.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                mensaje = $"Se agregó la entidad, correctamente {item.EntidadId}:{item.UsuarioId}";

                this.loggertxt.LogInformation(mensaje );

                return Ok(new { ok=true, mensaje, item });

            }
            catch (Exception ex)
            {
                 mensaje = $"Se produjo un error al asignar la entidad";

                this.loggertxt.LogError(mensaje);

                return BadRequest(new
                {
                    ok = false,
                    mensaje,
                    errors = new { mensaje = ex.Message }
                });
            }


        }
                
        [HttpDelete]
        public async Task<IActionResult> QuitarEntidad(UsuarioEntidad item)
        {
            var mensaje = "";
            try
            {
                this.Repositorio.UsuarioEntidades.Remove(item);
                await this.Repositorio.CompleteAsync();

                mensaje = $"Se quitó la entidad, correctamente {item.EntidadId}:{item.UsuarioId}";
                this.loggertxt.LogInformation(mensaje);

                return Ok(new { ok = true, mensaje, entidad= item });

            }
            catch (Exception ex)
            {

                mensaje = $"Se produjo un error al asignar la entidad";

                this.loggertxt.LogError(mensaje);

                return BadRequest(new
                {
                    ok = false,
                    mensaje,
                    errors = new { mensaje = ex.Message }
                });
            }
        }


    }
}