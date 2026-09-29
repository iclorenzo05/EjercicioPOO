using EjercicioPOO;
using EjercicioPOO.Repositorios;
using System;
using System.Collections.Generic;

Repositoriosempleados repositorioLogin = new Repositoriosempleados();

Console.WriteLine("============================================");
Console.WriteLine("           ACCESO AL SISTEMA");
Console.WriteLine("============================================");
Console.Write("Ingrese su código de matrícula: ");

string codigo = Console.ReadLine();

Empleado empleadoLogin = repositorioLogin.BuscarCodigoMatricula(codigo);

if (empleadoLogin == null)
{
    Console.WriteLine("No existe ese usuario.");
    return;
}

Console.WriteLine("Acceso correcto.");
Console.WriteLine("Bienvenido " + empleadoLogin.Nombre);
Console.WriteLine();

Console.WriteLine("============== Menu Principal ==============");
Console.WriteLine("1. Empleado");
Console.WriteLine("2. Producto");
Console.WriteLine("3. Tienda");
Console.Write("Seleccione una opción: ");

int opcion = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("============================================");

switch (opcion)
{
    // ================= EMPLEADO =================
    case 1:
        {
            Console.WriteLine("¿Qué opción desea realizar?");
            Console.WriteLine("R. Registrar");
            Console.WriteLine("A. Actualizar");
            Console.WriteLine("E. Eliminar");
            Console.WriteLine("V. Ver lista");
            Console.Write("Seleccione una acción: ");

            string accion = Console.ReadLine().ToUpper();

            Console.WriteLine("============================================");

            Repositoriosempleados repositorioempleados = new Repositoriosempleados();
            Empleado empleado = new Empleado();

            List<Empleado> listaEmpleados = repositorioempleados.Lista();

            switch (accion)
            {
                // ================= REGISTRAR =================
                case "R":

                    Console.WriteLine("Ingrese el nombre del empleado:");
                    empleado.Nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese la edad del empleado:");
                    empleado.Edad = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese el salario del empleado:");
                    empleado.Salario = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Ingrese la matrícula de 5 dígitos:");
                    empleado.CodigoMatricula = Console.ReadLine();

                    repositorioempleados.Registro(empleado);

                    break;

                // ================= ACTUALIZAR =================
                case "A":

                    Console.WriteLine("Ingrese el ID del empleado a actualizar:");
                    empleado.ID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese el nuevo nombre del empleado:");
                    empleado.Nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese la nueva edad del empleado:");
                    empleado.Edad = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese el nuevo salario del empleado:");
                    empleado.Salario = Convert.ToDouble(Console.ReadLine());

                    repositorioempleados.Actualizar(empleado);

                    break;

                // ================= ELIMINAR =================
                case "E":

                    Console.WriteLine("Ingrese el ID del empleado a eliminar:");
                    empleado.ID = Convert.ToInt32(Console.ReadLine());

                    repositorioempleados.Borrar(empleado);

                    break;

                // ================= VER LA LISTA =================
                case "V":

                    Console.WriteLine("ID | Nombre | Edad | Salario");

                    foreach (Empleado empl in listaEmpleados)
                    {
                        Console.WriteLine(
                            $"{empl.ID} | {empl.Nombre} | {empl.Edad} | ${empl.Salario}"
                        );
                    }

                    break;

                default:

                    Console.WriteLine("Acción no válida.");

                    break;
            }

            break;
        }


    // ================= PRODUCTO =================
    case 2:
        {
            Console.WriteLine("¿Qué opción desea realizar?");
            Console.WriteLine("R. Registrar");
            Console.WriteLine("A. Actualizar");
            Console.WriteLine("E. Eliminar");
            Console.WriteLine("V. Ver lista");
            Console.Write("Seleccione una acción: ");

            string accion = Console.ReadLine().ToUpper();

            Console.WriteLine("============================================");

            Repositorioproducto repositorioproducto = new Repositorioproducto();
            Producto producto = new Producto();

            switch (accion)
            {
                // ================= REGISTRAR =================
                case "R":

                    Console.WriteLine("Ingrese el nombre del producto:");
                    producto.Nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese el precio del producto:");
                    producto.Precio = Convert.ToDouble(Console.ReadLine());

                    repositorioproducto.Registro(producto);

                    break;

                // ================= ACTUALIZAR =================
                case "A":

                    Console.WriteLine("Ingrese el ID del producto a actualizar:");
                    producto.ID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese el nuevo nombre del producto:");
                    producto.Nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese el nuevo precio del producto:");
                    producto.Precio = Convert.ToDouble(Console.ReadLine());

                    repositorioproducto.Actualizar(producto);

                    break;

                // ================= ELIMINAR =================
                case "E":

                    Console.WriteLine("Ingrese el ID del producto a eliminar:");
                    producto.ID = Convert.ToInt32(Console.ReadLine());

                    repositorioproducto.Borrar(producto);

                    break;

                // ================= VER LA LISTA =================
                case "V":

                    Console.WriteLine("Lista de productos.");

                    break;

                default:

                    Console.WriteLine("Acción no válida.");

                    break;
            }

            break;
        }


    // ================= TIENDA =================
    case 3:
        {
            RepositorioVentas repositorioVentas = new RepositorioVentas();

            Console.WriteLine("============== TIENDA ==============");
            Console.WriteLine("¿Qué movimiento realizará?");
            Console.WriteLine("V - Vender");
            Console.WriteLine("H - Historial");
            Console.Write("Seleccione una opción: ");

            string movimiento = Console.ReadLine().ToUpper();

            Console.WriteLine("====================================");

            switch (movimiento)
            {
                // ================= VENDER =================
                case "V":

                    Venta venta = new Venta();

                    // Datos generales de la venta
                    venta.CodigoVenta = DateTime.Now.ToString("yyyyMMddHHmmss");
                    venta.Fecha = DateTime.Now;
                    venta.Empleado = empleadoLogin;
                    venta.Productos = new List<VentaProducto>();
                    venta.Total = 0;

                    Console.WriteLine("============== NUEVA VENTA ==============");
                    Console.WriteLine("Código de venta: " + venta.CodigoVenta);
                    Console.WriteLine("Empleado: " + venta.Empleado.Nombre);
                    Console.WriteLine("Fecha: " + venta.Fecha.ToString("dd/MM/yyyy HH:mm"));
                    Console.WriteLine();

                    // Matrícula del cliente
                    Console.Write("Ingrese la matrícula del cliente: ");
                    string codigoMatriculaCliente = Console.ReadLine();

                    string continuar;

                    // ================= AGREGAR PRODUCTOS =================
                    do
                    {
                        Console.WriteLine();
                        Console.Write("Ingrese el nombre del producto: ");
                        string nombreProducto = Console.ReadLine();

                        Repositorioproducto repositorioProducto = new Repositorioproducto();

                        List<Producto> resultados = repositorioProducto.Buscar(nombreProducto);

                        Producto productoVenta = null;

                        if (resultados.Count > 0)
                        {
                            productoVenta = resultados[0];
                        }

                        if (productoVenta == null)
                        {
                            Console.WriteLine("No se encontró ese producto.");
                        }
                        else
                        {
                            VentaProducto ventaProducto = new VentaProducto();

                            ventaProducto.Producto = productoVenta;

                            Console.Write("Ingrese la cantidad: ");
                            ventaProducto.Cantidad = Convert.ToSingle(Console.ReadLine());

                            // Calcular total del producto
                            ventaProducto.Total =
                                (decimal)productoVenta.Precio *
                                (decimal)ventaProducto.Cantidad;

                            // Agregar producto a la venta
                            venta.Productos.Add(ventaProducto);

                            // Sumar al total general
                            venta.Total += ventaProducto.Total;

                            Console.WriteLine();
                            Console.WriteLine("Producto agregado.");
                            Console.WriteLine(
                                "Total del producto: $" +
                                ventaProducto.Total.ToString("F2")
                            );
                        }

                        Console.WriteLine();
                        Console.Write("¿Desea agregar otro producto? S - Sí / N - No: ");
                        continuar = Console.ReadLine().ToUpper();

                    } while (continuar == "S");


                    // ================= COBRAR =================
                    Console.WriteLine();
                    Console.WriteLine("============== COBRANDO ==============");
                    Console.WriteLine();

                    // Encabezado de la tabla
                    Console.WriteLine(
                        "PRODUCTO\t\tPRECIO UNITARIO\tCANTIDAD\tTOTAL"
                    );

                    Console.WriteLine(
                        "---------------------------------------------------------------"
                    );

                    // Mostrar cada producto de la venta
                    foreach (VentaProducto prod in venta.Productos)
                    {
                        Console.WriteLine(
                            $"{prod.Producto.Nombre,-15}\t" +
                            $"${prod.Producto.Precio,-15:F2}\t" +
                            $"{prod.Cantidad,-10}\t" +
                            $"${prod.Total:F2}"
                        );
                    }

                    Console.WriteLine(
                        "---------------------------------------------------------------"
                    );

                    Console.WriteLine(
                        $"TOTAL DE LA VENTA:\t\t\t\t${venta.Total:F2}"
                    );

                    Console.WriteLine();

                    // Mostrar datos de la venta
                    Console.WriteLine("Cliente: " + codigoMatriculaCliente);
                    Console.WriteLine("Empleado: " + venta.Empleado.Nombre);
                    Console.WriteLine("Código de venta: " + venta.CodigoVenta);
                    Console.WriteLine(
                        "Fecha: " + venta.Fecha.ToString("dd/MM/yyyy HH:mm")
                    );

                    Console.WriteLine();

                    // Guardar la venta en MySQL
                    repositorioVentas.Registro(
                        venta,
                        codigoMatriculaCliente
                    );

                    break;


                // ================= HISTORIAL =================
                case "H":

                    List<Venta> listaVentas = repositorioVentas.Lista();

                    Console.WriteLine(
                        "============== HISTORIAL DE VENTAS =============="
                    );

                    foreach (Venta ven in listaVentas)
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine(
                            "Empleado: " + ven.Empleado.Nombre
                        );
                        Console.WriteLine("Total: $" + ven.Total);

                        Console.WriteLine("Productos:");

                        foreach (VentaProducto vp in ven.Productos)
                        {
                            Console.WriteLine(
                                $"Producto: {vp.Producto.Nombre} | " +
                                $"Cantidad: {vp.Cantidad} | " +
                                $"Total: ${vp.Total}"
                            );
                        }
                    }

                    break;


                default:

                    Console.WriteLine("Opción no válida.");

                    break;
            }

            break;
        }
}