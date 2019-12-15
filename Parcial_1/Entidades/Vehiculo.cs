using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        protected Fabricante fabricante;
        protected static Random generadorDeVelocidades;
        protected string modelo;
        protected float precio;
        protected int velocidadMaxima;

        public int VelocidadMaxima
        {
            get
            {
                if(this.velocidadMaxima == 0)
                {
                    this.velocidadMaxima = Vehiculo.generadorDeVelocidades.Next(100, 280);
                }
                return this.velocidadMaxima;
            }        
        }

        static Vehiculo()
        {
            Vehiculo.generadorDeVelocidades = new Random();
        }

        public Vehiculo(float precio, string modelo, Fabricante fabri)
        {
            this.precio = precio;
            this.modelo = modelo;
            this.fabricante = fabri;
        }

        public Vehiculo(string marca, EPais pais, string modelo, float precio) : this(precio, modelo, new Fabricante(marca, pais))
        {

        }

        private static string Mostrar(Vehiculo v)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(v.fabricante);
            retorno.AppendLine("MODELO: " + v.modelo);
            retorno.AppendLine("VELOCIDAD MAXIMA: " + v.VelocidadMaxima.ToString());
            retorno.AppendFormat("PRECIO: {0:#,###}\n",v.precio);
            return retorno.ToString();
        }

        public static bool operator ==(Vehiculo a, Vehiculo b)
        {
            bool retorno = false;
            if(a.modelo == b.modelo && a.fabricante == b.fabricante)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Vehiculo a, Vehiculo b)
        {
            return !(a == b);
        }

        public static explicit operator string(Vehiculo v)
        {
            return Vehiculo.Mostrar(v);
        }
    }
}
