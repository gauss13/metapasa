using Meta.Entities.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Entities.Extenciones
{
  public static class Extension
    {
        public static void Map(this Usuario itemdb, Usuario item )
        {
            itemdb.Correo = item.Correo;
          //  itemdb.Password = item.Password;// el cambio de password se hará desde un modulo especial
            itemdb.Descripcion = item.Descripcion;
            itemdb.RolId = item.RolId;
            itemdb.Activo = item.Activo;
            //itemdb.FechaReg = item.FechaReg;
            itemdb.UrlInvocacion = item.UrlInvocacion;
        }

        public static void Map(this Regla itemdb, Regla item)
        {
            itemdb.EntidadId = item.EntidadId;
            itemdb.GrupoId = item.GrupoId;
            itemdb.PaisId = item.PaisId;
            itemdb.RedPagoId = item.RedPagoId;
            itemdb.PasarelaId = item.PasarelaId;                        
            itemdb.DefaultEntidad = item.DefaultEntidad;

        }

        public static void Map(this Grupo itemdb, Grupo item)
        {
            itemdb.Nombre = item.Nombre;          
        }

    }
}
