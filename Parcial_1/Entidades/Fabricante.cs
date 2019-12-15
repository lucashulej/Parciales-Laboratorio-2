using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabricante
    {
        private string marca;
        private EPais pais;

        public Fabricante(string marca, EPais pais)
        {
            this.marca = marca;
            this.pais = pais;
        }

        public static bool operator ==(Fabricante a, Fabricante b)
        {
            bool retorno = false;
            if(a.pais == b.pais && a.marca == b.marca)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Fabricante a, Fabricante b)
        {
            return !(a == b);
        }

        public static implicit operator string(Fabricante f)
        {
            return "Fabricante = " + f.marca + " - " + f.pais;
        }
    }
}
