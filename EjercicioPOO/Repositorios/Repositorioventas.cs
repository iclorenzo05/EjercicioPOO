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
                try
                {
                    conexion.Open();

                    // 1. Guardar la información general de la venta
                    string consultaVenta = "INSERT INTO ventas " +
                        "(empleado, fecha, total, CodigoVenta) " +
                        "VALUES (@empleado, @fecha, @total, @CodigoVenta)";

                    using (MySqlCommand comandoVenta =
                        new MySqlCommand(consultaVenta, conexion))
                    {
                        comandoVenta.Parameters.AddWithValue(
                            "@empleado",
                            venta.Empleado.ID
                        );

                        comandoVenta.Parameters.AddWithValue(
                            "@fecha",
                            venta.Fecha
                        );

                        comandoVenta.Parameters.AddWithValue(
                            "@total",
                            venta.Total
                        );

                        comandoVenta.Parameters.AddWithValue(
                            "@CodigoVenta",
                            venta.CodigoVenta
                        );

                        comandoVenta.ExecuteNonQuery();
                    }

                    // 2. Obtener el ID que MySQL asignó a la venta
                    venta.ID = Convert.ToInt32(
                        new MySqlCommand(
                            "SELECT LAST_INSERT_ID()",
                            conexion
                        ).ExecuteScalar()
                    );

                    // 3. Guardar los productos relacionados con la venta
                    string consultaProducto = "INSERT INTO data_productos " +
                        "(CodigoVenta, ID_producto, precio, cantidad, total) " +
                        "VALUES (@CodigoVenta, @ID_producto, @precio, @cantidad, @total)";

                    foreach (VentaProducto ventaProducto in venta.Productos)
                    {
                        using (MySqlCommand comandoProducto =
                            new MySqlCommand(consultaProducto, conexion))
                        {
                            comandoProducto.Parameters.AddWithValue(
                                "@CodigoVenta",
                                venta.CodigoVenta
                            );

                            comandoProducto.Parameters.AddWithValue(
                                "@ID_producto",
                                ventaProducto.Producto.ID
                            );

                            comandoProducto.Parameters.AddWithValue(
                                "@precio",
                                ventaProducto.Precio
                            );

                            comandoProducto.Parameters.AddWithValue(
                                "@cantidad",
                                ventaProducto.Cantidad
                            );

                            comandoProducto.Parameters.AddWithValue(
                                "@total",
                                ventaProducto.Total
                            );

                            comandoProducto.ExecuteNonQuery();
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

            using (MySqlConnection conexion =
                new MySqlConnection(conexionMySQL))
            {
                string consulta =
                    "SELECT " +
                    "v.ID AS VentaID, " +
                    "v.CodigoVenta, " +
                    "v.empleado, " +
                    "v.fecha, " +
                    "v.total AS TotalVenta, " +
                    "dp.ID_producto, " +
                    "dp.precio, " +
                    "dp.cantidad, " +
                    "dp.total AS TotalProducto, " +
                    "p.Nombre AS NombreProducto " +
                    "FROM ventas v " +
                    "INNER JOIN data_productos dp " +
                    "ON v.CodigoVenta = dp.CodigoVenta " +
                    "INNER JOIN productos p " +
                    "ON dp.ID_producto = p.ID " +
                    "ORDER BY v.ID DESC";

                using (MySqlCommand comando =
                    new MySqlCommand(consulta, conexion))
                {
                    try
                    {
                        conexion.Open();

                        MySqlDataReader dr = comando.ExecuteReader();

                        while (dr.Read())
                        {
                            int idVenta =
                                Convert.ToInt32(dr["VentaID"]);

                            // Buscar si la venta ya existe en la lista
                            Venta venta =
                                lista.Find(v => v.ID == idVenta);

                            // Si no existe, crearla
                            if (venta == null)
                            {
                                venta = new Venta();

                                venta.ID = idVenta;

                                venta.CodigoVenta =
                                    dr["CodigoVenta"].ToString();

                                venta.Fecha =
                                    Convert.ToDateTime(dr["fecha"]);

                                venta.Total =
                                    Convert.ToDecimal(dr["TotalVenta"]);

                                venta.Productos =
                                    new List<VentaProducto>();

                                Empleado empleado = new Empleado();

                                empleado.ID =
                                    Convert.ToInt32(dr["empleado"]);

                                venta.Empleado = empleado;

                                lista.Add(venta);
                            }

                            // Crear el producto de esta venta
                            Producto producto = new Producto();

                            producto.ID =
                                Convert.ToInt32(dr["ID_producto"]);

                            producto.Nombre =
                                dr["NombreProducto"].ToString();

                            producto.Precio =
                                Convert.ToDouble(dr["precio"]);

                            // Crear el detalle del producto vendido
                            VentaProducto ventaProducto =
                                new VentaProducto();

                            ventaProducto.Producto = producto;

                            ventaProducto.Precio =
                                Convert.ToDecimal(dr["precio"]);

                            ventaProducto.Cantidad =
                                Convert.ToSingle(dr["cantidad"]);

                            ventaProducto.Total =
                                Convert.ToDecimal(dr["TotalProducto"]);

                            // Agregar el producto a la venta
                            venta.Productos.Add(ventaProducto);
                        }

                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(
                            "Error al listar ventas: " + ex.Message
                        );
                    }
                }
            }

            return lista;
        }


        // ELIMINAR VENTA
        public void Borrar(int id)
        {
            using (MySqlConnection conexion =
                new MySqlConnection(conexionMySQL))
            {
                try
                {
                    conexion.Open();

                    // Primero obtenemos el CodigoVenta de la venta
                    string consultaCodigo =
                        "SELECT CodigoVenta FROM ventas WHERE ID = @ID";

                    string codigoVenta = null;

                    using (MySqlCommand comandoCodigo =
                        new MySqlCommand(consultaCodigo, conexion))
                    {
                        comandoCodigo.Parameters.AddWithValue(
                            "@ID",
                            id
                        );

                        object resultado =
                            comandoCodigo.ExecuteScalar();

                        if (resultado != null)
                        {
                            codigoVenta = resultado.ToString();
                        }
                    }

                    if (codigoVenta == null)
                    {
                        Console.WriteLine(
                            "No se encontró una venta con ese ID."
                        );

                        return;
                    }

                    // Eliminar primero los productos relacionados
                    string consultaProductos =
                        "DELETE FROM data_productos " +
                        "WHERE CodigoVenta = @CodigoVenta";

                    using (MySqlCommand comandoProductos =
                        new MySqlCommand(
                            consultaProductos,
                            conexion))
                    {
                        comandoProductos.Parameters.AddWithValue(
                            "@CodigoVenta",
                            codigoVenta
                        );

                        comandoProductos.ExecuteNonQuery();
                    }

                    // Después eliminar la venta
                    string consultaVenta =
                        "DELETE FROM ventas WHERE ID = @ID";

                    using (MySqlCommand comandoVenta =
                        new MySqlCommand(
                            consultaVenta,
                            conexion))
                    {
                        comandoVenta.Parameters.AddWithValue(
                            "@ID",
                            id
                        );

                        int filas =
                            comandoVenta.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            Console.WriteLine(
                                "Venta eliminada correctamente."
                            );
                        }
                        else
                        {
                            Console.WriteLine(
                                "No se encontró una venta con ese ID."
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        "Error al eliminar venta: " + ex.Message
                    );
                }
            }
        }
    }
}