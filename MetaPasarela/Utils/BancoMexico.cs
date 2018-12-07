using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WsBancoMexico;
namespace MetaPasarela.Utils
{
    public static class BancoMexico
    {
        public static async Task<decimal> GetTipoCambio()
        {
            string r = "";
            WsBancoMexico.DgieWSPortClient wsb = new WsBancoMexico.DgieWSPortClient();

            var strRespuesta = await wsb.tiposDeCambioBanxicoAsync();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(strRespuesta);


            XNamespace bm = "http://www.banxico.org.mx/structure/key_families/dgie/sie/series/compact";
            XElement XElement = XElement.Parse(strRespuesta);

            string foliobanco = "SF60653";
            r = XElement.Descendants(bm + "Series")
                              .Where(x => x.Attribute("IDSERIE").Value == foliobanco)
                              .Descendants(bm + "Obs")
                              .Select(x => x.Attribute("OBS_VALUE").Value)
                              .FirstOrDefault();

            decimal cambio = 0;

            decimal.TryParse(r, out cambio);

            return cambio;
        }
    }
}
