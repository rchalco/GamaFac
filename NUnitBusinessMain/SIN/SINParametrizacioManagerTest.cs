using Business.Main.ManagersFacturacion;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitBusinessMain.SIN
{
    public class SINParametrizacioManagerTest
    {
        [Test]
        public void ConsutaPuntosVenta()
        {
            SINOficinaManager sINOficinaManager = new SINOficinaManager();
            var resul = sINOficinaManager.ConsutaPuntosVenta(Convert.ToInt32(4010898014));
        }

        [Test]
        public void SincronizarCodigoCUISGlobal()
        {
            SINParametrizacioManager sINParametrizacioManager = new SINParametrizacioManager();
            var resul = sINParametrizacioManager.SincronizarCodigoCUISGlobal();
        }
    }
}
