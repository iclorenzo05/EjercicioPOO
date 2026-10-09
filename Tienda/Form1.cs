using Core.clases;
using Core.Repositorios;
using System;
using System.Windows.Forms;

namespace Tienda
{
    public partial class Form1 : Form
    {
        // Guarda la venta que se está realizando.
        private Venta venta;
        private Empleado empleadoVenta;


        // Constructor del formulario.
        public Form1()
        {
            InitializeComponent();

            // Asignar un empleado existente para registrar las ventas.
            empleadoVenta = new Empleado
            {
                ID = 1,
                Nombre = "lola",
                CodigoMatricula = "12345"
            };

            // Crear la venta asociada al empleado.
            venta = new Venta(empleadoVenta);

            // Mostrar el total inicial.
            label1.Text = "$0.00";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener el código de barras escrito en el campo.
            string codigo = tb_id_producto.Text.Trim();


            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show(
                    "Por favor, ingrese el código de barras del producto.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Validar la cantidad ingresada.
            if (!float.TryParse(txtCantidad.Text, out float cantidad) || cantidad <= 0)
            {
                MessageBox.Show(
                    "Por favor, ingrese una cantidad mayor a cero.",
                    "Cantidad inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Buscar el producto por su código de barras en MySQL.
            RepositorioProductos repositorioProductos = new RepositorioProductos();

            Producto producto = repositorioProductos.BuscarPorCodigo(codigo);

            if (producto != null)
            {
                // Agregar el producto a la venta.
                venta.AgregarProducto(producto, cantidad);

                // Actualizar la tabla de productos de la venta.
                lista.DataSource = null;

                lista.DataSource = venta.Productos.Select(p => new
                {
                    Producto = p.Producto.Nombre,
                    Cantidad = p.Cantidad,
                    Precio = p.Precio,
                    Total = p.Total
                }).ToList();

                // Actualizar el total de la venta.
                label1.Text = venta.Total.ToString("C2");

                // Limpiar los campos para el siguiente producto.
                tb_id_producto.Clear();
                txtCantidad.Clear();

                tb_id_producto.Focus();
            }
            else
            {
                MessageBox.Show(
                    "No se encontró ningún producto con ese código de barras.",
                    "Producto no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                tb_id_producto.Focus();
                tb_id_producto.SelectAll();
            }


}


        // BOTÓN PAGAR: registra la venta.
        private void button1_Click(object sender, EventArgs e)
        {
            // Comprobar que haya productos en la venta.
            if (venta.Productos == null || venta.Productos.Count == 0)
            {
                MessageBox.Show(
                    "No hay productos agregados en la venta actual.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Registrar la venta en MySQL.
            RepositorioVentas repositorioVentas = new RepositorioVentas();

            bool registrada = repositorioVentas.Registro(
                venta,
                empleadoVenta.CodigoMatricula
            );

            if (registrada)
            {
                MessageBox.Show(
                    $"Venta registrada correctamente.\n" +
                    $"Atendió: {empleadoVenta.Nombre}\n" +
                    $"Código: {venta.CodigoVenta}\n" +
                    $"Total: {venta.Total:C2}",
                    "Venta exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Preparar una nueva venta.
                venta = new Venta(empleadoVenta);

                // Limpiar la tabla y restablecer el total.
                lista.DataSource = null;
                label1.Text = "$0.00";

                tb_id_producto.Clear();
                txtCantidad.Clear();
                tb_id_producto.Focus();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo registrar la venta. " +
                    "Revisa la conexión y los datos de MySQL.",
                    "Error al registrar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Evento del texto ID del producto.
        }

        private void Cantidad_Click(object sender, EventArgs e)
        {
            // Evento del texto Cantidad.
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            // Evento que se activa cuando cambia la cantidad.
        }
    }
}