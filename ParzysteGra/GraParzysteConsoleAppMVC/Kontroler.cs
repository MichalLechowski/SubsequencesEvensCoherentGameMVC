using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelGraParzysteLib;

namespace GraParzysteConsoleAppMVC
{
    class Kontroler
    {
        private ModelGame gra;
        private Widok widok;

        public Kontroler()
        {
            widok = new Widok(this);
            gra = new ModelGame();
        }

        public void Run()
        {
            widok.CzyscEkran();
            widok.WypiszOpisGry();
            Rozgrywka();
        }

        private void Rozgrywka()
        {
            ModelGame gra = new ModelGame();
            int iloscLiczb;
            int maxWartosc;

            Console.WriteLine("Witaj w grze.\nPodaj nick gracza nr 1: ");
            gra.Gracz1.Name = Console.ReadLine();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Podaj nick gracza nr 2: ");
            gra.Gracz2.Name = Console.ReadLine();
            Console.WriteLine("----------------------------------------------------------------");

            while (!(gra.CzyWybranoPoprawnaIloscLiczbDoWylosowania))
            {
                Console.WriteLine("Podaj ilość liczb do wylosowania. Minimum 3 liczby.");
                while (!(Int32.TryParse(Console.ReadLine(), out iloscLiczb)))
                {
                    Console.WriteLine("Niepoprawna wartość! Wpisz liczbę o wartości minimum 3.");
                }
                gra.WybierzIloscLiczbDoWylosowania(iloscLiczb);
                Console.WriteLine("----------------------------------------------------------------");
            }

            while (!(gra.CzyWybranoPoprawnaMaxWartoscDoWylosowania))
            {
                Console.WriteLine("Podaj max wartość losowanej liczby. Minimum liczba 2.");
                while (!(Int32.TryParse(Console.ReadLine(), out maxWartosc)))
                {
                    Console.WriteLine("Niepoprawna wartość! Wpisz liczbę o wartości minimum 2.");
                }
                gra.WybierzMaxWartoscLosowanejLiczby(maxWartosc);
                Console.WriteLine("----------------------------------------------------------------");
            }

            gra.LosujCiag();

            Console.WriteLine("Wylosowany ciąg: ");
            foreach (var item in gra.TabWylosowaneLiczbyAsReadOnly)
            {
                Console.WriteLine(item);
            }

            do
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("{0}: Wybierz podciąg spójny, parzysty. Liczby oddziel spacją.", gra.Gracz1.Name);
                string liczbyGracz1 = "";
                gra.Gracz1.PodciagCheck = false; //przechowuje info o poprawności formatu danych
                while (!gra.Gracz1.PodciagCheck)
                {
                    liczbyGracz1 = Console.ReadLine(); 
                    if (int.TryParse(liczbyGracz1.Replace(" ", string.Empty), out int result)) //jeśli po usunięciu przerw w stringu, da się sparsować na inta to znaczy, że wpisano same liczby. Clever :D
                    {
                        gra.Gracz1.PodciagCheck = true; //same liczby, zwróć true, info o poprawnych danych
                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine("Nieprawidłowy format danych. Wpisz tylko liczby całkowite oddzielone spacją.");
                    }
                }

                gra.Gracz1.WybierzLiczby(liczbyGracz1);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Wybrano liczby: " + liczbyGracz1);
                Console.WriteLine("----------------------------------------------------------------");
                gra.SprawdzCzyWybranoPoprawneLiczby(gra.Gracz1);
                gra.WyrzucWybraneLiczby(gra.Gracz1);
                Console.WriteLine("Aktualna postać ciągu: ");
                
                foreach (var item in gra.TabWylosowaneLiczbyAsReadOnly) //zredukowany ciąg
                {
                    Console.WriteLine(item + " ");
                }
                Console.WriteLine("----------------------------------------------------------------");

                if (!(gra.SprawdzCzyMoznaKontynuowac(gra.Gracz1)))
                {
                    gra.Wygrany = gra.Gracz1.Name;
                }


                if (gra.CzySaJeszczeRuchy && gra.CzyWybranoPoprawneLiczbyDoWyrzucenia)
                {
                    Console.WriteLine("{0}: Wybierz podciąg spójny, parzysty. Liczby oddziel spacją.", gra.Gracz2.Name);
                    string liczbyGracz2 = "";
                    int result1 = 0;
                    gra.Gracz2.PodciagCheck = false;
                    while (!gra.Gracz2.PodciagCheck)
                    {
                        liczbyGracz2 = Console.ReadLine();
                        if (int.TryParse(liczbyGracz2.Replace(" ", string.Empty), out result1))
                        {
                            gra.Gracz2.PodciagCheck = true;
                        }
                        else
                        {
                            Console.WriteLine("----------------------------------------------------------------");
                            Console.WriteLine("Nieprawidłowy format danych. Wpisz tylko liczby całkowite oddzielone spacją.");
                        }
                    }

                    gra.Gracz2.WybierzLiczby(liczbyGracz2);
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Wybrano liczby: " + liczbyGracz2);
                    Console.WriteLine("----------------------------------------------------------------");
                    gra.SprawdzCzyWybranoPoprawneLiczby(gra.Gracz2);
                    gra.WyrzucWybraneLiczby(gra.Gracz2);
                    Console.WriteLine("Aktualne wartości ciągu do wyboru: ");
                    foreach (var item in gra.TabWylosowaneLiczbyAsReadOnly)
                    {
                        Console.WriteLine(item + " ");
                    }
                    Console.WriteLine("----------------------------------------------------------------");
                    if (!(gra.SprawdzCzyMoznaKontynuowac(gra.Gracz2)))
                    {
                        gra.Wygrany = gra.Gracz2.Name;
                    }
                }
            } while (gra.CzyWybranoPoprawneLiczbyDoWyrzucenia && gra.CzySaJeszczeRuchy);

            if (gra.CzyWybranoPoprawneLiczbyDoWyrzucenia == false)
            { //wyrzuca błąd kiedy wartości są błędne np. nieparzyste, niespójne, w ogóle nie istnieją
                gra.Wygrany = "Przegrałeś! \nWybrany podciąg nie spełnia warunków: parzystości, spójności lub nie istnieje.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("KONIEC GRY: " + gra.Wygrany.ToUpper());
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Czy chcesz zagrać ponownie T/N?");
                string repeat = "";
                repeat = Console.ReadLine();
                if (repeat.ToUpper() == "T")
                {
                    Console.Clear();
                    Run();
                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("KONIEC GRY, WYGRYWA: " + gra.Wygrany.ToUpper());
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Czy chcesz zagrać ponownie T/N?");
                string repeat = "";
                repeat = Console.ReadLine();
                if (repeat.ToUpper() == "T")
                {
                    Console.Clear();
                    Run();
                }
            }
        }
    }
}