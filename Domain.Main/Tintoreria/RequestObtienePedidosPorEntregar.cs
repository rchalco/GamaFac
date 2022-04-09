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
    }
}
