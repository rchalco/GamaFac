using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Ventas
{
    public  class TransaccionVentasDetalleDTO
    {
        public TransaccionVentasDetalleDTO()
        {
            descuento = 0;
        }
        public int idParamPrecio { get; set; }
        public int idPedMaster { get; set; }
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public Nullable<int> cantidad { get; set; }
        public Nullable<decimal> cantidadDisponible { get; set; }
        public Nullable<decimal> precioVenta { get; set; }
        public Nullable<decimal> precioUnitario { get; set; }
        public Nullable<decimal> descuento { get; set; }
        public string observacion { get; set; }
        public Nullable<int> nroPedido { get; set; }
        public string mesero { get; set; }
        public Nullable<decimal> total { get; set; }

       
    }
}
