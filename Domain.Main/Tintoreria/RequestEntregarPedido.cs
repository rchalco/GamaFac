using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Tintoreria
{
    public class RequestEntregarPedido
    {
        public long idSesion { get; set; }
        public long idEmpresa { get; set; }
        public long idPedidoMaster { get; set; }
    }
}
