using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        protected Autor _autor;
        protected int _cantidadDePaginas;
        protected static Random _genereadorDePaginas;
        protected float _precio;
        protected string _titulo;

        public int CantidadDePaginas
        {
            get
            {
                if (this._cantidadDePaginas == 0)
                {
                    this._cantidadDePaginas = _genereadorDePaginas.Next(10, 580);
                }
                return this._cantidadDePaginas;
            }
        }

        static Libro()
        {
            Libro._genereadorDePaginas = new Random();
        }

        public Libro(float precio, string titulo, string nombre, string apellido) : this(titulo, new Autor(nombre, apellido), precio)
        {

        }

        public Libro(string titulo, Autor autor, float precio)
        {
            this._titulo = titulo;
            this._autor = autor;
            this._precio = precio;
        }

        public static explicit operator string(Libro i)
        {
            return Libro.Mostrar(i);
        }

        public static bool operator ==(Libro a, Libro b)
        {
            bool retorno = false;
            if(Object.Equals(a, null) == false && Object.Equals(b, null) == false)
            {
                if(a._autor == b._autor && a._titulo == b._titulo)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool operator !=(Libro a, Libro b)
        {
            return !(a == b);
        }

        private static string Mostrar(Libro i)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Titulo " + i._titulo);
            retorno.AppendLine("Precio " + i._precio);
            retorno.AppendLine("Cantidad de paginas " + i.CantidadDePaginas);
            retorno.AppendLine("Autor " + i._autor);

            return retorno.ToString();
        }
    }
}
