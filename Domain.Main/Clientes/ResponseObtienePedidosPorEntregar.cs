using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Clientes
{
    public class ResponseObtienePedidosPorEntregar
    {
        public long idPedMaster { get; set; }
        public long Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string documento { get; set; }
        public string NombreCliente { get; set; }
        public string producto { get; set; }
        public string Estado { get; set; }
        public decimal montoApertura { get; set; }
        public decimal montoCierre { get; set; }
        public int formaPago { get; set; }
    }
}
