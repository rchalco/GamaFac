using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Ventas
{
    public class DetalleGananciasDTO
    {
        public Nullable<int> Anio { get; set; }
        public Nullable<int> Mes { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.DateTime> FechaReal { get; set; }
        public Nullable<int> IdTransaccion { get; set; }
        public string Nombre { get; set; }
        public string AsignadoA { get; set; }
        public Nullable<decimal> Descuento { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<decimal> PrecioVenta { get; set; }
        public Nullable<decimal> TotalVenta { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
        public Nullable<decimal> TotalReal { get; set; }
        public Nullable<decimal> TotalGanancia { get; set; }
        public string TipoProducto { get; set; }
        public string Producto { get; set; }
        public string PersonaAtiende { get; set; }

    }
}
