﻿using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TStock
    {
        public long IdStock { get; set; }
        public long IdSesion { get; set; }
        public long IdOperacionDiariaCaja { get; set; }
        public int IdMovimiento { get; set; }
        public long IdProducto { get; set; }
        public long Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int? UnidadePorCaja { get; set; }
        public decimal? PrecioCaja { get; set; }
        public bool? StockTerminado { get; set; }
        public DateTime? FechaDeVencimiento { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
