using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Autor
    {
        private string nombre;
        private string apellido;

        public Autor(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public static implicit operator string(Autor a)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Nombre: " + a.nombre);
            retorno.AppendLine("Apellido: " + a.apellido);
            return retorno.ToString();
        }

        public static bool operator ==(Autor a, Autor b)
        {
            bool retorno = false;
            if(Object.Equals(a, null)  == false && Object.Equals(b, null) == false)
            {
                if(a.nombre == b.nombre && a.apellido == b.apellido)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Autor a, Autor b)
        {
            return !(a == b);
        }
    }
}
