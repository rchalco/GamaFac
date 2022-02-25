using System;
using System.Collections.Generic;

namespace Business.Main.DataMapping
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public int? IdPuntoAtencion { get; set; }
        public string NitEmisor { get; set; }
        public string RazonSocialEmisor { get; set; }
        public string Cuf { get; set; }
        public string Cufd { get; set; }
        public DateTime? FechaFactura { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string CodigoCliente { get; set; }
        public decimal? MontoTotal { get; set; }
        public string Cafc { get; set; }
        public string CabeceraJson { get; set; }
        public string DetalleJson { get; set; }

        public virtual PuntoAtencion IdPuntoAtencionNavigation { get; set; }
    }
}
