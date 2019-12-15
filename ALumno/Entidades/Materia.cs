using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Materia
    {
        private List<Alumno> _alumnos;
        private EMateria _nombre;
        private static Random _notaParaUnAlumno;

        static Materia()
        {
            Materia._notaParaUnAlumno = new Random();
        }

        private Materia()
        {
            this._alumnos = new List<Alumno>();
        }

        private Materia(EMateria nombre) : this()
        {
            this._nombre = nombre;
        }

        private string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("\nMATERIA = " + this._nombre);
            retorno.AppendLine("******************************");
            retorno.AppendLine("***********ALUMNOS************");
            retorno.AppendLine("******************************");
            foreach (Alumno aux in this._alumnos)
            {
                retorno.AppendLine(Alumno.Mostrar(aux) + "\n");
            }
            return retorno.ToString();
        }

        public void CalificarAlumnos()
        {
            foreach(Alumno aux in this._alumnos)
            { 
                aux.Nota = Materia._notaParaUnAlumno.Next(1, 10);
            }
        }

        public static explicit operator String(Materia materia)
        {
            return materia.Mostrar();
        }

        public static implicit operator Materia(EMateria nombre)
        {
            return new Materia(nombre);
        }

        public static explicit operator float (Materia m)
        {
            float retorno = 0;
            foreach(Alumno aux in m._alumnos)
            {
                retorno = retorno + aux.Nota;
            }
            retorno = retorno / m._alumnos.Count;
            return retorno;
        }

        public static bool operator ==(Materia m, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno aux in m._alumnos)
            {
                if (aux == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public static bool operator !=(Materia m, Alumno a)
        {
            return !(m == a);
        }

        public static Materia operator +(Materia m, Alumno a)
        {
            if(m != a)
            {
                m._alumnos.Add(a);
                Console.WriteLine("El alumno se agrego a la materia {0}", m._nombre);
            }
            else
            {
                Console.WriteLine("El alumno ya esta en la materia {0}", m._nombre);
            }
            return m;
        }

        public static Materia operator -(Materia m, Alumno a)
        {
            if (m == a)
            {
                m._alumnos.Remove(a);
                Console.WriteLine("El alumno se quito de la materia {0}", m._nombre);
            }
            else
            {
                Console.WriteLine("El alumno no esta en la materia {0}", m._nombre);
            }
            return m;
        }
    }
}