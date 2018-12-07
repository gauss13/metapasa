﻿using Meta.Entities.Modelos;
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
            itemdb.FechaReg = item.FechaReg;
            itemdb.UrlInvocacion = item.UrlInvocacion;
        }

    }
}
