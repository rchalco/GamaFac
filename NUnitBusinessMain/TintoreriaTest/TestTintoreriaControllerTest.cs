using BackgroundAPIRest.Controllers;
using Domain.Main.Tintoreria;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitBusinessMain.TintoreriaTest
{
    internal class TestTintoreriaControllerTest
    {
        [Test]
        public void TestObtienePedidosReporte()
        {

            TintoreriaController testTintoreria = new TintoreriaController();
            RequestObtienePedidosPorEntregar requestObtienePedidosPorEntregar
                = new RequestObtienePedidosPorEntregar();
            requestObtienePedidosPorEntregar.idSession = 1;
            requestObtienePedidosPorEntregar.idEmpresa = 1;
            requestObtienePedidosPorEntregar.idEstado = 0;
            requestObtienePedidosPorEntregar.FechaDesde = new DateTime(2022, 1, 1);
            requestObtienePedidosPorEntregar.FechaHasta = new DateTime(2022, 1, 1);
            var response = testTintoreria.ObtienePedidosReporte(requestObtienePedidosPorEntregar);
                 
            //TomaDecisionManager elaboracionAuditoriaManager = new TomaDecisionManager();
            //var response = elaboracionAuditoriaManager.DevuelveCorrelativoDocAuditoria(1,2021,3);
        }

    }
}
