using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Entidades
{
    public class Manejadora<T>
    {
        public void LimitePrecio(Object sender) //ESTE ES EL MANEJADOR
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\archivo.txt"))
                {
                    writer.WriteLine("Fecha y Hora = " + DateTime.Now);
                    writer.WriteLine("Precio Total = " + ((Cajon<T>)sender).PrecioTotal);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error con el txt", exception);
            }
        }
    }
}
