using Business.Main.ManagersFacturacion;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitBusinessMain
{
    public class SINSingManagerTest
    {
        [Test]
        public void FirmarDocumentoXMLTest()
        {
            SINSingManager sINSingManager = new SINSingManager();
            string data = File.ReadAllText(@"d:\tmp\factura.xml");
            var resul = sINSingManager.FirmarDocumentoXML(data,
                @"D:\BckDell  15 5500\e\PROYECTOS\SIN-Firma\SINFirma\certificado SIN\procesado\private_dec_dc_myke.key",
                @"D:\BckDell  15 5500\e\PROYECTOS\SIN-Firma\SINFirma\certificado SIN\procesado\cert_SIN_myke_dc.key");
        }
    }
}
