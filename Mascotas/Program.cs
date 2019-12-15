using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Grupo grupo = new Grupo("***Rio Unica***");
            string lista = "";
            Perro p1 = new Perro("Moro", "Pitbull");
            Perro p2 = new Perro("Julio", "Cruza", 13, false);
            Perro p3 = new Perro("Ramon", "Salchica", 2, true);
            Gato g1 = new Gato("Jose", "Angora");
            Gato g2 = new Gato("Hernan", "Cruza");
            Gato g3 = new Gato("Fer", "Siames");
            grupo += p1;
            grupo += p2;
            grupo += p3;
            grupo += g1;
            grupo += g2;
            grupo += g3;
            lista = grupo;
            Console.WriteLine(lista);
            Console.ReadLine();
        }
    }
}
