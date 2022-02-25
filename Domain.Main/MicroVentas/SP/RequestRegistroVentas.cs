using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.SP
{

    public class RequestRegistroVenta
    {
        public List<DetalleVenta> detalleVentas { get; set; }
        public long idSesion { get; set; }
        public long idOperacionDiariaCaja { get; set; }
    }

    public class DetalleVenta
    {
        public long idProducto { get; set; }
        public long cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public long UnidadePorCaja { get; set; }
        public decimal precioCaja { get; set; }
    }
}
