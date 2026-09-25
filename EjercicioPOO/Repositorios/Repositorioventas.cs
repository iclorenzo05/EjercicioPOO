using EjercicioPOO.Interfaces;
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
        public void Registro(Venta venta)
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
            {
                string consulta = "INSERT INTO ventas (Empleado, CodigoMatriculaEmpleado, Producto, Cantidad, Precio, CodigoMatriculaCliente, Total) VALUES (@Empleado, @CodigoMatriculaEmpleado, @Producto, @Cantidad, @Precio, @CodigoMatriculaCliente, @Total)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Empleado", venta.Empleado);
                    comando.Parameters.AddWithValue("@CodigoMatriculaEmpleado", venta.CodigoMatriculaEmpleado);
                    comando.Parameters.AddWithValue("@Producto", venta.Producto);
                    comando.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                    comando.Parameters.AddWithValue("@Precio", venta.Precio);
                    comando.Parameters.AddWithValue("@CodigoMatriculaCliente", venta.CodigoMatriculaCliente);
                    comando.Parameters.AddWithValue("@Total", venta.Total);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();

                        Console.WriteLine("Venta registrada correctamente.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al registrar venta: " + ex.Message);
                    }
                }
            }
        }


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

                                venta.ID = Convert.ToInt32(dr["ID"]);
                                venta.Empleado = dr["Empleado"].ToString();
                                venta.CodigoMatriculaEmpleado = dr["CodigoMatriculaEmpleado"].ToString();
                                venta.Producto = dr["Producto"].ToString();
                                venta.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                                venta.Precio = Convert.ToDouble(dr["Precio"]);
                                venta.CodigoMatriculaCliente = dr["CodigoMatriculaCliente"].ToString();
                                venta.Total = Convert.ToDouble(dr["Total"]);

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
    

    public void Borrar(Venta venta)
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
            {
                string consulta = "DELETE FROM ventas WHERE ID = @ID";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@ID", venta.ID);

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