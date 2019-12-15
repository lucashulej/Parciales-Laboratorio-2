using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Durazno : Fruta
    {
        protected int _cantPelusa;

        public Durazno()
        {

        }

        public Durazno(string color, double peso, int cantPelusa) : base(color, peso)
        {
            this._cantPelusa = cantPelusa;
        }

        public string Nombre
        {
            get
            {
                return "Durazno";
            }
        }

        public override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        public string Color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }

        public double Peso
        {
            get
            {
                return this._peso;
            }
            set
            {
                this._peso = value;
            }
        }

        public int CantPelusa
        {
            get
            {
                return this._cantPelusa;
            }
            set
            {
                this._cantPelusa = value;
            }
        }

        protected override string FrutaToString()
        {
            return base.FrutaToString() + "Nombre = " + this.Nombre + "\nCantidad de pelusa = " + this._cantPelusa + "\nTiene carozo = " + this.TieneCarozo + "\n";
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }
    }
}
