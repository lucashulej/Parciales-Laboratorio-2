using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comerciante
    {
        private string nombre;
        private string apellido;

        public Comerciante(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public static bool operator ==(Comerciante a, Comerciante b)
        {
            bool retorno = false;
            if (a.nombre == b.nombre && a.apellido == b.apellido)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Comerciante a, Comerciante b)
        {
            return !(a == b);
        }

        public static implicit operator string(Comerciante a)
        {
            string retorno = "";
            retorno = a.nombre + " " + a.apellido + "\n";
            return retorno;
        }
    }
}
