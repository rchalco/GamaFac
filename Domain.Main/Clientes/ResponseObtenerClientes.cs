using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Clientes
{
    public class ResponseObtenerClientes
    {
        public string idclienteFac { get; set; }
        public string idTipoDocumento { get; set; }
        public string documento { get; set; }
        public string NombreCliente { get; set; }
        public string correoElectronico { get; set; }
        public string numCelular { get; set; }
    }
}
