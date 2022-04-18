using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.SP
{
    public class ResulSPProductosCantidad
    {
        public int idProducto { get; set; }
        public int idPrecio { get; set; }
        public string Producto { get; set; }
        public string embase { get; set; }
        public string EnStock { get; set; }
        public string categoria { get; set; }
        public string nombreProducto { get; set; }
        public string marca { get; set; }
        public string contenido { get; set; }
        public decimal precio { get; set; }
        public decimal precioUnitario { get; set; }

        public byte[] picProducto { get; set; }
        public int CantidadCaja { get; set; }
    }
}
