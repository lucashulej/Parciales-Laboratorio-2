using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        public enum EMarcaProducto
        {
            Manaos,
            Pitusas,
            Naranju,
            Diversion,
            Swift,
            Favorita
        }

        public enum ETipoProducto
        {
            Galletita,
            Gaseosa,
            Jugo,
            Harina,
            Todos
        }

        protected int _codigoDeBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        public abstract float CalcularCostoDeProduccion
        {
            get;
        }
      

        public EMarcaProducto Marca
        {
            get
            {
                return this._marca;
            }
        }

        public float Precio
        {
            get
            {
                return this._precio;
            }
        }

        public Producto(int codigoDeBarra, EMarcaProducto marca, float precio)
        {
            this._codigoDeBarra = codigoDeBarra;
            this._marca = marca;
            this._precio = precio;
        }

        private static string MostrarProducto(Producto p)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Marca " + p._marca);
            retorno.AppendLine("Precio " + p._precio);
            retorno.AppendLine("Codigo de Barra " + p._codigoDeBarra);
            return retorno.ToString();
        }

        public static bool operator ==(Producto a, Producto b)
        {
            bool retorno = false;
            if (a.Equals(b) && a._marca == b._marca && a._codigoDeBarra == b._codigoDeBarra)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Producto a, Producto b)
        {
            return !(a == b);
        }

        public static bool operator ==(Producto a, EMarcaProducto marca)
        {
            bool retorno = false;
            if (a._marca == marca)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Producto a, EMarcaProducto marca)
        {
            return !(a == marca);
        }

        public static explicit operator int(Producto a)
        {
            return a._codigoDeBarra;
        }

        public static implicit operator string(Producto a)
        {
            return Producto.MostrarProducto(a);
        }

        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();    
        }

        public virtual string Consumir()
        {
            return "Parte de una mezcla";
        }
    }
}
