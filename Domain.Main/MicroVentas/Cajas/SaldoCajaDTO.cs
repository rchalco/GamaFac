using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.Cajas
{
    public class SaldoCajaDTO
    {
        public long idCaja { get; set; }
        public string nombreCaja { get; set; }
        public string fechaCierre { get; set; }
        public decimal saldoInicial { get; set; }
        public decimal saldoCierre { get; set; }
        public decimal saldoUsuario { get; set; }
        public decimal diferencia { get; set; }
        public string observacion { get; set; }
        public bool esCajaActual { get; set; }
        public string estadoCaja { get; set; }
        public long idOperacionDiariaCaja { get; set; }
        public long idSesion { get; set; }
        public long idEmpresa { get; set; }
        public DateTime fechaApertura { get; set; }
        public string observacioApertura { get; set; }
        public string observacionCierre { get; set; }
        public decimal montoGastoDiario { get; set; }
        public string observacionGastos { get; set; }



    }
}
