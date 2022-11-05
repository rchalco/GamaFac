using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Types
{
    public class typeDetailIngredientes
    {
        public Nullable<int> idProducto { get; set; }
        public Nullable<decimal> cantidad { get; set; }
        public Nullable<decimal> montoIndividual { get; set; }
    }
}
