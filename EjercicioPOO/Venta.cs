using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioPOO
{
    internal class Venta
    {
        public int ID { get; set; }
        public string Empleado { get; set; }
        public string CodigoMatriculaEmpleado{ get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public string CodigoMatriculaCliente { get; set; }
        public double Total { get; set; }
    }

}
