﻿using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TCaja
    {
        public long IdCaja { get; set; }
        public long IdEmpresa { get; set; }
        public long IdUsuario { get; set; }
        public int? IdTipoCaja { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
    }
}
