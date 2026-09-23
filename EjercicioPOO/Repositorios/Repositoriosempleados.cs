using EjercicioPOO.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioPOO.Repositorios
{
        internal class Repositoriosempleados : Interpository<Empleado>
        {
            // Datos para conectarnos a MySQL
            string conexionMySQL = "Server=localhost;Port=3307;Database=poo;User=root;Password=paola005;TreatTinyAsBoolean=false;";

            // REGISTRAR EMPLEADO
            public void Registro(Empleado empleado)
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
                {
                    string consulta = "INSERT INTO empleados (Nombre, Edad, Salario) VALUES (@Nombre, @Edad, @Salario)";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                        comando.Parameters.AddWithValue("@Edad", empleado.Edad);
                        comando.Parameters.AddWithValue("@Salario", empleado.Salario);

                        try
                        {
                            conexion.Open();
                            comando.ExecuteNonQuery();

                            Console.WriteLine("Empleado registrado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al registrar empleado: " + ex.Message);
                        }
                    }
                }
            }

            // ACTUALIZAR EMPLEADO
            public void Actualizar(Empleado empleado)
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
                {
                    string consulta = "UPDATE empleados SET Nombre = @Nombre, Edad = @Edad, Salario = @Salario WHERE ID = @ID";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID", empleado.ID);
                        comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                        comando.Parameters.AddWithValue("@Edad", empleado.Edad);
                        comando.Parameters.AddWithValue("@Salario", empleado.Salario);

                        try
                        {
                            conexion.Open();
                            int filas = comando.ExecuteNonQuery();

                            if (filas > 0)
                                Console.WriteLine("Empleado actualizado correctamente.");
                            else
                                Console.WriteLine("No se encontró un empleado con ese ID.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al actualizar empleado: " + ex.Message);
                        }
                    }
                }
            }

            // ELIMINAR EMPLEADO
            public void Borrar(Empleado empleado)
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
                {
                    string consulta = "DELETE FROM empleados WHERE ID = @ID";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID", empleado.ID);

                        try
                        {
                            conexion.Open();
                            int filas = comando.ExecuteNonQuery();

                            if (filas > 0)
                                Console.WriteLine("Empleado eliminado correctamente.");
                            else
                                Console.WriteLine("No se encontró un empleado con ese ID.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al eliminar empleado: " + ex.Message);
                        }
                    }
                }
            }
        }
    }