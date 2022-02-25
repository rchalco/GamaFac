using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Cajas
{
    public class RequestCierreCaja
    {
        public int idCaja { get; set; }
        public decimal montoCierre { get; set; }
        public string observacion { get; set; }

    }
}
