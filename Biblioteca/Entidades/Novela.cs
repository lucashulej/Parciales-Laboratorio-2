using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Novela : Libro
    {
        public EGenero genero;

        public Novela(string titulo, float precio, Autor autor, EGenero genero) :base(titulo, autor, precio)
        {
            this.genero = genero;
        }

        public string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Genero " + this.genero);
            retorno.AppendLine((string)this);
            return retorno.ToString();
        }

        public static bool operator ==(Novela a, Novela b)
        {
            bool retorno = false;
            if (Object.Equals(a, null) == false && Object.Equals(b, null) == false)
            {
                if ((Libro)a == (Libro)b && a.genero == b.genero)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Novela a, Novela b)
        {
            return !(a == b);
        }

        public static implicit operator double(Novela m)
        {
            return m._precio;
        }
    }
}
