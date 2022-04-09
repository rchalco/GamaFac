using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Tintoreria
{
    public class RequestSearchProduct
    {
        public long idSesion { get; set; }
        public long idEmpresa { get; set; }
        public string producto { get; set; }
    }
}
