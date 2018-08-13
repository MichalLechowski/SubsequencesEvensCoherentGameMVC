using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelGraParzysteLib;

namespace ModelGraParzysteLib
{
    public class ModelGame
    {
        private int iloscLiczb; //musi być fullprop, bo przekazuje przez out przy TryParse
        private int maxWartosc; //musi być fullprop, bo przekazuje przez out przy TryParse
        public int IloscLiczb { get => iloscLiczb; private set => iloscLiczb = value; }
        public int MaxWartosc { get => maxWartosc; private set => maxWartosc = value; }

        private int[] TabWylosowaneLiczby { get; set; }
        public IList<int> TabWylosowaneLiczbyAsReadOnly => Array.AsReadOnly(TabWylosowaneLiczby);
        public bool CzyWybranoPoprawneLiczbyDoWyrzucenia { get; private set; }
        public bool CzySaJeszczeRuchy { get; private set; }
        public bool CzyWybranoPoprawneLiczbyDoWylosowania { get; private set; }
        public bool CzyWybranoPoprawnaMaxWartoscDoWylosowania { get; private set; }
        public bool CzyWybranoPoprawnaIloscLiczbDoWylosowania { get; private set; }
        public string Wygrany { get; set; }
        public ModelPlayer Gracz1 { get; private set; } = new ModelPlayer();
        public ModelPlayer Gracz2 { get; private set; } = new ModelPlayer();

        public bool WybierzIloscLiczbDoWylosowania(int iloscLiczb)
        {
            this.iloscLiczb = iloscLiczb;
            if (IloscLiczb < 3)
            {
                CzyWybranoPoprawnaIloscLiczbDoWylosowania = false;
            }
            else
            {
                CzyWybranoPoprawnaIloscLiczbDoWylosowania = true;
            }
                return CzyWybranoPoprawnaIloscLiczbDoWylosowania;
        }

        public bool WybierzMaxWartoscLosowanejLiczby(int maxWartosc)
        {
            this.maxWartosc = maxWartosc;
            this.maxWartosc += 1; //trzeba zwiększyć o 1, bo metoda Next klasy Random określa max wartość losowanej liczby, ale bez jej uwzględnienia
            if (MaxWartosc <= 2) //czyli przy np. max wartość 2 losowane liczby będą 0 lub 1.
            {
                CzyWybranoPoprawnaMaxWartoscDoWylosowania = false;
            }
            else
            {
                CzyWybranoPoprawnaMaxWartoscDoWylosowania = true;
            }
            return CzyWybranoPoprawnaMaxWartoscDoWylosowania;
        }

        public void LosujCiag()
        {
            Random rand = new Random();
            TabWylosowaneLiczby = new int[IloscLiczb]; //tablica o długosci rownej ilosc liczb np. 5 elementow to 0,1,2,3,4

            while (IloscLiczb > 0) //przelatuje po wszystkich elementach tablicy
            {
                TabWylosowaneLiczby[iloscLiczb - 1] = rand.Next(MaxWartosc); // iloscLiczb-1, bo dla np. 5 elementowej tab max index 4 i min 0
                iloscLiczb--;
            }
        }

        public void WyrzucWybraneLiczby(ModelPlayer gracz)
        {
            int[] zredukowanaTablica = new int[TabWylosowaneLiczby.Length - gracz.WybranyPodciagSpojny.Length];

            //pętla sprawdza warunek nieprzekroczenia dlugosci tablic
            for (int i = 0, j = 0, k = 0; j < gracz.indexyDoWyrzucenia.Count && i < TabWylosowaneLiczby.Length;)
            {

                if (gracz.indexyDoWyrzucenia[j] != i) //sprawdzenie czy i NIE jest na liście indeksów do wyrzucenia
                {
                    zredukowanaTablica[k] = TabWylosowaneLiczby[i]; //jak nie jest (true) to dodaj element do nowej tablicy zredukowanej o wybrany podciąg
                    if (k == zredukowanaTablica.Length - 1) //jeżeli index zredukowanej tab jest na końcu to nie zwiększaj go
                    {
                        //można to zrobić ze sprawdzeniem negacji warunku, na to samo wyjdzie
                    }
                    else
                    {
                        k++; //jak nie jest to przejdź do kolejnego wiersza, bo widocznie jeszcze są elementy ciągu do dodania
                    }
                    i++; //przeskocz do następnego elementu wylosowanych liczb (tabWylosowaneLiczby)
                }
                else //wykonaj jak index i znajduje się na liście indexów do wyrzucenia
                {
                    j++; //przeskocz do następnego indeksu do wyrzucenia
                    i++; //przejdź do następnego elementu wylosowanych liczb
                    if (gracz.indexyDoWyrzucenia.Count == j) //jak jest to ostatni indeks do wyrzucenia to zmniejsz go, aby zapobiec wyjściu poza tablice
                    {
                        j--;
                    }
                }
                //nieciekawe rozwiązanie, ale działa. Optymalizacja?
            }
            TabWylosowaneLiczby = zredukowanaTablica; //zamień tablicę wylosowanych liczb na nową, zredukowaną o wybrany podciąg
        }

        public bool SprawdzCzyWybranoPoprawneLiczby(ModelPlayer gracz)
        {
            int suma = 0;

            foreach (var item in gracz.WybranyPodciagSpojny) //sumuje wybrany podciąg
            {
                suma += item;
            }

            if (suma % 2 == 0 && !(gracz.WybranyPodciagSpojny.Length == TabWylosowaneLiczby.Length))
            //jak podciąg jest parzysty to sprawdza czy został poprawnie wybrany tj. jest też spójny
            //oraz sprawdza czy długość podciągu nie jest równa długości całego ciągu, co by oznaczało,
            //że wybrano cały ciąg, a nie podciąg co jest niedozwolone
            {
                for (int i = 0, j = 0; j < gracz.WybranyPodciagSpojny.Length; i++) //przeleć po tablicy wybranego podciagu spojnego
                {
                    if (TabWylosowaneLiczby.Length == i)
                    {
                        CzyWybranoPoprawneLiczbyDoWyrzucenia = false;
                        break;
                    }

                    if (gracz.WybranyPodciagSpojny[j] == TabWylosowaneLiczby[i]) //sprawdz czy j-ty el. podciągu jest równy i-ty el. wylosowanych liczb
                    {
                        CzyWybranoPoprawneLiczbyDoWyrzucenia = true; //śledzi poprawność liczb
                        gracz.indexyDoWyrzucenia.Add(i); //wrzuć indeks do listy indeksów do wyrzucenia z wylosowanych liczb
                        j++; //przejdź do następnego elementu podciągu
                    }

                    else
                    {
                        if (j == 0) //zabezpieczenie, jeśli jestesmy na 1 elemencie podciągu to pozostań na nim, inaczej byłby index -1 = err
                        {
                            //nic nie rób :=D
                        }
                        else
                        {
                            i = gracz.indexyDoWyrzucenia.Last();
                            //pobierz ostatni element("index") z listy indeksów do wyrzucenia i ustaw go jako index elementu wylosowanego ciągu
                            //powoduje to, że omijamy element, który był prawidłowy, ale nie był szukany np. wybrany podciąg to 2 2,
                            //a wylosowane liczby to: 2 3 2 2, pierwsza 2 jest poprawna i zostanie wybrana do usunięcia,
                            //ale zostanie wyrzucona (list_clear) i będzie szukana "inna" dwójka, następna w kolejności
                            //z pominięciem tej pierwotnej, inaczej pętla byłaby nieskończona.

                            j = 0;
                            //wróc do pierwszego elementu podciągu jak w toku sprawdzania ciągu wyszło,
                            //że to jednak nie ten podciąg np. 2 3 3 oraz 2 3 2 lub 2 1 oraz 2 2, podbieństwo pierwszych wyrazów podciągów
                        }

                        gracz.indexyDoWyrzucenia.Clear();
                        continue;
                    }
                }
            }

            else
            {
                CzyWybranoPoprawneLiczbyDoWyrzucenia = false; //jak podciąg jest niepoprawny, czyli jest parzysty, a nie jest spójny to koniec gry
            }

            if (gracz.indexyDoWyrzucenia.Count == 0)
            {
                CzyWybranoPoprawneLiczbyDoWyrzucenia = false;
            }

            return CzyWybranoPoprawneLiczbyDoWyrzucenia;
        }

        public bool SprawdzCzyMoznaKontynuowac(ModelPlayer gracz)
        {
            int suma = 0;
            int[] tab = TabWylosowaneLiczby;
            if (TabWylosowaneLiczby.Length == 1)
            {
                CzySaJeszczeRuchy = false;
                return CzySaJeszczeRuchy;
            }
            else
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    //sprawdzenie pojedynczych liczb, jak jest jakaś parzysta to nie sprawdza dłuższych podciągów, bo nie ma po co
                    if (tab[i] % 2 == 0)
                    {
                        CzySaJeszczeRuchy = true;
                        goto GameOn;
                    }
                    else
                    {
                        CzySaJeszczeRuchy = false;
                        continue;
                    }
                }

                //przelatuje po tablicy od 0 do przedostatniego elementu (Length -2), ostatni nie będzie miał już nic po prawej stronie,
                //więc nie utworzy się żaden podciąg, a pojedynczej liczby nie sprawdzamy, bo sprawdziliśmy to wcześniej
                for (int i = 0; i < tab.Length - 2; i++)
                {
                    suma = 0; //wyzeruj sume po przejściu do tworzenia kolejnych podciągów zaczynająć od kolejnego elementu tablicy (przesuwamy się o 1 w prawo)
                    suma += tab[i]; //dodaj wartość tego elementu do sumy (jednorazowo, więć musi być przed wewnętrznym for)
                    for (int j = i + 1; j < tab.Length - 1 + (i == 0 ? +0 : +1); j++)
                    // :=D Yyy, dodawanie do sumy kolejnych wyrazów po prawo od 'i' tworząc podciągi najpierw 2-el, 3-el itd.
                    // aż do elementu PRZEDostatniego w przypadku gdy i=0, ponieważ wtedy byłby to cały ciąg, a nie podciąg!
                    // lub aż do elementu ostatniego gdy i != 0, wtedy można iterować do końca.
                    // do sprawdzenia wartości i wykorzystano wyrażenie trójargumentowe condition ? true_expression : false_expression
                    // co sumowanie sprawdzenie czy podciąg nie jest parzysty, jak jest to kończymy i gramy dalej,
                    // bo jest jeszcze co wybierać.
                    {
                        if ((suma += tab[j]) % 2 == 0)
                        {
                            CzySaJeszczeRuchy = true;
                            goto GameOn;
                        }
                        else
                        {
                            CzySaJeszczeRuchy = false;
                            continue;
                        }
                    }
                }
                GameOn:;
                return CzySaJeszczeRuchy;
            }
        }
    }
}