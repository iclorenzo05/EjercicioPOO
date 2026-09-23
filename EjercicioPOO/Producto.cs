using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioPOO
{
    internal class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public void MostrarInformacion()
        {
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Precio: $" + Precio);
        }
    }
}