using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelGraParzysteLib;

namespace GraParzysteConsoleAppMVC
{
    class Widok
    {
        Kontroler kontroler;

        public Widok(Kontroler parent)
        {
            kontroler = parent;
        }

        public void CzyscEkran() => Console.Clear();

        public void WypiszOpisGry()
        {
            Console.WriteLine("Gra polega na wyborze podciągów spójnych parzystych." +
                              "\nPrzegrywa ten kto nie ma dalszych zgodnych ruchów.");
            Console.WriteLine();
        }
    }
}
