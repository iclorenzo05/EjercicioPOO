using System;

namespace Core.clases
{
    public class VentaProducto
    {
        public Producto Producto { get; set; }
        public float Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
    }
}