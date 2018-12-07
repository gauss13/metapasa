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
    public class RolController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger loggerdb;
        private readonly ILogger<Rol> loggertxt;


        public RolController(IRepositorioWrapper rep, ILogger<Rol> logger, Serilog.ILogger seriLog)
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
                var lista = await this.Repositorio.Roles.GetAllAsyc();


                if(!lista.Any())
                {
                    return Ok(new { ok = false, mensaje = "No se encontró roles registrados." });
                }

                return Ok(new { ok= true, rol = lista, total = lista.Count() });

            

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

        [HttpPut("{idu:int}/{idr:int}")]
        public async Task<IActionResult> Asignar(int idu, int idr)
        {
            try
            {
                var itemdb = await this.Repositorio.Usuarios.GetByIdAsync(idu);
                

                if(itemdb == null)
                {
                    return Ok(new { ok = false, mensaje = "No se encontró el usuario." });
                }

                var rol = await this.Repositorio.Roles.GetByIdAsync(idr);

                if (rol == null)
                {
                    return Ok(new { ok = false, mensaje = "No se encontró el rol a asignar" });
                }

                itemdb.RolId = idr;
                itemdb.Rol = rol;

                return Ok(new { ok = true, usuario = itemdb });


            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = $"Se produjo un error al asignar el rol al usuario",
                    errors = new { mensaje = ex.Message }
                });

            }
        }

    }
}