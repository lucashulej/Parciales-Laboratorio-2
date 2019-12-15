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
    public class Cajon<T> : ISerealizar
    {
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;

        public delegate void delegadoPrecio(Object sender);
        public event delegadoPrecio EventoPrecio;

        public List<T> Elementos
        {
            get
            {
                return this._elementos;
            }
            set
            {
                this._elementos = value;
            }
        }

        public double PrecioTotal
        {
            get
            {
                return this._precioUnitario * this._elementos.Count;
            }
        }

        public double PrecioUnitario
        {
            get
            {
                return this._precioUnitario;
            }
            set
            {
                this._precioUnitario = value;
            }
        }


        public int Capacidad
        {
            get
            {
                return this._capacidad;
            }
            set
            {
                this._capacidad = value;
            }
        }

        public Cajon()
        {
            this._elementos = new List<T>();
        }

        public Cajon(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(double precioUnitario, int capacidad) : this(capacidad)
        {
            this._precioUnitario = precioUnitario;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno = retorno + "Capacidad = " + this._capacidad + "\nCantidad elementos = " + this._elementos.Count + "\nPrecio Total = " + this.PrecioTotal + "\n";
            foreach (T item in this._elementos)
            {
                retorno = retorno + item.ToString();
            }
            return retorno;
        }

        public static Cajon<T> operator +(Cajon<T> cajon, T elemento)
        {
            if(cajon._elementos.Count < cajon._capacidad)
            {
                cajon._elementos.Add(elemento);
            }
            else
            {
                throw new CajonLlenoException("No hay mas lugar en el cajon");
            }
            if(cajon.PrecioTotal > 55)
            {
                cajon.EventoPrecio(cajon);
            }
            return cajon;
        }

        public bool Xml(string path)
        {
            bool retorno = false;

            try
            {
                XmlSerializer archivo = new XmlSerializer(typeof(Cajon<T>));
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
    }
}
