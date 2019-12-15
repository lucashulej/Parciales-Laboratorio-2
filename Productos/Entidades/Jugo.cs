using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo : Producto
    {
        public enum ESaborJugo
        {
            Asqueroso,
            Pasable,
            Rico
        }
        protected ESaborJugo _sabor;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get
            {
                return this._precio * 0.4f;
            }
        }

        static Jugo() 
        {
            Jugo.DeConsumo = true;
        }

        public Jugo(int codigoDeBarra, float precio, EMarcaProducto marca, ESaborJugo sabor) : base(codigoDeBarra, marca, precio)
        {
            this._sabor = sabor;
        }

        private string MostrarJugo()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(this);
            retorno.AppendLine("Sabor " + this._sabor);
            return retorno.ToString();
        }

        public override string ToString()
        {
            return this.MostrarJugo();
        }

        public override string Consumir()
        {
            return base.Consumir() + " Bebible\n";
        }
    }
}
