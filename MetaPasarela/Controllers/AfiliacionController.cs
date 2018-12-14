using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Meta.Entities.Modelos;
using Meta.Repository;
using MetaPasarela.ViewModels;

namespace MetaPasarela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfiliacionController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger loggerdb;
        private readonly ILogger<Transaccion> loggertxt;

        public AfiliacionController(IRepositorioWrapper rep, ILogger<Transaccion> logger, Serilog.ILogger seriLog)
        {
            Repositorio = rep;
            this.loggertxt = logger;
            this.loggerdb = seriLog;
        }



        [HttpGet("{ide:int}")]
        public async Task<IActionResult> GetAll(int ide)
        {
            try
            {
                var lista = await this.Repositorio.Afiliaciones.FindAsyc(x => x.EntidadId == ide);

                if (!lista.Any())
                {
                    return Ok(new { ok = false, mensaje = "No se encontró afiliaciones registradas." });
                }

                return Ok(new { ok = true, rol = lista, total = lista.Count() });
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
        public async Task<IActionResult> Agregar(Afiliacion item)
        {
            var mensaje = "";
            try
            {
                if (item.NumAfiliacion != null)
                {
                    item.NumAfiliacion = item.NumAfiliacion.Trim();

                    // validar si existe
                    var itemdb = await this.Repositorio.Afiliaciones.FindAsyc(x => x.NumAfiliacion == item.NumAfiliacion && x.EntidadId == item.EntidadId);

                    if (itemdb.Any())
                    {
                        return Ok(new { ok = false, mensaje = "No se guardo el registro. El número de afiliacion ya esta registrado en esta entidad." });
                    }

                    var r = await this.Repositorio.Afiliaciones.AddAsync(item);
                    await this.Repositorio.CompleteAsync();

                    mensaje = $"Se agregó la afiliacion, correctamente";

                    this.loggertxt.LogInformation(mensaje);

                    return Ok(new { ok = true, mensaje, afiliacion = r });
                }
                else
                {
                    return Ok(new { ok = false, mensaje = "debe escribir el número o codigo de afiliacion" });
                }

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


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var mensaje = "";
            try
            {
                var itemdb = await this.Repositorio.Afiliaciones.GetByIdAsync(id);

                if (itemdb != null)
                {
                    this.Repositorio.Afiliaciones.Remove(itemdb);
                    await this.Repositorio.CompleteAsync();

                    return Ok(new { ok = true, mensaje = "Se eliminó la afiliacion correctamente" });
                }
                else
                {
                    return Ok(new { ok = false, mensaje = "No se encontró la afiliacion a eliminar" });
                }

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


        [HttpPut("{ide:int}/{ida:int}")]
        public async Task<IActionResult> SetPrincipal(int ide, int ida)
        {
            string mensaje = "";

            try
            {
                var lista = await this.Repositorio.Afiliaciones.FindAsyc(x => x.EntidadId == ide);

                if (lista.Any())
                {

                    foreach (var ia in lista)
                    {
                        ia.Principal = false;

                        if (ia.Id == ida)
                        {
                            ia.Principal = true;
                        }
                    }

                    await this.Repositorio.CompleteAsync();

                    return Ok(new { ok = true, mensaje = "Se actualizó la afiliacion como principal" });
                }
                else
                {
                    return Ok(new { ok = false, mensaje = "No se encontró la afiliaciones a la entidad" });
                }


            }
            catch (Exception ex)
            {
                mensaje = $"Se produjo un error al registrar en la bd";

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