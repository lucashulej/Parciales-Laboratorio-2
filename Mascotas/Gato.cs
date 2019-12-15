using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_01
{
    public class Gato : Mascota
    {
        public Gato(string nombre, string raza) : base(nombre, raza)
        {

        }

        protected override string Ficha()
        {
            return base.DatosCompletos();
        }

        public static bool operator==(Gato obj1, Gato obj2)
        {
            bool retorno = false;
            if (Object.Equals(obj1, null) == false && Object.Equals(obj2, null) == false)
            {
                if(obj1.Nombre == obj2.Nombre && obj1.Raza == obj2.Raza)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator!=(Gato obj1, Gato obj2)
        {
            return !(obj1 == obj2);
        }

        public override string ToString()
        {
            return this.Ficha();
        }
    }
}
