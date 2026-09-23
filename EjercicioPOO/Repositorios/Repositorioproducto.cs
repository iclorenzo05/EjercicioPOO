using EjercicioPOO.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

    namespace EjercicioPOO.Repositorios
    {
        internal class Repositorioproducto : Interpository<Producto>
        {
            // Conexión a MySQL
            string conexionMySQL = "Server=localhost;Port=3307;Database=poo;User=root;Password=paola005;TreatTinyAsBoolean=false;";

            // REGISTRAR PRODUCTO
            public void Registro(Producto producto)
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
                {
                    string consulta = "INSERT INTO productos (Nombre, Precio) VALUES (@Nombre, @Precio)";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        comando.Parameters.AddWithValue("@Precio", producto.Precio);

                        try
                        {
                            conexion.Open();
                            comando.ExecuteNonQuery();

                            Console.WriteLine("Producto registrado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al registrar producto: " + ex.Message);
                        }
                    }
                }
            }

            // ACTUALIZAR PRODUCTO
            public void Actualizar(Producto producto)
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
                {
                    string consulta = "UPDATE productos SET Nombre = @Nombre, Precio = @Precio WHERE ID = @ID";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID", producto.ID);
                        comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                        comando.Parameters.AddWithValue("@Precio", producto.Precio);

                        try
                        {
                            conexion.Open();
                            int filas = comando.ExecuteNonQuery();

                            if (filas > 0)
                                Console.WriteLine("Producto actualizado correctamente.");
                            else
                                Console.WriteLine("No se encontró un producto con ese ID.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al actualizar producto: " + ex.Message);
                        }
                    }
                }
            }

            // ELIMINAR PRODUCTO
            public void Borrar(Producto producto)
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
                {
                    string consulta = "DELETE FROM productos WHERE ID = @ID";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID", producto.ID);

                        try
                        {
                            conexion.Open();
                            int filas = comando.ExecuteNonQuery();

                            if (filas > 0)
                                Console.WriteLine("Producto eliminado correctamente.");
                            else
                                Console.WriteLine("No se encontró un producto con ese ID.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al eliminar producto: " + ex.Message);
                        }
                    }
                }
            }
        }
    }