using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingMicroVenta
{
    public partial class TEstadoVentanilla
    {
        public long IdEstadoVentanilla { get; set; }
        public long? IdVentanilla { get; set; }
        public decimal MontoApertura { get; set; }
        public decimal? MontoCierre { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
    }
}
