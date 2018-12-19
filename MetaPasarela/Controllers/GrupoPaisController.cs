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
using MetaPasarela.ViewModels;

namespace MetaPasarela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoPaisController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger loggerdb;
        private readonly ILogger<Transaccion> loggertxt;

        public GrupoPaisController(IRepositorioWrapper rep, ILogger<Transaccion> logger, Serilog.ILogger seriLog)
        {
            Repositorio = rep;
            this.loggertxt = logger;
            this.loggerdb = seriLog;
        }


        [HttpGet("{idg:int}")]
        public async Task<IActionResult> GetAll(int idg)
        {
            var paisesDelGrupo = await this.Repositorio.GrupoPaises.GetGrupoConPais(idg);

            var listaPaises = await this.Repositorio.Paises.GetAllAsyc();

            if (!listaPaises.Any())
            {
                return Ok(new { ok = false, mensaje = "No se encontró registros de Países en el grupo" });
            }

            List<VMPaisesGrupo> lista = new List<VMPaisesGrupo>();

            foreach (var pais in listaPaises)
            {
                VMPaisesGrupo item = new VMPaisesGrupo();
                item.Id = 0;
                item.IdPais = pais.Id;
                item.Nombre = pais.Nombre;
                item.Codigo = pais.Codigo;

                var en = paisesDelGrupo.FirstOrDefault(x => x.PaisId == pais.Id);

                if (en != null)
                {
                    item.Id = en.Id;
                    item.DelGrupo = true;
                }

                lista.Add(item);

            }
            lista = lista.OrderBy(x => x.Nombre).ThenBy(x => x.DelGrupo).ToList();

            var listaNi = lista.Where(x => x.DelGrupo == false).ToList();
            var listaIn = lista.Where(x => x.DelGrupo == true).ToList();

            return Ok(new { ok = true, total = lista.Count(), paises = listaNi, incluidos=listaIn });
        }

        // GRUPO PAIS
        [HttpPost]
        public async Task<IActionResult> Agregar(GrupoPais item)
        {
            try
            {
                var r = await this.Repositorio.GrupoPaises.AddAsync(item);
                await this.Repositorio.CompleteAsync();

                if (r == null)
                    return Ok(new { ok = false, mensaje = "No se pudo agregar el registro", pais = r });

                return Ok(new { ok = true, mensaje = "Se agregó el pais, correctamente", pais = r });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = "Se produjo un error al agregar el pais",
                    errors = new { mensaje = ex.Message }
                });

            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Quitar(int id)
        {
            try
            {

                var itemdb = await this.Repositorio.GrupoPaises.GetByIdAsync(id);

                if (itemdb == null)
                {
                    return Ok(new { ok = false, mensaje = "No se encontró el registro a quitar" });
                }

                this.Repositorio.GrupoPaises.Remove(itemdb);
                await this.Repositorio.CompleteAsync();

                return Ok(new { ok = true, mensaje = "Se quitó el pais, correctamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ok = false,
                    mensaje = "Se produjo un error al agregar el pais",
                    errors = new { mensaje = ex.Message }
                });

            }
        }


    }
}