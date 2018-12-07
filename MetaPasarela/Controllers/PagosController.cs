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
    public class PagosController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger loggerdb;
        private readonly ILogger<Transaccion> loggertxt;

        public PagosController(IRepositorioWrapper rep, ILogger<Transaccion> logger, Serilog.ILogger seriLog)
        {
            Repositorio = rep;
            this.loggertxt = logger;
            this.loggerdb = seriLog;
        }


        [HttpPost("direct/{ide:int}")]
        public async Task<IActionResult> Directo([FromBody] VMPagoDirecto itemPago, int ide)
        {
            (bool r, string m) result = (false, "");

            try
            {
                result = await PagoDirectoAsync(itemPago, ide);             

                return Ok(new { ok = result.r, mensaje = result.m });

            }
            catch (Exception ex)
            {
                loggertxt.LogError(ex.InnerException.Message);

                return BadRequest(new
                {
                    ok = false,
                    mensaje = "Se produjo un error al realizar el pago",
                    errors = new { mensaje = ex.Message }

                });

            }
        }

        [HttpPost("link/{ide:int}")]
        public async Task<IActionResult> Enlace([FromBody] VMPagoEnlace itemPago, int ide)
        {
            (bool r, string m) result = (false, "");

            try
            {
                result = await PagoLinkAsync(itemPago, ide);

                return Ok(new { ok = result.r, mensaje = result.m });

            }
            catch (Exception ex)
            {
                loggertxt.LogError(ex.InnerException.Message);

                return BadRequest(new
                {
                    ok = false,
                    mensaje = "Se produjo un error al realizar el pago",
                    errors = new { mensaje = ex.Message }

                });

            }
        }

        #region PAGO DIRECTO

        private Task<(bool r, string m)> PagoDirectoAsync(VMPagoDirecto itemPago, int ide)
        {
            var t = Task.Factory.StartNew(() =>
            {
                var r = PagoDirecto(itemPago, ide);
                return r;
            });

            return t;
        }

        private (bool r, string m) PagoDirecto(VMPagoDirecto itemPago, int ide)
        {
            (bool r, string m) result = (false, "");

            try
            {
                loggertxt.LogInformation("inicio de transaccion");

                // Registrar la transaccion
                // Registrar el estado
                // Request -> pasarela
                // Response <- pasarela

                //todo bien
                result = (false, "El pago se registró correctamente");

            }
            catch (Exception ex)
            {
                loggertxt.LogError(ex.InnerException.Message);
                result = (false, ex.Message);
            }
            finally
            {
                // close conexion ws
                // actualizar bd              
                loggertxt.LogInformation("fin de transaccion");
            }

            return result;
        }

        #endregion

        #region PAGO LINK

        private Task<(bool r, string m)> PagoLinkAsync(VMPagoEnlace itemPago, int ide)
        {
            var t = Task.Factory.StartNew(() =>
            {
                var r = PagoLink(itemPago, ide);
                return r;
            });

            return t;
        }

        private (bool r, string m) PagoLink(VMPagoEnlace itemPago, int ide)
        {
            (bool r, string m) result = (false, "");

            try
            {
                loggertxt.LogInformation("inicio de transaccion");

                // Registrar la transaccion
                // Registrar el estado
                // Request -> pasarela
                // Response <- pasarela

                //todo bien
                result = (false, "El pago se registró correctamente");

            }
            catch (Exception ex)
            {
                loggertxt.LogError(ex.InnerException.Message);
                result = (false, ex.Message);
            }
            finally
            {
                // close conexion ws
                // actualizar bd              
                loggertxt.LogInformation("fin de transaccion");
            }

            return result;
        }

        #endregion
    }
}