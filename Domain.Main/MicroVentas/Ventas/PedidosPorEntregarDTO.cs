using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Ventas
{
    public class PedidosPorEntregarDTO
    {
        public long idPedMaster { get; set; }
        public string fecha { get; set; }
        public string nombreCliente { get; set; }
        public string pedido { get; set; }
    }
}
