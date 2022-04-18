using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Clientes
{
    public class RequestRegistrarClientreFactura
    {
        public long idSesion { get; set; }
        public long idEmpresa { get; set; }
        public long idTipoDocumento { get; set; }
        public string documento { get; set; }
        public string NombreCliente { get; set; }
        public string correoElectronico { get; set; }
        public string numCelular { get; set; }
    }
}
