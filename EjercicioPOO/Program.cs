using EjercicioPOO;
using EjercicioPOO.Repositorios;
using System;

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
                        Console.WriteLine($"{empl.ID} | {empl.Nombre} | {empl.Edad} | ${empl.Salario}");
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

                    // Aquí después podemos poner la lista de productos
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
            Console.WriteLine("============== TIENDA ==============");
            Console.WriteLine("1. Registrar venta");
            Console.WriteLine("2. Ver lista de ventas");
            Console.WriteLine("3. Eliminar venta");
            Console.Write("Seleccione una opción: ");

            int opcionTienda = Convert.ToInt32(Console.ReadLine());

            RepositorioVentas repositorioVentas = new RepositorioVentas();
            Venta venta = new Venta();

            Console.WriteLine("====================================");

            switch (opcionTienda)
            {
                case 1:

                    venta.Empleado = empleadoLogin.Nombre;
                    venta.CodigoMatriculaEmpleado = empleadoLogin.CodigoMatricula;

                    Console.WriteLine("Ingrese el nombre del producto:");
                    venta.Producto = Console.ReadLine();

                    Console.WriteLine("Ingrese la cantidad:");
                    venta.Cantidad = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese el precio:");
                    venta.Precio = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Ingrese la matrícula del cliente:");
                    venta.CodigoMatriculaCliente = Console.ReadLine();

                    venta.Total = venta.Cantidad * venta.Precio;

                    Console.WriteLine("Total de la venta: $" + venta.Total);

                    repositorioVentas.Registro(venta);

                    break;

                case 2:

                    List<Venta> listaVentas = repositorioVentas.Lista();

                    Console.WriteLine("============== LISTA DE VENTAS ==============");

                    Console.WriteLine("ID | Empleado | Mat. Empleado | Producto | Cantidad | Precio | Mat. Cliente | Total");

                    foreach (Venta ven in listaVentas)
                    {
                        Console.WriteLine(
                            $"{ven.ID} | {ven.Empleado} | {ven.CodigoMatriculaEmpleado} | {ven.Producto} | {ven.Cantidad} | ${ven.Precio} | {ven.CodigoMatriculaCliente} | ${ven.Total}"
                        );
                    }

                    break;

                case 3:

                    Console.WriteLine("Ingrese el ID de la venta que desea eliminar:");
                    venta.ID = Convert.ToInt32(Console.ReadLine());

                    repositorioVentas.Borrar(venta);

                    break;


                default:

                    Console.WriteLine("Opción no válida.");

                    break;

                    Console.WriteLine("Opción no válida.");

                    break;
            }

            break;
        }


    // ================= OPCIÓN NO VÁLIDA =================
    default:

        Console.WriteLine("Opción no válida.");

        break;
}