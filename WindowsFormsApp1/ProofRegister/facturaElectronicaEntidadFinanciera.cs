using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ProofRegister
{
    [Serializable]
    public class facturaElectronicaEntidadFinanciera
    {

        public virtual cabeceraFactura cabecera
        {
            get;
            set;
        }
                      

        /// <summary>
        /// Coleccion de detalle
        /// </summary>
        public virtual detalleFactura detalle
        {
            get;
            set;
        }

        
        
    }
}
