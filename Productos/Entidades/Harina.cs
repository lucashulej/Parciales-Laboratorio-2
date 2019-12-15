using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Harina : Producto
    {
        public enum ETipoHarina
        {
            CuatroCeros,
            TresCeros,
            Integral
        }

        private ETipoHarina _tipo;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get
            {
                return this._precio * 0.6f;
            }
        }

        static Harina()
        {
            Harina.DeConsumo = false;
        }

        public Harina(int codigo, float precio, EMarcaProducto marca, ETipoHarina tipo) : base(codigo, marca, precio)
        {
            this._tipo = tipo;
        }

        private string MostrarHarina()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(this);
            retorno.AppendLine("TipoHarina " + this._tipo);
            return retorno.ToString();
        }

        public override string ToString()
        {
            return this.MostrarHarina();
        }
    }
}
