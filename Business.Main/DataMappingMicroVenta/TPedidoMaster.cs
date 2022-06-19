using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TPedidoMaster
    {
        public long IdPedMaster { get; set; }
        public long IdSesion { get; set; }
        public long IdEmpresa { get; set; }
        public long IdOperacionDiariaCaja { get; set; }
        public long? IdAmbiente { get; set; }
        public long? IdFactura { get; set; }
        public long? IdFacCliente { get; set; }
        public decimal? MontoEntrada { get; set; }
        public decimal? MontoSalida { get; set; }
        public decimal? MontoDescuento { get; set; }
        public int? IdFacTipoPago { get; set; }
        public int? IdEstado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string Observaciones { get; set; }
    }
}
