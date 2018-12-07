using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.Entities.Modelos;
using Meta.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetaPasarela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioEntidadesController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger seriLogger;
        private readonly ILogger<Usuario> logger;

        private bool ok = false;
        private string mensaje = "";
        private object registro = null;
        private List<object> registros = null;
        private int total = 0;

        public UsuarioEntidadesController(IRepositorioWrapper rep, ILogger<Usuario> logger, Serilog.ILogger seriLog)
        {
            this.logger = logger;
            this.seriLogger = seriLog;
            Repositorio = rep;
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] UsuarioEntidad item)
        {
            try
            {
                // Registra el usuario/entidad en la BD
                var r = await this.Repositorio.UsuarioEntidades.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                if (r == null)
                {
                    ok = false;
                    mensaje = "No se pudo agregar el registro";
                }
                else
                {
                    ok = true;
                    mensaje = "Se agregó el regitro correctamente";
                    registro = r;
                }

                logger.LogInformation(mensaje);
                seriLogger.Information(mensaje);

                return Created("", new
                {
                    ok,
                    mensaje,
                    registro
                });
            }
            catch (Exception ex)
            {
                logger.LogError("Mensaje error");
                seriLogger.Error("mensaje error");

                return BadRequest(new
                {
                    ok = false,
                    mensaje = "Se produjo un error al guardar el registro",
                    errors = new { mensaje = ex.Message }

                });
            }

        }

        [HttpDelete("{idu:int}/{ide:int}")]
        public async Task<IActionResult> Quitar(int idu, int ide)
        {
            var encontrado = await this.Repositorio.UsuarioEntidades.FindAsyc(x => x.UsuarioId == idu && x.EntidadId == ide);

            if (!encontrado.Any())
            {
                ok = false;
                mensaje = "No se encontró el registro";
            }
            else
            {
                ok = true;
                mensaje = $"Se quito la entidad {ide} al usuario {idu}";

                this.Repositorio.UsuarioEntidades.RemoveRange(encontrado);
                await this.Repositorio.CompleteAsync();
            }

            return Ok(new
            {
                ok,
                mensaje,
                registro
            });


        }
    }
}