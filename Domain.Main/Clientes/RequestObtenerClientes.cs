using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Clientes
{
    public class RequestObtenerClientes
    {
        public long idEmpresa { get; set; }
        public long idSession { get; set; }
        public string documento { get; set; }
    }
}
