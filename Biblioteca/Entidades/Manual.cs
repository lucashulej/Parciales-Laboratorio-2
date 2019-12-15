using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Manual : Libro
    {
        public ETipo tipo;

        public Manual(string titulo, float precio, string nombre, string apellido, ETipo tipo) : base(precio, titulo, nombre, apellido)
        {
            this.tipo = tipo;
        }

        public string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Tipo " + this.tipo);
            retorno.AppendLine((string)this);
            return retorno.ToString();
        }

        public static bool operator ==(Manual a, Manual b)
        {
            bool retorno = false;
            if(Object.Equals(a, null) == false && Object.Equals(b, null) == false)
            {
                if((Libro)a == (Libro)b && a.tipo == b.tipo)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Manual a, Manual b)
        {
            return !(a == b);
        }

        public static implicit operator double(Manual m)
        {
            return m._precio;
        }
    }
}
