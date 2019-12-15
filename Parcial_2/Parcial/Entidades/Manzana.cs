using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Manzana : Fruta, ISerealizar, IDeserilizar
    {
        protected string _provinciaOrigen;

        public Manzana()
        {

        }

        public Manzana(string color, double peso, string pronvinciaOrigen) : base(color, peso)
        {
            this._provinciaOrigen = pronvinciaOrigen;
        }

        public string Nombre
        {
            get
            {
                return "Manzana";
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

        public string ProvinciaDeOrigen
        {
            get
            {
                return this._provinciaOrigen;
            }
            set
            {
                this._provinciaOrigen = value;
            }
        }

        protected override string FrutaToString()
        {
            return base.FrutaToString() + "Nombre = " + this.Nombre +"\nPronvincia Origen = " + this._provinciaOrigen + "\nTiene carozo = " + this.TieneCarozo + "\n";
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }

        public bool Xml(string path)
        {
            bool retorno = false;

            try
            {
                XmlSerializer archivo = new XmlSerializer(typeof(Manzana));
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + path))
                {
                    archivo.Serialize(writer, this);
                    retorno = true;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error de Xml", e);
            }
            
            return retorno;
        }

        bool IDeserilizar.Xml(string path, out Fruta fruta)
        {
            bool retorno = false;
            fruta = default(Fruta);

            try
            {
                XmlSerializer archivo = new XmlSerializer(typeof(Manzana));
                using (StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + path))
                {
                    fruta = (Manzana)archivo.Deserialize(reader);
                    retorno = true;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Error de Xml", e);
            }

            return retorno;

        }
    }
}
