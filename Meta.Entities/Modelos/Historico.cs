using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Meta.Entities.Modelos
{
  public  class Transaccion
    {
        public int Id { get; set; }
        public int EntidadId { get; set; }
        public int TipoInvocacion { get; set; } //1 directo - 2 url
        [StringLength(50)]
        public string Token { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        [StringLength(100)]
        public string  Concepto { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Importe { get; set; }
        [StringLength(3)]
        public string DivisaBase { get; set; }
        [StringLength(3)]
        public string DivisaCobro { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Ratio { get; set; }// tipo de cambio- se obtiene del web service del Banco de mexico
        [StringLength(50)]
        public string Agente { get; set; }
     
        [StringLength(20)]
        public string Idioma { get; set; } // ? español - codigo de idioma - es necesario tener un catalogo de idiomas
        [StringLength(20)]
        public string Referencia { get; set; }//Confirmacion de reserva de pago
        public bool Cancelado { get; set; } // ? - se quita o se se deja
        public bool Finalizado { get; set; }// el proceso concluyo - no hay intentos
        public bool Confirmado_Pms { get; set; }// descargas
        public int PasarelaId { get; set; }
        public int RedPagoId { get; set; }
        public int PaisId { get; set; }
        [StringLength(20)]
        public string ID_TPV { get; set; } //
        [StringLength(10)]
        public string Estado { get; set; }// contendrá el estado actual el ultimo registra en la tabla EstadoTransaccion
        public DateTime FechaReg { get; set; }
        public int UsuarioId { get; set; }
       
      
        public Usuario Usuario { get; set; } // nav
        public Pasarela Pasarela { get; set; } // nav
        public RedPago RedPago { get; set; } // nav
        public Entidad Entidad { get; set; } // nav

    }

  public  class TransaccionEstado
    {
        public int Id { get; set; }
        public int TransaccionId { get; set; }
        [StringLength(10)]
        public string Estado { get; set; }
        [StringLength(150)]
        public string RespuestaPasarela { get; set; }
        public DateTime FechaReg { get; set; }
    }

}
