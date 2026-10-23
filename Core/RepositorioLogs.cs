using Core.clases;
using Coree;
using EjercicioPOO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Core.repositorio
{
    internal class repositorioLog
    {
        public void Registro(Log log)
        {

            if (log.tipo == 1) // Tipo de error
            {
                File.AppendAllText(
                    $"{DateTime.Now.ToString("yyyyMMdd")}.txt",
                    $"{log.Fecha.ToString("HH:mm:ss")} | " +
                    $"{log.ex.Message} " +
                    $"{log.ex.StackTrace} | " +
                    $"{log.empleado.ID.ToString()}{Environment.NewLine}");
            }
            else if (log.tipo == 2) // Tipo de movimiento
            {
                File.AppendAllText(
                    $"{DateTime.Now.ToString("yyyyMMdd")}.txt",
                    $"{log.Fecha.ToString("HH:mm:ss")} | " +
                    $"{log.ex.Message} " +
                    $"{log.ex.StackTrace} | " +
                    $"{log.empleado.ID.ToString()}{Environment.NewLine}");
            }
        }

        public void RegistroDB(Log log)
        {
            MySqlConnection conn = new MySqlConnection(Utils.connStr);
            MySqlCommand comm = new MySqlCommand("insert into logs(fecha,mensaje, stacktrace,empleado,tipo)" +
            "values(@fecha,@mensaje,@stack,@empleado,@tipo)", conn);

            comm.Parameters.AddWithValue("@fecha", log.Fecha);
            comm.Parameters.AddWithValue("@mensaje", log.ex.Message); //muestra que pasa

            comm.Parameters.AddWithValue("@stack", log.ex.StackTrace); //muestra donde pasa el error

            comm.Parameters.AddWithValue("@empleado", log.empleado.ID);
            comm.Parameters.AddWithValue("@tipo", log.tipo);

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }

            catch
            {

            }

            finally
            {
                conn.Close();
            }
        }
    }
}

