using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Impresion
{
    public class DataDocumento
    {
        public string titulo { get; set; }
        public List<string> contenido { get; set; }
        public string pie { get; set; }
        public string pathLogo { get; set; }
    }
}
