using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa : Producto
    {
        protected float _litros;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get
            {
                return this._precio * 0.42f;
            }
        }

        static Gaseosa()
        {
            Gaseosa.DeConsumo = true;
        }

        public Gaseosa(int codigoDeBarra, float precio, EMarcaProducto marca, float litros) : base(codigoDeBarra, marca, precio)
        {
            this._litros = litros;
        }

        public Gaseosa(Producto p, float litros) : this((int)p, p.Precio, p.Marca, litros) 
        {

        }

        private string MostrarGaseosa()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(this);
            retorno.AppendLine("Litros " + this._litros);
            return retorno.ToString();
        }

        public override string ToString()
        {
            return this.MostrarGaseosa();
        }

        public override string Consumir()
        {
            return base.Consumir() + " Bebible\n";
        }
    }
}
