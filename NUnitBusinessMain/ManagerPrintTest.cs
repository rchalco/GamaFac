using Business.Main.Managers;
using Domain.Main.MicroVentas.Impresion;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitBusinessMain
{
    public class ManagerPrintTest
    {
        [Test]
        public void DevuelveCorrelativoDocAuditoria()
        {
            MangerPrinter mangerPrinter = new MangerPrinter();
            DataDocumento dataDocumento = new DataDocumento();
            dataDocumento.titulo = "Mi Titulo";
            dataDocumento.contenido = new List<string>();
            dataDocumento.contenido.Add("Concepto 1 ..... 5");
            dataDocumento.contenido.Add("Concepto 1 ..... 6");
            dataDocumento.contenido.Add("Concepto 1 ..... 6");
            dataDocumento.contenido.Add("Concepto 1 ..... 8");
            dataDocumento.pie = "Ley Nro 453: Esta prohibido distribuir o comercializar productos expirados o prontos a expirar. Este Documento es la representacion grafica de un Documento Fisca Digital.....";
            var resul = mangerPrinter.GenerarDocumento(dataDocumento);
        }
    }
}
