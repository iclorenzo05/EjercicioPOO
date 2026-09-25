

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
        string conexionMySQL = "Server=localhost;Port=3307;Database=poo;User=root;Password=paola05;TreatTinyAsBoolean=false;";

        // REGISTRAR EMPLEADO
        public void Registro(Empleado empleado)
        {
            using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
            {
              string consulta = "INSERT INTO empleados (Nombre, Edad, Salario, CodigoMatricula) VALUES (@Nombre, @Edad, @Salario, @CodigoMatricula)";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    comando.Parameters.AddWithValue("@Edad", empleado.Edad);
                    comando.Parameters.AddWithValue("@Salario", empleado.Salario);
                    comando.Parameters.AddWithValue("@CodigoMatricula", empleado.CodigoMatricula);

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
                        {
                            Console.WriteLine("Empleado eliminado correctamente.");

                            // Revisar si ya no quedan empleados
                            string verificar = "SELECT COUNT(*) FROM empleados";

                            using (MySqlCommand comandoVerificar = new MySqlCommand(verificar, conexion))
                            {
                                int cantidad = Convert.ToInt32(comandoVerificar.ExecuteScalar());

                                // Si la tabla quedó vacía, reiniciar el ID
                                if (cantidad == 0)
                                {
                                    string reiniciar = "ALTER TABLE empleados AUTO_INCREMENT = 1";

                                    using (MySqlCommand comandoReiniciar = new MySqlCommand(reiniciar, conexion))
                                    {
                                        comandoReiniciar.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontró un empleado con ese ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al eliminar empleado: " + ex.Message);
                    }
                }
            }
        }

        // LISTAR EMPLEADOS
        public List<Empleado> Lista()
        {
            List<Empleado> lista = new List<Empleado>();

            using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
            {
                string consulta = "SELECT * FROM empleados";

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
                                Empleado empleado = new Empleado();

                                empleado.ID = Convert.ToInt32(dr["id"].ToString());
                                empleado.Nombre = dr["nombre"].ToString();
                                empleado.Edad = Convert.ToInt32(dr["Edad"].ToString());
                                empleado.Salario = Convert.ToInt32(dr["salario"].ToString());

                                lista.Add(empleado);
                            }
                        }

                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return lista;
        }

        // BUSCAR EMPLEADO
        public List<Empleado> Buscar(string nombre)
        {
            List<Empleado> lista = new List<Empleado>();

            using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
            {
                string consulta = "SELECT * FROM empleados WHERE nombre LIKE @nombre";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                    try
                    {
                        conexion.Open();

                        MySqlDataReader dr = comando.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Empleado empleado = new Empleado();

                                empleado.ID = Convert.ToInt32(dr["id"].ToString());
                                empleado.Nombre = dr["nombre"].ToString();
                                empleado.Edad = Convert.ToInt32(dr["Edad"].ToString());
                                empleado.Salario = Convert.ToDouble(dr["salario"].ToString());

                                lista.Add(empleado);
                            }
                        }

                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return lista;
        }

        // BUSCAR POR CÓDIGO DE MATRÍCULA
        public Empleado BuscarCodigoMatricula(string codigo)
        {
            Empleado empleado = null;

            using (MySqlConnection conexion = new MySqlConnection(conexionMySQL))
            {
                string consulta = "SELECT * FROM empleados WHERE CodigoMatricula = @CodigoMatricula";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@CodigoMatricula", codigo);

                    try
                    {
                        conexion.Open();

                        MySqlDataReader dr = comando.ExecuteReader();

                        if (dr.Read())
                        {
                            empleado = new Empleado();

                            empleado.ID = Convert.ToInt32(dr["ID"]);
                            empleado.Nombre = dr["Nombre"].ToString();
                            empleado.Edad = Convert.ToInt32(dr["Edad"]);
                            empleado.Salario = Convert.ToDouble(dr["Salario"]);
                            empleado.CodigoMatricula = dr["CodigoMatricula"].ToString();
                        }

                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al buscar código: " + ex.Message);
                    }
                }
            }

            return empleado;
        }
    }
}
            