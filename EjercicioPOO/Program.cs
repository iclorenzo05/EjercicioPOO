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

            Repositoriosempleados repositorioempleados =
                new Repositoriosempleados();

            Empleado empleado = new Empleado();

            List<Empleado> listaEmpleados =
                repositorioempleados.Lista();

            switch (accion)
            {
                // ================= REGISTRAR =================
                case "R":

                    Console.WriteLine("Ingrese el nombre del empleado:");
                    empleado.Nombre = Console.ReadLine();

                    Console.WriteLine("Ingrese la edad del empleado:");
                    empleado.Edad =
                        Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese el salario del empleado:");
                    empleado.Salario =
                        Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Ingrese la matrícula de 5 dígitos:");
                    empleado.CodigoMatricula =
                        Console.ReadLine();

                    repositorioempleados.Registro(empleado);

                    break;

                // ================= ACTUALIZAR =================
                case "A":

                    Console.WriteLine(
                        "Ingrese el ID del empleado a actualizar:"
                    );

                    empleado.ID =
                        Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(
                        "Ingrese el nuevo nombre del empleado:"
                    );

                    empleado.Nombre =
                        Console.ReadLine();

                    Console.WriteLine(
                        "Ingrese la nueva edad del empleado:"
                    );

                    empleado.Edad =
                        Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(
                        "Ingrese el nuevo salario del empleado:"
                    );

                    empleado.Salario =
                        Convert.ToDouble(Console.ReadLine());

                    repositorioempleados.Actualizar(empleado);

                    break;

                // ================= ELIMINAR =================
                case "E":

                    Console.WriteLine(
                        "Ingrese el ID del empleado a eliminar:"
                    );

                    empleado.ID =
                        Convert.ToInt32(Console.ReadLine());

                    repositorioempleados.Borrar(empleado);

                    break;

                // ================= VER LA LISTA =================
                case "V":

                    Console.WriteLine(
                        "ID | Nombre | Edad | Salario"
                    );

                    foreach (Empleado empl in listaEmpleados)
                    {
                        Console.WriteLine(
                            $"{empl.ID} | {empl.Nombre} | " +
                            $"{empl.Edad} | ${empl.Salario}"
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

            Repositorioproducto repositorioproducto =
                new Repositorioproducto();

            Producto producto = new Producto();

            switch (accion)
            {
                // ================= REGISTRAR =================
                case "R":

                    Console.WriteLine(
                        "Ingrese el nombre del producto:"
                    );

                    producto.Nombre =
                        Console.ReadLine();

                    Console.WriteLine(
                        "Ingrese el precio del producto:"
                    );

                    producto.Precio =
                        Convert.ToDouble(Console.ReadLine());

                    repositorioproducto.Registro(producto);

                    break;

                // ================= ACTUALIZAR =================
                case "A":

                    Console.WriteLine(
                        "Ingrese el ID del producto a actualizar:"
                    );

                    producto.ID =
                        Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(
                        "Ingrese el nuevo nombre del producto:"
                    );

                    producto.Nombre =
                        Console.ReadLine();

                    Console.WriteLine(
                        "Ingrese el nuevo precio del producto:"
                    );

                    producto.Precio =
                        Convert.ToDouble(Console.ReadLine());

                    repositorioproducto.Actualizar(producto);

                    break;

                // ================= ELIMINAR =================
                case "E":

                    Console.WriteLine(
                        "Ingrese el ID del producto a eliminar:"
                    );

                    producto.ID =
                        Convert.ToInt32(Console.ReadLine());

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
            RepositorioVentas repositorioVentas =
                new RepositorioVentas();

            Console.WriteLine("============== TIENDA ==============");
            Console.WriteLine("¿Qué movimiento realizará?");
            Console.WriteLine("V - Vender");
            Console.WriteLine("H - Historial");
            Console.Write("Seleccione una opción: ");

            string movimiento =
                Console.ReadLine().ToUpper();

            Console.WriteLine("====================================");

            switch (movimiento)
            {
                // ================= VENDER =================
                case "V":

                    Venta venta =
                        new Venta(empleadoLogin);

                    Console.WriteLine(
                        "============== NUEVA VENTA =============="
                    );

                    Console.WriteLine(
                        "Código de venta: " +
                        venta.CodigoVenta
                    );

                    Console.WriteLine(
                        "Empleado: " +
                        venta.Empleado.Nombre
                    );

                    Console.WriteLine(
                        "Fecha: " +
                        venta.Fecha.ToString(
                            "dd/MM/yyyy HH:mm"
                        )
                    );

                    Console.WriteLine();

                    // Matrícula del cliente
                    Console.Write(
                        "Ingrese la matrícula del cliente: "
                    );

                    string codigoMatriculaCliente =
                        Console.ReadLine();

                    string continuar;

                    // ================= AGREGAR PRODUCTOS =================
                    do
                    {
                        Console.WriteLine();

                        Console.Write(
                            "Ingrese el ID del producto: "
                        );

                        int idProducto =
                            Convert.ToInt32(
                                Console.ReadLine()
                            );

                        Repositorioproducto repositorioProducto =
                            new Repositorioproducto();

                        Producto productoVenta =
                            repositorioProducto.BuscarPorId(
                                idProducto
                            );

                        if (productoVenta == null)
                        {
                            Console.WriteLine(
                                "No se encontró ese producto."
                            );
                        }
                        else
                        {
                            Console.Write(
                                "Ingrese la cantidad: "
                            );

                            float cantidad =
                                Convert.ToSingle(
                                    Console.ReadLine()
                                );

                            venta.AgregarProducto(
                                productoVenta,
                                cantidad
                            );

                            VentaProducto ultimoProducto =
                                venta.Productos[
                                    venta.Productos.Count - 1
                                ];

                            Console.WriteLine();
                            Console.WriteLine(
                                "Producto agregado."
                            );

                            Console.WriteLine(
                                "Total del producto: $" +
                                ultimoProducto.Total.ToString("F2")
                            );
                        }

                        Console.WriteLine();

                        Console.Write(
                            "¿Desea agregar otro producto? " +
                            "S - Sí / N - No: "
                        );

                        continuar =
                            Console.ReadLine().ToUpper();

                    } while (continuar == "S");


                    // ================= COBRAR =================
                    Console.WriteLine();
                    Console.WriteLine(
                        "============== COBRANDO =============="
                    );

                    Console.WriteLine();

                    Console.WriteLine(
                        "PRODUCTO\t\tPRECIO UNITARIO\tCANTIDAD\tTOTAL"
                    );

                    Console.WriteLine(
                        "---------------------------------------------------------------"
                    );

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

                    Console.WriteLine(
                        "Cliente: " +
                        codigoMatriculaCliente
                    );

                    Console.WriteLine(
                        "Empleado: " +
                        venta.Empleado.Nombre
                    );

                    Console.WriteLine(
                        "Código de venta: " +
                        venta.CodigoVenta
                    );

                    Console.WriteLine(
                        "Fecha: " +
                        venta.Fecha.ToString(
                            "dd/MM/yyyy HH:mm"
                        )
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

                    List<Venta> listaVentas =
                        repositorioVentas.Lista();

                    Console.WriteLine(
                        "============== HISTORIAL DE VENTAS =============="
                    );

                    if (listaVentas.Count == 0)
                    {
                        Console.WriteLine(
                            "No hay ventas registradas."
                        );
                    }
                    else
                    {
                        // Mostrar las ventas de la más reciente
                        // a la más antigua
                        for (int i = 0;
                             i < listaVentas.Count;
                             i++)
                        {
                            Venta ven =
                                listaVentas[i];

                            Console.WriteLine(
                                $"{i + 1}. Código: " +
                                $"{ven.CodigoVenta} | " +
                                $"Fecha: " +
                                $"{ven.Fecha.ToString("dd/MM/yyyy HH:mm")} | " +
                                $"Total: ${ven.Total:F2}"
                            );
                        }

                        Console.WriteLine();

                        Console.Write(
                            "Seleccione el número de la venta " +
                            "que desea consultar: "
                        );

                        int seleccion =
                            Convert.ToInt32(
                                Console.ReadLine()
                            );

                        if (seleccion >= 1 &&
                            seleccion <= listaVentas.Count)
                        {
                            // Primero obtenemos la venta seleccionada
                            Venta ventaSeleccionada =
                                listaVentas[seleccion - 1];

                            // Obtenemos el CódigoVenta real
                            string codigoVenta =
                                ventaSeleccionada.CodigoVenta;

                            // Buscamos los productos usando el CódigoVenta
                            List<VentaProducto> productosVenta =
                                repositorioVentas.ListaProductosPorVenta(
                                    codigoVenta
                                );

                            Console.WriteLine();

                            Console.WriteLine(
                                "============== DETALLE DE LA VENTA =============="
                            );

                            Console.WriteLine(
                                "Código de venta: " +
                                codigoVenta
                            );

                            Console.WriteLine(
                                "Fecha: " +
                                ventaSeleccionada.Fecha.ToString(
                                    "dd/MM/yyyy HH:mm"
                                )
                            );

                            Console.WriteLine(
                                "Empleado ID: " +
                                ventaSeleccionada.Empleado.ID
                            );

                            Console.WriteLine(
                                "Total de la venta: $" +
                                ventaSeleccionada.Total.ToString(
                                    "F2"
                                )
                            );

                            Console.WriteLine();

                            Console.WriteLine(
                                "PRODUCTOS DE LA VENTA"
                            );

                            Console.WriteLine(
                                "------------------------------------------------------------"
                            );

                            foreach (
                                VentaProducto vp
                                in productosVenta
                            )
                            {
                                Console.WriteLine(
                                    $"Producto: " +
                                    $"{vp.Producto.Nombre}"
                                );

                                Console.WriteLine(
                                    $"Precio: ${vp.Precio:F2} | " +
                                    $"Cantidad: {vp.Cantidad} | " +
                                    $"Total: ${vp.Total:F2}"
                                );

                                Console.WriteLine(
                                    "------------------------------------------------------------"
                                );
                            }
                        }
                        else
                        {
                            Console.WriteLine(
                                "Número de venta no válido."
                            );
                        }
                    }

                    break;


                // ================= OPCIÓN NO VÁLIDA =================
                default:

                    Console.WriteLine(
                        "Opción no válida."
                    );

                    break;
            }

            break;
        }
}
