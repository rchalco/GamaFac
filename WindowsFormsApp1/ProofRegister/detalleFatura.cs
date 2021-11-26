using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ProofRegister
{
    [Serializable]
    public class detalleFactura
    {

        /// <summary>
        /// Actividad económica registrada en el Padrón Nacional de Contribuyentes relacionada al NIT.
        /// SI
        /// </summary>
        public virtual string actividadEconomica
        {
            get;
            set;
        }

        /// <summary>
        /// Homologado a los códigos de productos genéricos enviados por el SIN a través del servicio de sincronización.
        /// SI
        /// </summary>
        public virtual long codigoProductoSin
        {
            get;
            set;
        }

        /// <summary>
        /// Código que otorga el contribuyente a su servicio o producto.
        /// SI
        /// </summary>
        public virtual string codigoProducto
        {
            get;
            set;
        }

        /// <summary>
        /// Descripción que otorga el contribuyente a su servicio o producto
        /// SI
        /// </summary>
        public virtual string descripcion
        {
            get;
            set;
        }

        /// <summary>
        /// Cantidad del producto o servicio otorgado. En caso de servicio este valor debe ser 1.
        /// SI
        /// </summary>
        public virtual long cantidad
        {
            get;
            set;
        }

        /// <summary>
        /// Valor de la paramétrica que identifica la unidad de medida.
        /// SI
        /// </summary>
        public virtual long unidadMedida
        {
            get;
            set;
        }

        /// <summary>
        /// Precio que otorga el contribuyente a su servicio o producto.
        /// SI
        /// </summary>
        public virtual decimal precioUnitario
        {
            get;
            set;
        }

        /// <summary>
        /// Monto de descuento sobre el producto o servicio específico,  Si no aplica deberá ser nulo
        /// NO
        /// </summary>
        public virtual decimal? montoDescuento
        {
            get;
            set;
        }

        /// <summary>
        /// El subtotal es igual a la (cantidad * precio unitario) – descuento.
        /// SI
        /// </summary>
        public virtual decimal subTotal
        {
            get;
            set;
        }


    }
}

