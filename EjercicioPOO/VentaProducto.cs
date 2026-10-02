using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioPOO
{
    internal class VentaProducto
    {
        public Producto Producto { get; set; }
        public float Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
    }
}