using Core;
using Core.clases;
using Core.Interfaces;
using Core.repositorio;
using Coree;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;

namespace Core.Repositorios
{
    public class RepositorioProductos : Interpository<Producto>
    {
        // Conexión a la base de datos MySQL.
        private string conexionMySQL =
        "Server=localhost;Port=3307;Database=poo;User=root;Password=paola05;TreatTinyAsBoolean=false;";


        // REGISTRAR PRODUCTO
        public void Registro(Producto producto)
        {
            using (MySqlConnection conexion =
                new MySqlConnection(conexionMySQL))
            {
                string consulta =
                    "INSERT INTO productos (Nombre, Precio, CodigoProducto) " +
                    "VALUES (@Nombre, @Precio, @CodigoProducto)";

                using (MySqlCommand comando =
                    new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@Nombre", producto.Nombre);

                    comando.Parameters.AddWithValue(
                        "@Precio", producto.Precio);

                    comando.Parameters.AddWithValue(
                        "@CodigoProducto",
                        string.IsNullOrWhiteSpace(producto.CodigoProducto)
                            ? (object)DBNull.Value
                            : producto.CodigoProducto);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();

                        Console.WriteLine(
                            "Producto registrado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        RegistrarError(ex);

                        Console.WriteLine(
                            "Error al registrar producto: " + ex.Message);
                    }
                }
            }
        }


        // ACTUALIZAR PRODUCTO
        public void Actualizar(Producto producto)
        {
            using (MySqlConnection conexion =
                new MySqlConnection(conexionMySQL))
            {
                string consulta =
                    "UPDATE productos " +
                    "SET Nombre = @Nombre, Precio = @Precio, " +
                    "CodigoProducto = @CodigoProducto " +
                    "WHERE ID = @ID";

                using (MySqlCommand comando =
                    new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@ID", producto.ID);

                    comando.Parameters.AddWithValue(
                        "@Nombre", producto.Nombre);

                    comando.Parameters.AddWithValue(
                        "@Precio", producto.Precio);

                    comando.Parameters.AddWithValue(
                        "@CodigoProducto",
                        string.IsNullOrWhiteSpace(producto.CodigoProducto)
                            ? (object)DBNull.Value
                            : producto.CodigoProducto);

                    try
                    {
                        conexion.Open();

                        int filas = comando.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            Console.WriteLine(
                                "Producto actualizado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine(
                                "No se encontró un producto con ese ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        RegistrarError(ex);

                        Console.WriteLine(
                            "Error al registrar producto: " + ex.Message);
                    }
                }
            }
        }


        // ELIMINAR PRODUCTO
        public void Borrar(Producto producto)
        {
            using (MySqlConnection conexion =
                new MySqlConnection(conexionMySQL))
            {
                string consulta =
                    "DELETE FROM productos WHERE ID = @ID";

                using (MySqlCommand comando =
                    new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@ID", producto.ID);

                    try
                    {
                        conexion.Open();

                        int filas = comando.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            Console.WriteLine(
                                "Producto eliminado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine(
                                "No se encontró un producto con ese ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        RegistrarError(ex);

                        Console.WriteLine(
                            "Error al registrar producto: " + ex.Message);
                    }
                }
            }
        }


        // LISTAR PRODUCTOS
        public List<Producto> Lista()
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection conexion =
                new MySqlConnection(conexionMySQL))
            {
                string consulta =
                    "SELECT ID, Nombre, Precio, CodigoProducto FROM productos";

                using (MySqlCommand comando =
                    new MySqlCommand(consulta, conexion))
                {
                    try
                    {
                        conexion.Open();

                        using (MySqlDataReader dr =
                            comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Producto producto = new Producto();

                                producto.ID =
                                    Convert.ToInt32(dr["ID"]);

                                producto.Nombre =
                                    dr["Nombre"].ToString();

                                producto.Precio =
                                    Convert.ToDouble(dr["Precio"]);

                                producto.CodigoProducto =
                                    dr["CodigoProducto"] == DBNull.Value
                                        ? null
                                       : dr["CodigoProducto"].ToString();

                                lista.Add(producto);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        RegistrarError(ex);

                        Console.WriteLine(
                            "Error al registrar producto: " + ex.Message);
                    }
                }
            }

            return lista;
        }


        // BUSCAR PRODUCTOS POR NOMBRE
        public List<Producto> Buscar(string nombre)
        {
            List<Producto> lista = new List<Producto>();

            using (MySqlConnection conexion =
                new MySqlConnection(conexionMySQL))
            {
                string consulta =
                    "SELECT ID, Nombre, Precio, CodigoProducto " +
                    "FROM productos WHERE Nombre LIKE @Nombre";

                using (MySqlCommand comando =
                    new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@Nombre", "%" + nombre + "%");

                    try
                    {
                        conexion.Open();

                        using (MySqlDataReader dr =
                            comando.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Producto producto = new Producto();

                                producto.ID =
                                    Convert.ToInt32(dr["ID"]);

                                producto.Nombre =
                                    dr["Nombre"].ToString();

                                producto.Precio =
                                    Convert.ToDouble(dr["Precio"]);

                                producto.CodigoProducto =
                                    dr["CodigoProducto"] == DBNull.Value
                                        ? null
                                        : dr["CodigoProducto"].ToString();

                                lista.Add(producto);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        RegistrarError(ex);

                        Console.WriteLine(
                            "Error al registrar producto: " + ex.Message);
                    }
                }
            }

            return lista;
        }


        // BUSCAR UN PRODUCTO POR SU ID
        public Producto BuscarPorId(int id)
        {
            Producto producto = null;

            using (MySqlConnection conexion =
                new MySqlConnection(conexionMySQL))
            {
                string consulta =
                    "SELECT ID, Nombre, Precio, CodigoProducto " +
                    "FROM productos WHERE ID = @ID";

                using (MySqlCommand comando =
                    new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@ID", id);

                    try
                    {
                        conexion.Open();

                        using (MySqlDataReader dr =
                            comando.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                producto = new Producto();

                                producto.ID =
                                    Convert.ToInt32(dr["ID"]);

                                producto.Nombre =
                                    dr["Nombre"].ToString();

                                producto.Precio =
                                    Convert.ToDouble(dr["Precio"]);

                                producto.CodigoProducto =
                                    dr["CodigoProducto"] == DBNull.Value
                                        ? null
                                        : dr["CodigoProducto"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        RegistrarError(ex);

                        Console.WriteLine(
                            "Error al registrar producto: " + ex.Message);
                    }
                }
            }

            return producto;
        }


        // BUSCAR UN PRODUCTO POR SU CÓDIGO DE BARRAS
        public Producto BuscarPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                return null;
            }

            Producto producto = null;

            using (MySqlConnection conexion =
                new MySqlConnection(conexionMySQL))
            {
                string consulta =
                    "SELECT ID, Nombre, Precio, CodigoProducto " +
                    "FROM productos WHERE CodigoProducto = @CodigoProducto";

                using (MySqlCommand comando =
                    new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue(
                        "@CodigoProducto", codigo.Trim());

                    try
                    {
                        conexion.Open();

                        using (MySqlDataReader dr =
                            comando.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                producto = new Producto();

                                producto.ID =
                                    Convert.ToInt32(dr["ID"]);

                                producto.Nombre =
                                    dr["Nombre"].ToString();

                                producto.Precio =
                                    Convert.ToDouble(dr["Precio"]);

                                producto.CodigoProducto =
                                    dr["CodigoProducto"] == DBNull.Value
                                        ? null
                                        : dr["CodigoProducto"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        RegistrarError(ex);

                        Console.WriteLine(
                            "Error al registrar producto: " + ex.Message);
                    }
                }
            }

            return producto;
        }

        // REGISTRAR ERRORES
        private void RegistrarError(Exception ex)
        {
            Log log = new Log();
            log.Fecha = DateTime.Now;
            log.ex = ex;
            log.empleado = new Empleado();
            log.tipo = 1;

            repositorioLog logs = new repositorioLog();
            logs.Registro(log);
        }
    }
}
