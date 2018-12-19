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
    public class GrupoController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger loggerdb;
        private readonly ILogger<Transaccion> loggertxt;

        public GrupoController(IRepositorioWrapper rep, ILogger<Transaccion> logger, Serilog.ILogger seriLog)
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
                var lista = await this.Repositorio.Grupos.GetAllAsyc();              

                if (!lista.Any())
                {
                    return Ok(new { ok = false, mensaje = "No se encontró grupos registrados." });
                }

                return Ok(new { ok = true, grupo = lista, total = lista.Count() });
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

        [HttpPost]
        public async Task<IActionResult> Agregar(Grupo item)
        {
            var mensaje = "";
            try
            {
                if (item != null)
                {

                    var r = await this.Repositorio.Grupos.AddAsync(item);
                    await this.Repositorio.CompleteAsync();

                    mensaje = $"Se agregó el grupo, correctamente";

                    this.loggertxt.LogInformation(mensaje);

                    return Ok(new { ok = true, mensaje, grupo = r });
                }
                else
                {
                    return Ok(new { ok = false, mensaje = "No se agregó el grupo" });
                }

            }
            catch (Exception ex)
            {
                mensaje = $"Se produjo un error al agregar el grupo";

                this.loggertxt.LogError(mensaje);

                return BadRequest(new
                {
                    ok = false,
                    mensaje,
                    errors = new { mensaje = ex.Message }
                });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, Grupo itemEdit)
        {
            var mensaje = "";

            try
            {

                var itemdb = await this.Repositorio.Grupos.GetByIdAsync(id);

                if (itemdb == null)
                {
                    return Ok(new { ok = false, mensaje = "No se encontró el grupo" });
                }

                itemdb.Map(itemEdit);

                var r = this.Repositorio.Grupos.Update(itemdb);
                await this.Repositorio.CompleteAsync();

                if (r == null)
                    return Ok(new { ok = false, mensaje = "No se actualizó el grupo", grupo = r });



                return Ok(new { ok = true, mensaje = "Se actualizo el grupo, correctamente", grupo = r });

            }
            catch (Exception ex)
            {
                mensaje = $"Se produjo un error al actualizar el grupo";

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