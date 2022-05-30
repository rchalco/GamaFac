using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingFacturacion
{
    public partial class Invoice
    {
        public int IdInvoice { get; set; }
        public string Invoice1 { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string State { get; set; }
        public string DetailProcess { get; set; }
        public string IdEvent { get; set; }
        public string CodeBatch { get; set; }
        public string FileNameCompress { get; set; }
        public string FolderContainer { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string ProcessObject { get; set; }
        public string InvoiceSign { get; set; }
        public string InvoiceNumber { get; set; }
        public int? IndexFile { get; set; }
        public long? IdOffice { get; set; }
        public long? IdCufd { get; set; }

        public virtual Cufd IdCufdNavigation { get; set; }
        public virtual Office IdOfficeNavigation { get; set; }
    }
}
