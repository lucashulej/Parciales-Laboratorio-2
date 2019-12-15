using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Banana : Fruta
    {
        protected string _paisOrigen;

        public Banana()
        {

        }

        public Banana(string color, double peso, string paisOrigen) : base(color, peso)
        {
            this._paisOrigen = paisOrigen;
        }

        public string Nombre
        {
            get
            {
                return "Banana";
            }
        }

        public override bool TieneCarozo
        {
            get
            {
                return false;
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

        public string PaisOrigen
        {
            get
            {
                return this._paisOrigen;
            }
            set
            {
                this._paisOrigen = value;
            }
        }

        protected override string FrutaToString()
        {
            return base.FrutaToString() + "Nombre = " + this.Nombre + "\nPais Origen = " + this._paisOrigen + "\nTiene carozo = " + this.TieneCarozo + "\n";
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }
    }
}
