using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.General
{
    public class ClasificadorDTO
    {
        public int idClasificador { get; set; }
        public Nullable<int> idClasificadorTipo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<bool> Activo { get; set; }

        public string observaciones { get; set; }
        public byte[] picCategoria { get; set; }
        public string picCategoriaB64 { get; set; }
        
        

    }
}
