using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaPasarela.ViewModels
{
    public class VMHistoricoEnlace
    {
        public string Token { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaExpiracion { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public string Divisa { get; set; }
        public string Solicitante { get; set; }
        public string Estado { get; set; }
        public string UltimaTransaccion { get; set; }
    }
}
