using System;
using System.Collections.Generic;

namespace Business.Main.DataMappingFacturacion
{
    public partial class Parameter
    {
        public int IdParameter { get; set; }
        public string KeyName { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string Group { get; set; }
        public bool Enabled { get; set; }
    }
}
