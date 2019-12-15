using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Shopping
    {
        private int _capacidad;
        private List<Comercio> _comercios;

        private Shopping()
        {
            this._comercios = new List<Comercio>();
        }

        private Shopping(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public double PrecioImportadores
        {
            get
            {
                return this.ObtenerPrecio(EComercio.Importador);
            }
        }

        public double PrecioExportadores
        {
            get
            {
                return this.ObtenerPrecio(EComercio.Exportador);
            }
        }

        public double PrecioTotal
        {
            get
            {
                return this.ObtenerPrecio(EComercio.Ambos);
            }
        }

        public static string Mostrar(Shopping s)
        {
            StringBuilder retorno = new StringBuilder();
            if(Object.Equals(s,null) == false)
            {
                retorno.AppendLine("Capacidad del shopping " + s._capacidad);
                retorno.AppendLine("Total importadores " + s.PrecioImportadores.ToString());
                retorno.AppendLine("Total exportadores " + s.PrecioExportadores.ToString());
                retorno.AppendLine("Total " + s.PrecioTotal.ToString());
                retorno.AppendLine("listado de comercios");
                foreach (Comercio aux in s._comercios)
                {
                    if(aux is Importador)
                    {
                        retorno.AppendLine(((Importador)aux).Mostrar());
                        retorno.AppendLine();
                    }
                    else
                    {
                        retorno.AppendLine(((Exportador)aux).Mostrar());
                        retorno.AppendLine();
                    }
                }
            }
            return retorno.ToString();
        }

        public static implicit operator Shopping(int capacidad)
        {
            return new Shopping(capacidad);
        }

        public static bool operator ==(Shopping s, Comercio c)
        {
            bool retorno = false;
            foreach(Comercio aux in s._comercios)
            {
                if(aux is Exportador  && c is Exportador)
                {
                    if((Exportador)aux == (Exportador)c)
                    {
                        retorno = true;
                        break;
                    }
                    continue;
                }
                if (aux is Importador && c is Importador)
                {
                    if ((Importador)aux == (Importador)c)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        public static bool operator !=(Shopping s, Comercio c)
        {
            return !(s == c);
        }

        public static Shopping operator +(Shopping s, Comercio c)
        {
            if (s != c)
            {
                if(s._comercios.Count < s._capacidad)
                {
                    s._comercios.Add(c);
                }
                else
                {
                    Console.WriteLine("NO hay mas lugar en el Shopping!!!");
                }
            }
            else
            {
                Console.WriteLine("El comercio ya esta en el Shopping!!!");
            }
            return s;
        }

        private double ObtenerPrecio(EComercio tipoComercio)
        {
            double retorno = 0;
            switch (tipoComercio)
            {
                case EComercio.Importador:
                    foreach (Comercio aux in this._comercios)
                    {
                        if (aux is Importador)
                        {
                            retorno = retorno + (Importador)aux;
                        }
                    }
                    break;

                case EComercio.Exportador:
                    foreach (Comercio aux in this._comercios)
                    {
                        if (aux is Exportador)
                        {
                            retorno = retorno + (Exportador)aux;
                        }
                    }
                    break;

                case EComercio.Ambos:
                    retorno = this.ObtenerPrecio(EComercio.Importador) + this.ObtenerPrecio(EComercio.Exportador);
                    break;
            }
            return retorno;
        }
    }
}
