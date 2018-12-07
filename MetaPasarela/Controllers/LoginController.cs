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
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace MetaPasarela.Controllers
{
    //[Route("api/[controller]")]
    [Route("/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IRepositorioWrapper Repositorio;
        public readonly Serilog.ILogger loggerdb;
        private readonly ILogger<Usuario> loggertxt;

        public LoginController(IRepositorioWrapper rep, ILogger<Usuario> logger, Serilog.ILogger seriLog)
        {
            Repositorio = rep;
            this.loggertxt = logger;
            this.loggerdb = seriLog;
        }


        [HttpPost]
        public async Task<IActionResult> PostLogin(Usuario usuario)
        {
            try
            {
                //eliminar los espacion en blanco
                usuario.Correo = usuario.Correo.Trim();
                usuario.Password = usuario.Password.Trim();

                // Validar el nombre de usuario
                var itemdb = await this.Repositorio.Usuarios.FindAsyc(x => x.Correo == usuario.Correo);

                if (!itemdb.Any())
                {
                    this.loggertxt.LogWarning($"Correo no registrado {usuario.Correo}");
                    return Ok(new { ok = false, mensaje = $"No se encontró registro para el correo: {usuario.Correo}" });
                }

                if (itemdb.Count() > 1)
                {
                    this.loggertxt.LogWarning($"El correo {usuario.Correo} esta registrado {itemdb.Count()} veces");
                    return Ok(new { ok = false, mensaje = $"El correo {usuario.Correo} esta registrado {itemdb.Count()} veces" });
                }

                // Validar el password
                var usuariodb = itemdb.FirstOrDefault();

                // este activo
                if(usuariodb.Activo == false)
                {
                    this.loggertxt.LogWarning($"El correo {usuario.Correo} esta Bloqueado");
                    return Ok(new { ok = false, mensaje = $"El correo {usuario.Correo} esta Bloqueado" });
                }

                var valid = CryptoHelper.Crypto.VerifyHashedPassword(usuariodb.Password, usuario.Password);


                if (!valid)
                {
                    this.loggertxt.LogWarning($"password incorrecto. {usuario.Correo}");
                    return Ok(new { ok = false, mensaje = $"El password es incorrecto." });
                    // return Unauthorized();
                }
                else
                {
                    this.loggertxt.LogInformation($"Inicio de session {usuariodb.Correo}");

                    usuariodb.Password = ":)";
                    var token = GenerarToken(usuario);
                    var rol = await this.Repositorio.Roles.GetByIdAsync(usuariodb.RolId);
                    if (rol != null)
                        usuariodb.Rol = rol;

                    return Ok(new
                    {
                        ok = true,
                        usuario= usuariodb,
                        token,
                        id = usuario.Id,
                    });
                }
            }
            catch (Exception ex)
            {
                loggertxt.LogError(ex.InnerException.Message);
                return BadRequest(new { ok = false, mensaje = $"Se produjo un error en el sistema", errors = new { mensaje = ex.Message } });
            }

        }

        [HttpPut("{idu:int}")]
        public void Logout(Usuario usuario,int idu)
        {
            this.loggertxt.LogInformation($"Fin de sesión {usuario.Correo}");
        }

        public string GenerarToken(Usuario usuario)
        {
            var claveSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superCrete246754d(=?34ddsdBXsdg%$%FG&6HHfQWAccgt8678FGFASDF&%&56zx#$%GHCVBTYTRYFGGFHfgh&/ghtdgfd989dfgDFGdfg98dfgE5345dsf5sd6fsdf%$654fdgdfgd3681=(3459&#232342fsdf)=fadfgdfgdgwefrwR54WE#43d#$%@13"));
            var credencialFirma = new SigningCredentials(claveSecreta, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim(ClaimTypes.Role, usuario.RolId.ToString())
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: "*",
                audience: "*",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credencialFirma
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;

        }

    }
}