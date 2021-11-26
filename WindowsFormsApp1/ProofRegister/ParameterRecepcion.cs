using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ProofRegister
{
    [Serializable]

    public class ParameterRecepcion
    {
        /// <summary>
        ///  Describe el tipo de ambiente utilizado, los valores permitidos son:
        ///        Producción: 1
        ///     Pruebas y Piloto: 2
        ///     
        /// SI
        /// 
        /// </summary>
        public virtual long codigoAmbiente
        {
            get;
            set;
        }

        /// <summary>
        ///  Solo se envía cuando la transacción se realiza utilizando un punto de venta.Caso contrario enviar 0.
        /// SI
        /// </summary>
        public virtual long codigoPuntoVenta
        {
            get;
            set;
        }
        /// <summary>
        /// Código de Sistema que le fue asignado al momento de realizar la solicitud de autorización.
        /// 
        ///
        /// SI
        /// </summary>
        public virtual string codigoSistema
        {
            get;
            set;
        }
        /// <summary>
        /// Valor que identifica a la sucursal donde se realiza la emisión de la Factura:
        /// Casa Matriz: 0
        ///    Sucursal: 1,2,..,n
        /// SI
        /// </summary>
        public virtual long codigoSucursal
        {
            get;
            set;
        }

        /// <summary>
        /// NIT perteneciente al emisor de la Factura.
        /// SI
        /// </summary>
        public virtual long nit
        {
            get;
            set;
        }

        /// <summary>
        /// Código que identifica el sector de la Factura.
        /// SI
        /// </summary>
        public virtual long codigoDocumentoSector
        {
            get;
            set;
        }

        /// <summary>
        /// Describe si la emisión se realizó en línea. El valor permitido es:
        ///  Online: 1
        ///
        /// SI
        /// </summary>
        public virtual long codigoEmision
        {
            get;
            set;
        }

        /// <summary>
        /// Electrónica en línea: 1
        /// SI
        /// </summary>
        public virtual long codigoModalidad
        {
            get;
            set;
        }

        /// <summary>
        /// Valor diario otorgado por el SIN
        /// SI
        /// </summary>
        public virtual string cufd
        {
            get;
            set;
        }

        /// <summary>
        /// Valor único para una sucursal y/o punto de venta que se obtiene al realizar el inicio de uso de sistemas
        /// SI
        /// </summary>
        public virtual string cuis
        {
            get;
            set;
        }

        /// <summary>
        /// Código que identifica el Tipo de Factura que se está enviando
        ///SI
        /// </summary>
        public virtual long tipoFacturaDocumento
        {
            get;
            set;
        }

        /// <summary>
        /// Fecha y hora en la cual se envía la Factura.
        /// SI
        /// </summary>
        public virtual TimeSpan fechaEnvio
        {
            get;
            set;
        }

        /// <summary>
        /// Sha256 de la cadena Archivo que se envía.
        /// </summary>
        public virtual string hashArchivo
        {
            get;
            set;
        }
    }
}
