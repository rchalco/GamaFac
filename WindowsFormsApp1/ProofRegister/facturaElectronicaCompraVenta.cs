using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ProofRegister
{
    [Serializable]
    public class facturaElectronicaCompraVenta
    {

        public virtual cabeceraFacturaCV cabecera
        {
            get;
            set;
        }
                      

        /// <summary>
        /// Coleccion de detalle
        /// </summary>
        public virtual detalleFacturaCV detalle
        {
            get;
            set;
        }

        
        
    }
}
