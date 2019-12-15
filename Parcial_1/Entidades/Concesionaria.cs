using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Concesionaria
    {
        private int capacidad;
        private List<Vehiculo> vehiculos;

        private Concesionaria()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        private Concesionaria(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }

        public double PrecioDeAutos
        {
            get
            {
                return this.ObtenerPrecio(EVehiculo.PrecioDeAutos);
            }
        }

        public double PrecioDeMotos
        {
            get
            {
                return this.ObtenerPrecio(EVehiculo.PrecioDeMotos);
            }
        }

        public double PrecioTotal
        {
            get
            {
                return this.ObtenerPrecio(EVehiculo.PrecioTotal);
            }
        }

        public static implicit operator Concesionaria(int capacidad)
        {
            return new Concesionaria(capacidad);
        }

        public static string Mostrar(Concesionaria c)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Capacidad " + c.capacidad);
            retorno.AppendFormat("Precio por autos = {0:#,###}\n", c.PrecioDeAutos);
            retorno.AppendFormat("Precio por motos = {0:#,###}\n", c.PrecioDeMotos);
            retorno.AppendFormat("Total = {0:#,###}\n", c.PrecioTotal);
            retorno.AppendLine("******************************************************************************");
            retorno.AppendLine("Listado Vehiculos");
            retorno.AppendLine("******************************************************************************");
            foreach (Vehiculo aux in c.vehiculos)
            {
                retorno.AppendLine(aux.ToString());
                retorno.AppendLine();
            }
            return retorno.ToString();
        }

        

        public static bool operator ==(Concesionaria c, Vehiculo v)
        {
            bool retorno = false;
            foreach (Vehiculo aux in c.vehiculos)
            {
                if (aux is Auto && v is Auto)
                {
                    if ((Auto)aux == (Auto)v)
                    {
                        retorno = true;
                        break;
                    }
                    continue;
                }
                else if (aux is Moto && v is Moto)
                {
                    if ((Moto)aux == (Moto)v)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        public static bool operator !=(Concesionaria c, Vehiculo v)
        {
            return !(c == v);
        }

        public static Concesionaria operator +(Concesionaria c, Vehiculo v)
        {
            if (c != v)
            {
                if (c.vehiculos.Count < c.capacidad)
                {
                    c.vehiculos.Add(v);
                }
                else
                {
                    Console.WriteLine("No hay mas lugar en la concesioanria!!!");
                }
            }
            else
            {
                Console.WriteLine("El vehiculo ya se encuentra en la concesionaria!!!");
            }
            return c;
        }

        private double ObtenerPrecio(EVehiculo tipoVehiculo)
        {
            double retorno = 0d;
            foreach (Vehiculo aux in this.vehiculos)
            {
                switch (tipoVehiculo)
                {
                    case EVehiculo.PrecioDeAutos:
                        if (aux is Auto)
                        {
                            retorno += (Single)(Auto)aux;
                        }
                        break;

                    case EVehiculo.PrecioDeMotos:
                        if (aux is Moto)
                        {
                            retorno += (Moto)aux;
                        }
                        break;

                    case EVehiculo.PrecioTotal:
                        if (aux is Auto)
                        {
                            retorno += (Single)(Auto)aux;
                        }
                        else
                        {
                            retorno += (Moto)aux;
                        }
                        break;
                }
            }
            return retorno;
        }
    }
}
