using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Entities.Modelos
{
   public class Regla
    {
        public int Id { get; set; }
        public int EntidadId { get; set; }
        public int? GrupoId { get; set; }
        public int? PaisId { get; set; }
        public int RedPagoId { get; set; }
        public int PasarelaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaReg { get; set; }
        //nav
        public Entidad Entidad{ get; set; }
        public Grupo Grupo { get; set; }
        public Pais Pais { get; set; }
        public RedPago RedPago { get; set; }
        public Pasarela Pasarela { get; set; }
        public Usuario Usuario { get; set; }
    }
}
