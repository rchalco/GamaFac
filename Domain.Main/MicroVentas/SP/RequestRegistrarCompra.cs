using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.SP
{
    public class RequestRegistrarCompra
    {
        public int idUsuario { get; set; }
        public int idVentanilla { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public int precioUnitario { get; set; }
    }
}
