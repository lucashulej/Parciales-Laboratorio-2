using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculo
    {
        public ETipo tipo;

        public Auto(string modelo, float precio, Fabricante fabri, ETipo tipo) : base(precio, modelo, fabri)
        {
            this.tipo = tipo;
        }

        public static bool operator ==(Auto a, Auto b)
        {
            bool retorno = false;
            if (a.tipo == b.tipo && (Vehiculo)a == (Vehiculo)b)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Auto a, Auto b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is Auto;
        }

        public override string ToString()
        {
            return (string)this + "TIPO: " + this. tipo;
        }

        public static explicit operator Single(Auto a)
        {
            return a.precio;
        }
    }
}
