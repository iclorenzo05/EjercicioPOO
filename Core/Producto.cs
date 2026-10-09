using System;

namespace Core.clases
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

    // Código de barras del producto.
    public string CodigoProducto { get; set; }

        public void MostrarInformacion()
        {
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Precio: $" + Precio);
            Console.WriteLine("Código de barras: " + CodigoProducto);
        }
    }

}
