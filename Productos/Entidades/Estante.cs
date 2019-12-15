using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estante
    {
        protected sbyte _capacidad;
        protected List<Producto> _productos;

        public float ValorEstanteTotal
        {
            get
            {
                return this.GetValorEstante(Producto.ETipoProducto.Todos);
            }
        }

        private Estante()
        {
            this._productos = new List<Producto>();
        }

        public Estante(sbyte capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public List<Producto> GetProductos()
        {
            return this._productos;
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Capacidad " + e._capacidad);
            foreach (Producto aux in e._productos)
            {
                retorno.AppendLine(aux.ToString());
                retorno.AppendLine();
            }
            return retorno.ToString();
        }

        public static bool operator ==(Estante e, Producto prod)
        {
            bool retorno = false;
            foreach(Producto aux in e._productos)
            {
                if(aux == prod)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Estante e, Producto prod)
        {
            return !(e == prod);
        } 

        public static bool operator +(Estante e, Producto prod)
        {
            bool retorno = false;
            if(e._productos.Count < e._capacidad && e != prod)
            {
                e._productos.Add(prod);
                retorno = true;
            }
            return retorno;
        }

        public static Estante operator -(Estante e, Producto prod)
        {
            if(e == prod)
            {
                e._productos.Remove(prod);
            }
            return e;
        }

        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {
            Producto aux;
            for(int i = 0; i < e._productos.Count; i++)
            {
                aux = e._productos[i];
                switch (tipo)
                {
                    case Producto.ETipoProducto.Galletita:
                        if (aux is Galletita)
                        {
                            e._productos.Remove(aux);
                            i--;
                        }
                        break;

                    case Producto.ETipoProducto.Gaseosa:
                        if (aux is Gaseosa)
                        {
                            e._productos.Remove(aux);
                            i--;
                        }
                        break;

                    case Producto.ETipoProducto.Jugo:
                        if (aux is Jugo)
                        {
                            e._productos.Remove(aux);
                            i--;
                        }
                        break;

                    case Producto.ETipoProducto.Harina:
                        if (aux is Harina)
                        {
                            e._productos.Remove(aux);
                            i--;
                        }
                        break;

                    default:
                        e._productos.Remove(aux);
                        i--;
                        break;
                }
            }
            return e;
        }

        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float retorno = 0;
            foreach(Producto aux in this._productos)
            {
                switch (tipo)
                {
                    case Producto.ETipoProducto.Galletita:
                        if(aux is Galletita)
                        {
                            retorno = retorno + aux.Precio;
                        }
                        break;

                    case Producto.ETipoProducto.Gaseosa:
                        if (aux is Gaseosa)
                        {
                            retorno = retorno + aux.Precio;
                        }
                        break;

                    case Producto.ETipoProducto.Jugo:
                        if (aux is Jugo)
                        {
                            retorno = retorno + aux.Precio;
                        }
                        break;

                    case Producto.ETipoProducto.Harina:
                        if (aux is Harina)
                        {
                            retorno = retorno + aux.Precio;
                        }
                        break;

                    default:
                            retorno = retorno + aux.Precio;
                        break;
                }
            }
            return retorno;
        }


    }
}
