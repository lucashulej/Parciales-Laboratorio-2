using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Entidades
{
    public static class Exstensora
    {
        public static bool ElimiarFruta(this Cajon<Manzana> cajon, int id)
        {
            bool retorno = false;
            try
            {
                using (SqlConnection dataBase = new SqlConnection(Properties.Settings.Default.Conexion))
                {
                    dataBase.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = dataBase;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "DELETE FROM frutas WHERE [id] = @id";
                    comando.Parameters.AddWithValue("@id", id);
                    if(comando.ExecuteNonQuery() != 0)
                    {
                        retorno = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error para eliminar en BD", e);
            }
            return retorno;
        }
    }
}
