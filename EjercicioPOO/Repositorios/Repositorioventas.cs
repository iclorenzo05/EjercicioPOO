using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace EjercicioPOO.Repositorios
{
    internal class RepositorioVentas
    {
        // Datos para conectarnos a MySQL
        string conexionMySQL = "Server=localhost;Port=3307;Database=poo;User=root;Password=paola05;TreatTinyAsBoolean=false;";

        // REGISTRAR VENTA
        public void Registro(Venta venta, string codigoMatriculaCliente)
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
            {
                string consulta = "INSERT INTO ventas " +
                    "(Empleado, CodigoMatriculaEmpleado, Producto, Cantidad, Precio, CodigoMatriculaCliente, Total) " +
                    "VALUES " +
                    "(@Empleado, @CodigoMatriculaEmpleado, @Producto, @Cantidad, @Precio, @CodigoMatriculaCliente, @Total)";

                try
                {
                    conexion.Open();

                    foreach (VentaProducto ventaProducto in venta.Productos)
                    {
                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Empleado", venta.Empleado.Nombre);
                            comando.Parameters.AddWithValue("@CodigoMatriculaEmpleado", venta.Empleado.CodigoMatricula);
                            comando.Parameters.AddWithValue("@Producto", ventaProducto.Producto.Nombre);
                            comando.Parameters.AddWithValue("@Cantidad", ventaProducto.Cantidad);
                            comando.Parameters.AddWithValue("@Precio", ventaProducto.Producto.Precio);
                            comando.Parameters.AddWithValue("@CodigoMatriculaCliente", codigoMatriculaCliente);
                            comando.Parameters.AddWithValue("@Total", ventaProducto.Total);

                            comando.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine("Venta registrada correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al registrar venta: " + ex.Message);
                }
            }
        }


        // LISTAR VENTAS
        public List<Venta> Lista()
        {
            List<Venta> lista = new List<Venta>();

            using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
            {
                string consulta = "SELECT * FROM ventas";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    try
                    {
                        conexion.Open();

                        MySqlDataReader dr = comando.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Venta venta = new Venta();

                                venta.Productos = new List<VentaProducto>();

                                Empleado empleado = new Empleado();
                                empleado.Nombre = dr["Empleado"].ToString();
                                empleado.CodigoMatricula = dr["CodigoMatriculaEmpleado"].ToString();

                                venta.Empleado = empleado;

                                Producto producto = new Producto();
                                producto.Nombre = dr["Producto"].ToString();
                                producto.Precio = Convert.ToDouble(dr["Precio"]);

                                VentaProducto ventaProducto = new VentaProducto();

                                ventaProducto.Producto = producto;
                                ventaProducto.Cantidad = Convert.ToSingle(dr["Cantidad"]);
                                ventaProducto.Total = Convert.ToDecimal(dr["Total"]);

                                venta.Productos.Add(ventaProducto);

                                venta.Total = ventaProducto.Total;

                                lista.Add(venta);
                            }
                        }

                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al listar ventas: " + ex.Message);
                    }
                }
            }

            return lista;
        }


        // ELIMINAR VENTA
        public void Borrar(int id)
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
            {
                string consulta = "DELETE FROM ventas WHERE ID = @ID";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        conexion.Open();

                        int filas = comando.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            Console.WriteLine("Venta eliminada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró una venta con ese ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al eliminar venta: " + ex.Message);
                    }
                }
            }
        }
    }
}