using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Tintoreria
{
    public class RequestObtieneArqueoCaja
    {

        public long idSession { get; set; }
        public long idEmpresa { get; set; }
        public long idCaja { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
    }
}
