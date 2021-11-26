using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ProofRegister
{
    [Serializable]
    public class ParametrosCUF
    {
        /// <summary>
        ///  NIT del Contribuyente.(Emisor)
        /// </summary>
        public virtual long NIT
        {
            get;
            set;
        }

        /// <summary>
        /// Fecha y Hora del Emisor  yyyyMMddHHmmssSSS
        /// </summary>
        public virtual long FechaHora
        {
            get;
            set;
        }

        /// <summary>
        /// SUCURSAL (de donde se emite la factura)
        /// 0 = Casa Matriz
        /// 1 = Sucursal 1
        /// 2 = Sucursal 2
        /// N = Sucursal N
        /// </summary>
        public virtual long Sucursal
        {
            get;
            set;
        }
        /// <summary>
        /// 1 = Electrónica en Línea     
        /// 2 = Computarizada en Línea
        /// 3 = Portal Web en Línea
        /// </summary>
        public virtual long Modalidad
        {
            get;
            set;
        }

        /// <summary>
        /// 1 = Online
        /// 2 = Offline
        /// 3 = Masiva
        /// </summary>
        public virtual long TipoEmision
        {
            get;
            set;
        }
        /// <summary>
        /// TIPO FACTURA / DOCUMENTO AJUSTE
        ///1 = Factura con Derecho a Crédito Fiscal
        ///2 = Factura sin Derecho a Crédito Fiscal
        ///3 = Documento de Ajuste
        /// </summary>
        public virtual long TipoFactura
        {
            get;
            set;
        }

        /// <summary>
        /// 1 = Factura Compra Venta 2 = Recibo de Alquiler de Bienes Inmuebles //24 = Nota Crédito - Débito
        /// </summary>
        public virtual long TipoDocumentoSector
        {
            get;
            set;
        }


        /// <summary>
        /// NÚMERO DE FACTURA
        /// </summary>
        public virtual long NumeroFactura
        {
            get;
            set;
        }

        /// <summary>
        /// PUNTO DE VENTA (POS)
        /// Número de punto de venta
        /// 0 = No corresponde
        /// 1,2,3,4,….n
        /// </summary>
        public virtual long PuntoVenta
        {
            get;
            set;
        }

        /// <summary>
        /// Módulo 11
        /// </summary>
        public virtual long CodigoAutoverificador
        {
            get;
            set;
        }

    }
}
