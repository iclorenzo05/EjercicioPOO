using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Tienda
{
    public partial class Form2 : Form
    {
        // Archivo donde se guardarán los registros.
        private string archivo = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
        "RegistroTienda.txt");
        public Form2()
        {
            InitializeComponent();

            // Conectar los botones con sus métodos.
            btnGuardar.Click += btnGuardar_Click;
            btnAbrir.Click += btnAbrir_Click;
        }

        // Guardar un registro en el archivo de texto.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = DateTime.Now.ToString("HH:mm:ss")
                + " | Registro de prueba de la tienda";

            File.AppendAllText(archivo, mensaje + Environment.NewLine);

            MessageBox.Show(
                "El registro se guardó correctamente.",
                "Registro guardado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Abrir el archivo guardado en el Bloc de notas.
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (File.Exists(archivo))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "notepad.exe",
                    Arguments = "\"" + archivo + "\"",
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show(
                    "Todavía no hay registros. Primero guarda uno.",
                    "Archivo no encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            btnGuardar_Click(sender, e);
        }
    }
}
