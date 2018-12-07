using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoHelper;
using Meta.Entities.Extenciones;
using Meta.Entities.Modelos;
using Meta.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetaPasarela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger loggerdb;
        private readonly ILogger<Usuario> loggertxt;
        public UsuarioController(IRepositorioWrapper rep, ILogger<Usuario> logger, Serilog.ILogger seriLog)
        {
            this.loggertxt = logger;
            this.loggerdb = seriLog;
            Repositorio = rep;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var item = await this.Repositorio.Usuarios.GetByIdAsync(id);           

                if (item == null)
                {                

                    return Ok(new
                    {
                        ok = false,
                        mensaje = $"No se encontró la Usuario con id {id}",
                        errors = ""
                    });
                }

                item.Password = ":)";

                return Ok(new
                { 
                    ok = true,
                    usuario = item
                });

            }
            catch (Exception ex)
            {               
                return BadRequest(new
                {
                    ok = false,
                    mensaje = $"Se produjo un error al buscar el usuario con id {id}",
                    errors = ex.Message
                });

            }          
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var r = await Utils.BancoMexico.GetTipoCambio();

            var lista = await this.Repositorio.Usuarios.GetAllAsyc();    
          
            foreach (var item in lista)
            {
                item.Password = ":)";
            }

            // BAD REQUEST
            if (!lista.Any())
            {
                var objB = new
                {
                    ok = false,
                    mensaje = "No se encontrarón Usuarios"                    
                };
                return Ok(objB);
            }

            // OK
            var obj = new
            {
                ok = true,
                total = lista.Count(),
                usuarios = lista
            };

            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Usuario item)
        {
            try
            {              

                item.FechaReg = DateTime.Now; //asignamos la fecha del servidor 

                var hashPass = Crypto.HashPassword(item.Password);
                item.Password = hashPass;

                // Registra el usuario en la BD
                var r = await this.Repositorio.Usuarios.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                r.Password = ":)";

                var obj = new
                {
                    ok = true,
                    usuario = r
                };

                //retornamos el usuario creado con su id identity
                return Created("", obj);

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

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar([FromBody] Usuario itemEdit, int id)
        {
            // No se hara cambio de password desde la edicion, sino que tendrá su propio modulo de cambio de pass
            try
            {
                itemEdit.Id = id;

                //buscar la Usuario 
                var itemEncontrado = await this.Repositorio.Usuarios.GetByIdAsync(id);

                if (itemEncontrado == null)
                {
                    return Ok(new { ok = false, mensaje = "No se encontró la Usuario", erros = "" });
                }

                //Validar el correo
                //Validar que el correo no exista en la BD con otro usuario
                var encontrado = await this.Repositorio.Usuarios.FindAsyc(x => x.Correo == itemEdit.Correo && x.Id != id);

                if (encontrado.Any())
                {
                    return Ok(new
                    {
                        ok = false,
                        mensaje = $"El correo {itemEdit.Correo} ya esta registrado"
                    });
                }

                itemEncontrado.Map(itemEdit);              

                var r = this.Repositorio.Usuarios.Update(itemEncontrado);
                await this.Repositorio.CompleteAsync();

                r.Password = ":)";

                var obj = new
                {
                    ok = true,
                    usuario = r
                };

                return Created("", obj);


            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = "Se produjo un error al Actualizar los datos de la Usuario",
                    errors = new { mensaje = ex.Message }

                });

            }

        }


      

    }
}