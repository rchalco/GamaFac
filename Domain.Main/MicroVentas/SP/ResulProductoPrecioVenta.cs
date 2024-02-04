using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.MicroVentas.SP
{
    public class ResulProductoPrecioVenta
    {
        public int idSesion { get; set; }
        public int idProducto { get; set; }
        public int idPrecio { get; set; }
        public string producto { get; set; }
        public string embase { get; set; }
        public byte[] picProducto { get; set; }
        public string picProductoB64 { get; set; }
        public string marca { get; set; }
        public string contenido { get; set; }
        public decimal enStock { get; set; }
        //precio de venta
        public decimal precio { get; set; }
        public decimal precioUnitario { get; set; }
        public int cantidadCaja { get; set; }
        public int cantidad { get; set; }
        public int cantidadVendida { get; set; }
        public string nombreProducto { get; set; }
        public int idcCategoria { get; set; }
        public string categoria { get; set; }
        public string nivelStock { get; set; }
        //public bool visible { get; set; }
        public string picCategoria { get; set; }
        public string contenidoCategoria { get; set; }
        public bool activo { get; set; }
        public bool esParaMenu { get; set; }
        public byte[] picProductoCombo { get; set; }
        public string picProductoComboB64 { get; set; }
        public List<ResulProductoPrecioVenta> detalleProductos { get; set; }

    }

    public class ResulProductoPrecioVentaComplex
    {
        public int idCategoria { get; set; }
        public string categoria { get; set; }
        public byte[] picProducto { get; set; }
        public string descProducto { get; set; }
        public decimal precioUnitario { get; set; }
        public string etiquetaDerecha { get; set; }
        public string etiquetaIzquierda { get; set; }
        public int slide { get; set; }
        public bool activo { get; set; }
        public bool esParaMenu { get; set; }

        public List<ResulProductoPrecioVenta> detalle { get; set; }
    }

    

}
