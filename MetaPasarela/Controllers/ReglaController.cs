using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.Entities.Modelos;
using Meta.Repository;
using MetaPasarela.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetaPasarela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReglaController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger loggerdb;
        private readonly ILogger<Regla> loggertxt;



        public ReglaController(IRepositorioWrapper rep, ILogger<Regla> logger, Serilog.ILogger seriLog)
        {
            Repositorio = rep;
            this.loggertxt = logger;
            this.loggerdb = seriLog;
        }

        //Agregar Regla
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Regla item)
        {
            try
            {
                item.FechaReg = DateTime.Now;

                var r = await this.Repositorio.Reglas.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                loggertxt.LogInformation($"Se agregó la regla correctamente. Por el usuario {item.UsuarioId}");

                return Ok(new
                {
                    ok = true,
                    mensaje = "Se agregó la regla correctamente",
                    regla = r
                });

            }
            catch (Exception ex)
            {
                loggertxt.LogError(ex.InnerException.Message);

                return BadRequest(new
                {
                    ok = false,
                    mensaje = "Se produjo un error al crear la regla",
                    errors = new { mensaje = ex.Message }

                });

            }
        }


        // Quitar 
        [HttpDelete("{idr:int}/{idu:int}")]
        public async Task<IActionResult> Quitar(int idr, int idu)
        {
            try
            {
                var itemdb = await this.Repositorio.Reglas.GetByIdAsync(idr);

                if (itemdb == null)
                {
                    return Ok(new { ok = false, mensaje = "No se encontró la regla a eliminar" });
                }

                this.Repositorio.Reglas.Remove(itemdb);
                await this.Repositorio.CompleteAsync();

                loggertxt.LogInformation($"Se quito la regla {idr} por el usuario {idu}");

                return Ok(new { ok = true, mensaje = "Se quitó la regla correctamente", regla = itemdb });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = "Se produjo un error al crear la Usuario",
                    errors = new { mensaje = ex.Message }
                });
            }
        }

        // Get Reglas por entidad

        [HttpGet("{ide:int}")]
        public async Task<IActionResult> GetReglas(int ide)
        {
            try
            {
                var lista = await this.Repositorio.Reglas.GetReglasAllInclude(ide);

                if (!lista.Any())
                {
                    return Ok(new { ok = false, mensaje = "No se encontró reglas para la entidad " });
                }

                List<VMRegla> listaReglas = new List<VMRegla>();

                foreach (var reg in lista)
                {
                    VMRegla item = new VMRegla();

                    item.Id = reg.Id;
                    item.Ide = reg.EntidadId;
                    item.Entidad = reg.Entidad.Nombre;
                    item.Idg = reg.GrupoId == null ? 0 : reg.GrupoId.Value;
                    item.Grupo = reg.GrupoId == null ? "" : reg.Grupo.Nombre;
                    item.Idp = reg.PaisId == null ? 0 : reg.PaisId.Value;
                    item.Pais = reg.PaisId == null ? "" : reg.Pais.Nombre;
                    item.Idr = reg.RedPagoId;
                    item.RedPago = reg.RedPago.Nombre;
                    item.Idpas = reg.PasarelaId;
                    item.Pasarela = reg.Pasarela.Nombre;

                    listaReglas.Add(item);
                }


                return Ok(new { ok = true, total = lista.Count(), reglas = listaReglas });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = $"Se produjo un error al obtener las reglas de la entidad {ide}",
                    errors = new { mensaje = ex.Message }
                });

            }
        }



    }
}