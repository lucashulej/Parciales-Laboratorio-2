using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Biblioteca
    {
        private int _capacidad;
        private List<Libro> _libros;

        private Biblioteca()
        {
            this._libros = new List<Libro>();
        }

        private Biblioteca(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public double PrecioDeManuales
        {
            get
            {
                double retorno = 0;
                double auxDouble = 0;
                foreach(Libro aux in this._libros)
                {
                    if(aux is Manual)
                    {
                        auxDouble = (Manual)aux;
                        retorno = retorno + auxDouble;
                    }
                }
                return retorno;
            }
        }

        public double PrecioDeNovelas
        {
            get
            {
                double retorno = 0;
                double auxDouble = 0;
                foreach (Libro aux in this._libros)
                {
                    if (aux is Novela)
                    {
                        auxDouble = (Novela)aux;
                        retorno = retorno + auxDouble;
                    }
                }
                return retorno;
            }
        }

        public double PrecioTotal
        {
            get
            {
                return this.PrecioDeManuales + this.PrecioDeNovelas;
            }
        }

        public static string Mostrar(Biblioteca e)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Capacidad de la biblioteca: " + e._capacidad);
            retorno.AppendFormat("Total por manuales: {0:#.##}\n", e.PrecioDeManuales);
            retorno.AppendFormat("Total por novelas: {0:#.##}\n", e.PrecioDeNovelas);
            retorno.AppendFormat("Total: {0:#.##}\n",  e.PrecioTotal);
            retorno.AppendLine("******************************\nListado de Libros\n******************************");
            foreach (Libro aux in e._libros)
            {
                if(aux is Novela)
                {
                    retorno.AppendLine(((Novela)aux).Mostrar());
                }
                else
                {
                    retorno.AppendLine(((Manual)aux).Mostrar());
                }
            }
            return retorno.ToString();
        }

        public static implicit operator Biblioteca(int capacidad)
        {
            return new Biblioteca(capacidad);
        }

        public static bool operator ==(Biblioteca e, Libro i)
        {
            bool retorno = false;
            if(Object.Equals(e, null) == false && Object.Equals(i, null) == false)
            {
                foreach(Libro aux in e._libros)
                {
                    if(aux is Novela && i is Novela)
                    {
                        if((Novela)aux == (Novela)i)
                        {
                            retorno = true;
                            break;
                        }
                        continue;
                    }
                    if(aux is Manual && i is Manual)
                    {
                        if ((Manual)aux == (Manual)i)
                        {
                            retorno = true;
                            break;
                        }
                    }
                }
            }
            return retorno;
        }

        public static bool operator !=(Biblioteca e, Libro i)
        {
            return !(e == i);
        }

        public static Biblioteca operator +(Biblioteca e, Libro i)
        {
            if(e != i)
            {
                if(e._libros.Count < e._capacidad)
                {
                    e._libros.Add(i);
                }
                else
                {
                    Console.WriteLine("NO hay mas lugar en la biblioteca");
                }
            }
            else
            {
                Console.WriteLine("El libro ya esta en la biblioteca");
            }
            return e;
        }

        private double ObtenerPrecio(ELibro tipoLibro)
        {
            double retorno = 0;
            switch(tipoLibro)
            {
                case ELibro.Manual:
                    retorno = this.PrecioDeManuales;
                    break;
                case ELibro.Novela:
                    retorno = this.PrecioDeNovelas;
                    break;
                case ELibro.Ambos:
                    retorno = this.PrecioTotal;
                    break;
            }
            return retorno;
        }
    }
}
