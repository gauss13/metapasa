using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaPasarela.ViewModels
{
    public class VMHistoricoDirecto
    {
        public string Token { get; set; }
        public string Fecha { get; set; }
        public string Solicitante { get; set; }
        public string Entidad { get; set; }
        public decimal Importe { get; set; }
        public string Divisa { get; set; }
        public string Red { get; set; }
        public string Pais { get; set; }
        public string Pasarela { get; set; }
        public string Estado { get; set; }

    }
}
