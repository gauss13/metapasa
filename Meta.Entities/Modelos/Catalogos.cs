using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.Entities.Modelos
{
    public class Rol
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }        
    }

    public class Usuario
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Correo { get; set; }
        public string Password { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        public int RolId { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(250)]
        public string UrlInvocacion { get; set; }// para los tipo de rol pasarela
        public Rol Rol { get; set; }//nav
    }

    public class Grupo
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; } 
        public List<Pais> Paises { get; set; }//nav
        public List<Regla> Reglas { get; set; } // nav

    }


    public class Pais
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }
        [StringLength(2)]
        public string Codigo { get; set; }     
        public List<Regla> Reglas { get; set; } // nav

    }

    public class Entidad
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }
        [StringLength(3)]
        public string Codigo { get; set; }
        public int LocalizacionId { get; set; }
        public Localizacion Localizacion { get; set; }//nav
        public List<Regla> Reglas { get; set; }//nav
    }

    public class Localizacion
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }
    }

    public class Afiliacion
    {
        public int Id { get; set; }
        public int EntidadId { get; set; }
        public int PasarelaId { get; set; }
        [StringLength(20)]
        public string NumAfiliacion { get; set; }
        [StringLength(3)]
        public string Divisa { get; set; }
        public bool Activo { get; set; }
        public bool Principal { get; set; }
        public Entidad Entidad { get; set; }
        public Pasarela Pasarela { get; set; }
    }

    public class Pasarela
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }
        [StringLength(250)]
        public string Url { get; set; }

        public List<Regla> Reglas { get; set; }
    }

    public class RedPago
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Nombre { get; set; }
        [StringLength(3)]
        public string  Codigo { get; set; }

        public List<Regla> Reglas { get; set; }
    }

 

    // INTERMEDIOS

   public class UsuarioEntidad
    {
        public int UsuarioId { get; set; }
        public int EntidadId { get; set; }
    }

  public  class GrupoPais
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public int PaisId { get; set; }
    }
}
