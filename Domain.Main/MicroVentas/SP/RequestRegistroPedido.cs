using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.SP
{
    public class RequestRegistroPedido
    {
        public List<typeDetailPedido> detallePedido { get; set; }
        public long idSesion { get; set; }
        public string idFacCliente { get; set; }
        public long idEmpresa { get; set; }
        public long idOperacionDiariaCaja { get; set; }
        public long idAmbiente { get; set; }
        public long idPedMaster { get; set; }
        public string Observaciones { get; set; }
        /// <summary>
        /// nuevossssss
        /// </summary>
        public string NombreFactura { get; set; }
        public long NITCliente { get; set; }
        public decimal Descuento { get; set; }
        public decimal MontoFactura { get; set; }

    }

    public class typeDetailPedido
    {
        public long? idProducto { get; set; }
        public long? cantidad { get; set; }
        public decimal? PrecioFinal { get; set; }
        /// <summary>
        /// nuevossssss
        /// </summary>
        public string NombreProducto { get; set; }
        public decimal Descuento { get; set; }
    }
}
