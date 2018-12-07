using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaPasarela.ViewModels
{
    public class VMPagoEnlace
    {
        public decimal Importe { get; set; }
        public string DivisaBase { get; set; }
        public string DivisaCobro { get; set; }
        public int IdEntidad { get; set; }
        public string Concepto { get; set; }
        public string Agente { get; set; }
        public string Idioma { get; set; }
        public DateTime? Caducidad { get; set; }
    }
}
