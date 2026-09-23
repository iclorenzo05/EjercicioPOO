using EjercicioPOO;
using EjercicioPOO.Repositorios;
using System;

Console.WriteLine("============== Menu Principal ==============");
Console.WriteLine("1. Empleado");
Console.WriteLine("2. Producto");
Console.Write("Seleccione una opción: ");

int opcion = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("============================================");

Console.WriteLine("¿Qué opción desea realizar?");
Console.WriteLine("R. Registrar");
Console.WriteLine("A. Actualizar");
Console.WriteLine("E. Eliminar");
Console.Write("Seleccione una acción: ");

string accion = Console.ReadLine().ToUpper();

Console.WriteLine("============================================");

switch (opcion)
{
    case 1:

        Repositoriosempleados repositorioempleados = new Repositoriosempleados();
        Empleado empleado = new Empleado();

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

            default:

                Console.WriteLine("Acción no válida.");

                break;
        }

        break;

    case 2:

        Repositorioproducto repositorioproducto = new Repositorioproducto();
        Producto producto = new Producto();

        switch (accion)
        {
            case "R":

                Console.WriteLine("Ingrese el nombre del producto:");
                producto.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el precio del producto:");
                producto.Precio = Convert.ToDouble(Console.ReadLine());

                repositorioproducto.Registro(producto);

                break;

            case "A":

                Console.WriteLine("Ingrese el ID del producto a actualizar:");
                producto.ID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingrese el nuevo nombre del producto:");
                producto.Nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el nuevo precio del producto:");
                producto.Precio = Convert.ToDouble(Console.ReadLine());

                repositorioproducto.Actualizar(producto);

                break;

            case "E":

                Console.WriteLine("Ingrese el ID del producto a eliminar:");
                producto.ID = Convert.ToInt32(Console.ReadLine());

                repositorioproducto.Borrar(producto);

                break;

            default:

                Console.WriteLine("Acción no válida.");

                break;
        }

        break;

    default:

        Console.WriteLine("Opción no válida.");

        break;
}