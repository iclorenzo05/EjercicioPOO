using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioPOO
{
    internal class Venta
    {
        public string CodigoVenta { get; set; }
        public List<VentaProducto> Productos { get; set; }
        public DateTime Fecha { get; set; }
        public Empleado Empleado { get; set; }
        public decimal Total { get; set; }
    }
}