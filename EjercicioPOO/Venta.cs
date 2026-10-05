using System;
using System.Collections.Generic;
using System.Text;
using EjercicioPOO.Repositorios;
using MySql.Data.MySqlClient;

namespace EjercicioPOO
{
    internal class Venta
    {
        public Venta(Empleado usuario)
        {
            CodigoVenta = GeneraCodigoVenta();
            Fecha = DateTime.Now;
            Empleado = usuario;
            Productos = new List<VentaProducto>();
        }

        private string GeneraCodigoVenta()
        {
            RepositorioVentas repoVentas = new RepositorioVentas();

            return DateTime.Now.ToString("yyyyMMdd") +
                   repoVentas.NextSale().ToString("000");
        }

        public int ID { get; set; }
        public string CodigoVenta { get; set; }
        public List<VentaProducto> Productos { get; set; }
        public DateTime Fecha { get; set; }
        public Empleado Empleado { get; set; }
        public decimal Total { get; set; }

        public void AgregarProducto(Producto producto, float cantidad)
        {
            decimal totalProducto =
                (decimal)producto.Precio * (decimal)cantidad;

            VentaProducto productoVendido = new VentaProducto();

            productoVendido.Producto = producto;
            productoVendido.Precio = (decimal)producto.Precio;
            productoVendido.Cantidad = cantidad;
            productoVendido.Total = totalProducto;

            Productos.Add(productoVendido);

            Total += totalProducto;
        }
    }
}