using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.SP
{
    public class RequestRegistrarCompra
    {
        public int idSession { get; set; }
        public int idOperacionDiariaCaja { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public int precioUnitario { get; set; }
        public int unidadXCaja { get; set; }
        public int precioCaja { get; set; }
        public string tipoUnidad { get; set; }
    }
}
