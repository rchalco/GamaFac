using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Tintoreria
{
    public class RequestObtienePedidosPorEntregar
    {
        public long idSession { get; set; }
        public long idEmpresa { get; set; }
        /// <summary>
        /// 0 all, 1 pedidos pendientes, 2 entregados, 3 facturados
        /// </summary>
        public int idEstado { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

    }
}
