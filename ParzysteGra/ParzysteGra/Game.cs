using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzysteGra
{
    public class Game
    {
        private int iloscLiczb; //jest w Game
        public int IloscLiczb
        {
            get { return iloscLiczb; }
            set { iloscLiczb = value; }
        }

        private int maxWartosc; //jest w Game
        public int MaxWartosc
        {
            get { return maxWartosc; }
            set { maxWartosc = value; }
        }


        public int[] tabWylosowaneLiczby { get; set; } //jest w Game
        public Player gracz1 { get; set; } = new Player(); //jest w Game
        public Player gracz2 { get; set; } = new Player(); //jest w Game
        public bool grajDalej { get; set; } //jest w Game jako czySaJeszczeRuchy
        public bool czyPoprawneLiczby { get; set; } //jest w Game jako czyWybranoPoprawneLiczby
        public string wygrany { get; set; } //jest w Game


        bool liczbyDoWylosowaniaCheck = false;  //jest w Game jako czyWybranoPoprawneLiczbyDoWylosowania
        bool maxWartoscLiczbyCheck = false;
        bool gracz1PodciagCheck = false;
        bool gracz2PodciagCheck = false;    

        public void Run()
        {
            Game gra = new Game();
            Console.WriteLine("Witaj w grze, podaj nick gracza nr 1: ");
            gracz1.Name = Console.ReadLine();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Podaj nick gracza nr 2: ");
            gracz2.Name = Console.ReadLine();
            Console.WriteLine("----------------------------------------------------------------");

            //jest w metodzie losuj w Game
            while (!liczbyDoWylosowaniaCheck) 
            {
                Console.WriteLine("Podaj ilość liczb do wylosowania. Minimum 3 liczby.");
                liczbyDoWylosowaniaCheck = int.TryParse(Console.ReadLine(), out iloscLiczb); //parsuje do inta aż się uda, czyli aż zostanie podana poprawna wartość
                if (iloscLiczb < 3)
                {
                    liczbyDoWylosowaniaCheck = false;
                }
                Console.WriteLine("----------------------------------------------------------------");
            }

            //jest w metodzie losuj w Game
            while (!maxWartoscLiczbyCheck) 
            {
                Console.WriteLine("Podaj max wartość losowanej liczby");
                maxWartoscLiczbyCheck = int.TryParse(Console.ReadLine(), out maxWartosc);
                maxWartosc += 1; //trzeba zwiększyć o 1, bo metoda Next klasy Random określa max wartość losowanej liczby, ale bez jej uwzględnienia
                if (maxWartosc < 2) //czyli przy np. max wartość 2 losowane liczby będą 0 lub 1.
                {
                    maxWartoscLiczbyCheck = false;
                }
                Console.WriteLine("----------------------------------------------------------------");
            }

            Console.WriteLine("Wylosowany ciąg: ");
            gra.LosujLiczby(IloscLiczb, MaxWartosc); //losuje liczby na podstawie parametrów
            //gra.tabWylosowaneLiczby = new int[] { 1, 1, 2, 1, 3 }; //opcjonalne do podania liczb z ręki
            
            do
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("{0}: Wybierz podciąg spójny, parzysty. Liczby oddziel spacją.", gracz1.Name);
                string liczbyGracz1 = "";
                //int result = 0; //pomocnicza zmienna do sprawdzenia czy wprowadzono liczby -> inicjalizacja możliwa w TryParse
                gracz1PodciagCheck = false; //przechowuje info o poprawności formatu danych
                while (!gracz1PodciagCheck)
                {
                    liczbyGracz1 = Console.ReadLine(); //wczytaj wybór gracza 1
                    if (int.TryParse(liczbyGracz1.Replace(" ", string.Empty), out int result)) //jeśli po usunięciu przerw w stringu, da się sparsować na inta to znaczy, że wpisano same liczby. Clever :D
                    {
                        gracz1PodciagCheck = true; //same liczby, zwróć info o poprawnych danych
                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine("Nieprawidłowy format danych. Wpisz tylko liczby całkowite oddzielone spacją.");
                    }
                }

                gracz1.WybierzLiczby(liczbyGracz1);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Wybrano liczby: " + liczbyGracz1);
                Console.WriteLine("----------------------------------------------------------------");
                gracz1.SprawdzCzyWybranoPoprawneLiczby(gra);
                gracz1.WyrzucWybraneLiczby(gra);
                Console.WriteLine("Aktualna postać ciągu: ");
                foreach (var item in gra.tabWylosowaneLiczby) //wypisuje nowy ciąg po redukcji o wybrany podciąg
                {
                    Console.WriteLine(item + " ");
                }
                Console.WriteLine("----------------------------------------------------------------");

                if (!(gracz1.SprawdzCzyMoznaKontynuowac(gra))) //sprawdza czy są jeszcze dopuszczalne ruchy w grze
                {
                    gra.wygrany = gracz1.Name;
                }


                if (gra.grajDalej && gra.czyPoprawneLiczby) //jeśli są jeszcze ruchy i gracz1 wybrał poprawne liczby to przejdź do 2 gracza
                {

                    Console.WriteLine("{0}: Wybierz podciąg spójny, parzysty. Liczby oddziel spacją.", gracz2.Name);
                    string liczbyGracz2 = "";
                    int result1 = 0;
                    gracz2PodciagCheck = false;
                    while (!gracz2PodciagCheck)
                    {
                        liczbyGracz2 = Console.ReadLine();
                        if (int.TryParse(liczbyGracz2.Replace(" ", string.Empty), out result1))
                        {
                            gracz2PodciagCheck = true;
                        }
                        else
                        {
                            Console.WriteLine("----------------------------------------------------------------");
                            Console.WriteLine("Nieprawidłowy format danych. Wpisz tylko liczby całkowite oddzielone spacją.");
                        }
                    }

                    gracz2.WybierzLiczby(liczbyGracz2);
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Wybrano liczby: " + liczbyGracz2);
                    Console.WriteLine("----------------------------------------------------------------");
                    gracz2.SprawdzCzyWybranoPoprawneLiczby(gra);
                    gracz2.WyrzucWybraneLiczby(gra);
                    Console.WriteLine("Aktualne wartości ciągu do wyboru: ");
                    foreach (var item in gra.tabWylosowaneLiczby)
                    {
                        Console.WriteLine(item + " ");
                    }
                    Console.WriteLine("----------------------------------------------------------------");
                    if (!(gracz2.SprawdzCzyMoznaKontynuowac(gra)))
                    {
                        gra.wygrany = gracz2.Name;
                    }
                }


            } while (gra.czyPoprawneLiczby && gra.grajDalej); //powtarzaj dopóki wprowadzane są poprawne liczby oraz są dalsze ruchy

            if (gra.czyPoprawneLiczby == false)
            { //wyrzuca błąd kiedy wartości są błędne np. nieparzyste, niespójne, w ogóle nie istnieją itp.
                gra.wygrany = "Przegrałeś, wybrany podciąg nie spełnia warunków.";
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("KONIEC GRY: " + gra.wygrany.ToUpper());
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Czy chcesz zagrać ponownie T/N?");
                string repeat = "";
                repeat = Console.ReadLine();
                if (repeat.ToUpper() == "T")
                {
                    Console.Clear();
                    gra.Run();
                }
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("KONIEC GRY, WYGRYWA: " + gra.wygrany.ToUpper());
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Czy chcesz zagrać ponownie T/N?");
                string repeat = "";
                repeat = Console.ReadLine();
                if (repeat.ToUpper() == "T")
                {
                    Console.Clear();
                    gra.Run();
                }
            }
        }

        public void LosujLiczby(int iloscLiczb, int maxWartosc) //losuje liczby na podstawie podanej ilosci i wartosci max
        {
            Random rand = new Random();
            tabWylosowaneLiczby = new int[iloscLiczb]; //tablica o długosci rownej ilosc liczb np. 5 elementow to 0,1,2,3,4

            while (iloscLiczb > 0) //przelatuje po wszystkich elementach tablicy
            {
                tabWylosowaneLiczby[iloscLiczb - 1] = rand.Next(maxWartosc); // iloscLiczb-1, bo dla np. 5 elementowej tab max index 4 i min 0
                iloscLiczb--;
            }

            string wylosowaneLiczby = "";

            for (int i = 0; i < tabWylosowaneLiczby.Length; i++)
            {
                wylosowaneLiczby += tabWylosowaneLiczby[i] + " ";
            } //widok kontroler?

            Console.WriteLine(wylosowaneLiczby.ToString());  //widok kontroler?
        }
    }
}
