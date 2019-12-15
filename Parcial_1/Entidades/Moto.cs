using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto: Vehiculo
    {
        public ECilindrada cilindrada;

        public Moto(string marca, EPais pais, string modelo, float precio, ECilindrada cilindrada) :  base(marca, pais, modelo, precio)
        {
            this.cilindrada = cilindrada;
        }

        public static bool operator ==(Moto a, Moto b)
        {
            bool retorno = false;
            if (a.cilindrada == b.cilindrada && (Vehiculo)a == (Vehiculo)b)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Moto a, Moto b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is Moto;
        }

        public override string ToString()
        {
            return (string)this + "CILINDRADA: " + this.cilindrada;
        }

        public static implicit operator Single(Moto m)
        {
            return m.precio;
        }
    }
}
