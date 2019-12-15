using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_01
{
    public class Grupo
    {
        public enum TipoManada
        {
            Unica,
            Mixta
        }
        private List<Mascota> manada;
        private string nombre;
        private static TipoManada tipo;

        public static TipoManada Tipo
        {
            set
            {
                Grupo.tipo = value;
            }
        }

        private Grupo()
        {
            this.manada = new List<Mascota>();
        }

        static Grupo()
        {
            Grupo.tipo = TipoManada.Unica;
        }

        public Grupo(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public Grupo(string nombre, TipoManada tipo) : this(nombre)
        {
            Grupo.tipo = tipo;
        }

        public static bool operator ==(Grupo e, Mascota j)
        {
            bool retorno = false;
            if (Object.Equals(e, null) == false && Object.Equals(j, null) == false)
            {
                foreach(Mascota aux in e.manada)
                {
                    if(aux == j)
                    {
                        retorno = true;
                        break;
                    }
                }

            }
            return retorno;
        }

        public static bool operator !=(Grupo e, Mascota j)
        {
            return !(e == j);
        }

        public static Grupo operator +(Grupo e, Mascota j)
        {
            if (Object.Equals(e, null) == false && Object.Equals(j, null) == false)
            {
                if (e != j)
                {
                    e.manada.Add(j);
                }  
            }
            return e;
        }

        public static Grupo operator -(Grupo e, Mascota j)
        {
            if (Object.Equals(e, null) == false && Object.Equals(j, null) == false)
            {
                if (e == j)
                {
                    e.manada.Remove(j);
                }
            }
            return e;
        }

        public static implicit operator string(Grupo e)
        {
            string retorno = "";
            retorno = retorno + e.nombre + "\n" + "Integrantes" + "\n";
            foreach(Mascota auxiliar in e.manada)
            {
                retorno = retorno + auxiliar.ToString();
                retorno = retorno + "\n";
            }
            return retorno;
        }
    }
}





