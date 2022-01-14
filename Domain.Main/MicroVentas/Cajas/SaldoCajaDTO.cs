using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Cajas
{
    public class SaldoCajaDTO
    {
        public int IdCaja { get; set; }
        public string FechaCierre { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal SaldoCierre { get; set; }
        public decimal SaldoUsuario { get; set; }
        public decimal Diferencia { get; set; }
        public string Observacion { get; set; }
        public bool EsCajaActual { get; set; }
        public string EstadoCaja { get; set; }

    }
}
