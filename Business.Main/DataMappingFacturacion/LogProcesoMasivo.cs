using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingFacturacion
{
    public partial class LogProcesoMasivo
    {
        public int IdLogProcesoMasivo { get; set; }
        public string FileName { get; set; }
        public string XmlrequestEnviado { get; set; }
        public string XmlresponseEnviado { get; set; }
        public string EstadoEnviado { get; set; }
        public string CodigoDescripcionEnviado { get; set; }
        public string CodigoRecepcionEnviado { get; set; }
        public string EstadoValidado { get; set; }
        public string CodigoDescripcionValidado { get; set; }
        public string CodigoRecepcionEnviadoValidado { get; set; }
        public string XmlrequestValidado { get; set; }
        public string XmlresponseValidado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string CodeBatch { get; set; }
        public long? IdEventoSignificativo { get; set; }

        public virtual EventoSignificativo IdEventoSignificativoNavigation { get; set; }
    }
}
