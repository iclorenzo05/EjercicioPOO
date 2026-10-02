using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace EjercicioPOO
{
    internal class Venta
    {
        public Venta()
        {
            CodigoVenta = GeneraCodigoVenta();
            Fecha = DateTime.Now;
            Productos = new List<VentaProducto>();
        }

        private string GeneraCodigoVenta()
        {
            string codigo = DateTime.Now.ToString("yyyyMMdd");

            string consulta = "select count(*)+1 from ventas where DATE(fecha)=CURDATE()";

            MySqlConnection conn = new MySqlConnection(Utils.connStr);
            MySqlCommand comm = new MySqlCommand(consulta, conn);

            int consecutivo = 0;

            try
            {
                conn.Open();

                MySqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    consecutivo = Convert.ToInt32(dr[0]);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return codigo + consecutivo.ToString("D2");
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