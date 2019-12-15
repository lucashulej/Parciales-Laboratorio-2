using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comercio
    {
        protected int _cantidadDeEmpleados;
        protected Comerciante _comerciante;
        protected static Random _generdorDeEmpleados;
        protected string _nombre;
        protected float _precioAlquiler;

        public int CantidadDeEmpleados
        {
            get
            {
                if(this._cantidadDeEmpleados == 0)
                {
                    this._cantidadDeEmpleados = Comercio._generdorDeEmpleados.Next(1, 100);
                }
                return this._cantidadDeEmpleados;
            }
        }

        static Comercio()
        {
            Comercio._generdorDeEmpleados = new Random();
        }

        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler) 
        {
            this._nombre = nombre;
            this._precioAlquiler = precioAlquiler;
            this._comerciante = comerciante;
        }

        public Comercio(float precio_alquiler, string nombreComercio, string nombre, string apellido) : this(nombreComercio, new Comerciante(nombre, apellido), precio_alquiler)
        {

        }

        private static string Mostrar(Comercio c)
        {
            string retorno = "";
            retorno = c._comerciante + "Nombre " + c._nombre + "\nAlquiler " + c._precioAlquiler + "\nEmpleados " + c.CantidadDeEmpleados;
            return retorno;
        }

        public static bool operator ==(Comercio a, Comercio b)
        {
            bool retorno = false;
            if (a._comerciante == b._comerciante && a._nombre == b._nombre)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Comercio a, Comercio b)
        {
            return !(a == b);
        }

        public static implicit operator string(Comercio a)
        {
            string retorno = "";
            retorno = Comercio.Mostrar(a);   
            return retorno;
        }
    }
}
