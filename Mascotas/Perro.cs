using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_01
{
    public class Perro : Mascota
    {
        private int edad;
        private bool esAlfa;

        public int Edad
        {
            get
            {
                return this.edad;
            }
            set
            {
                this.edad = value;
            }
        }

        public bool EsAlfa
        {
            get
            {
                return this.esAlfa;
            }
            set
            {
                this.esAlfa = value;
            }
        }

        public Perro(string nombre, string raza) : base(nombre, raza)
        {
            this.edad = 0;
            this.esAlfa = false;
        }
        
        public Perro(string nombre, string raza, int edad, bool esAlfa) : this(nombre, raza)
        {
            this.edad = edad;
            this.esAlfa = esAlfa;
        }

        protected override string Ficha()
        {
            string retorno = "";
            if(this.esAlfa == true)
            {
                retorno = base.DatosCompletos() + ", alfa de la manada, edad " + this.edad;
            }
            else
            {
                retorno = base.DatosCompletos() + " edad " + this.edad;
            }

            return retorno;
        }

        public static bool operator ==(Perro j1, Perro j2)
        {
            bool retorno = false;
            if(Object.Equals(j1,null) == false && Object.Equals(j2, null) == false)
            {
                if(j1.Nombre == j2.Nombre && j1.Raza == j2.Raza && j1.edad == j2.edad)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Perro j1, Perro j2)
        {
            return !(j1 == j2);
        }

        public override bool Equals(object obj)
        {
            return obj is Perro;
        }

        public override string ToString()
        {
            return this.Ficha();
        }
    }
}
