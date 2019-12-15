using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita : Producto
    {
        protected float _peso;
        protected static bool DeConsumo;

        public override float CalcularCostoDeProduccion
        {
            get
            {
                return this._precio * 0.33f;
            }
        }

        static Galletita()
        {
            Galletita.DeConsumo = true;
        }

        public Galletita(int codigoDeBarra, float precio, EMarcaProducto marca, float peso) : base(codigoDeBarra, marca, precio)
        {
            this._peso = peso;
        }

        private static string MostrarGalletita(Galletita g)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(g);
            retorno.AppendLine("Peso " + g._peso);
            return retorno.ToString();
        }

        public override string ToString()
        {
            return Galletita.MostrarGalletita(this);
        }

        public override string Consumir()
        {
            return base.Consumir() + " Comestible\n";
        }

       
    }
}
