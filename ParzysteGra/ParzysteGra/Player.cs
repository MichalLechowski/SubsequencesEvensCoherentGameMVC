using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParzysteGra
{
    public class Player
    {
        public int[] WybranyPodciagSpojny { get; set; } //jest w Player
        List<int> indexyDoWyrzucenia = new List<int>(); //jest w Player
        public string Name { get; set; } //jest w Player

        public void WybierzLiczby(string wczytajLiczby)
        {
            wczytajLiczby = wczytajLiczby.Trim();
            string[] rozdzielLiczby = wczytajLiczby.Split(' ');

            WybranyPodciagSpojny = new int[rozdzielLiczby.Length];

            for (int i = 0; i < rozdzielLiczby.Length; i++)
            {
                WybranyPodciagSpojny[i] = int.Parse(rozdzielLiczby[i]);
            }
        }  // jest w Player

        public bool SprawdzCzyWybranoPoprawneLiczby(Game gra)
        {
            int suma = 0;

            foreach (var item in WybranyPodciagSpojny) //sumuje wybrany podciąg
            {
                suma += item;
            }

            if (suma % 2 == 0 && !(WybranyPodciagSpojny.Length == gra.tabWylosowaneLiczby.Length))
            //jak podciąg jest parzysty to sprawdza czy został poprawnie wybrany tj. jest też spójny
            //oraz sprawdza czy długość podciągu nie jest równa długości całego ciągu, co by oznaczało,
            //że wybrano cały ciąg, a nie podciąg co jest niedozwolone
            {
                for (int i = 0, j = 0; j < WybranyPodciagSpojny.Length; i++) //przeleć po tablicy wybranego podciagu spojnego
                {
                    if (gra.tabWylosowaneLiczby.Length == i)
                    {
                        gra.czyPoprawneLiczby = false;
                        break;
                    }
                    if (WybranyPodciagSpojny[j] == gra.tabWylosowaneLiczby[i]) //sprawdz czy j-ty el. podciągu jest równy i-ty el. wylosowanych liczb
                    {
                        gra.czyPoprawneLiczby = true; //śledzi poprawność liczb
                        indexyDoWyrzucenia.Add(i); //wrzuć indeks do listy indeksów do wyrzucenia z wylosowanych liczb
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
                            i = indexyDoWyrzucenia.Last();
                            //pobierz ostatni element("index") z listy indeksów do wyrzucenia i ustaw go jako index elementu wylosowanego ciągu
                            //powoduje to, że omijamy element, który był prawidłowy, ale nie był szukany np. wybrany podciąg to 2 2,
                            //a wylosowane liczby to: 2 3 2 2, pierwsza 2 jest poprawna i zostanie wybrana do usunięcia,
                            //ale zostanie wyrzucona (list_clear) i będzie szukana "inna" dwójka, następna w kolejności
                            //z pominięciem tej pierwotnej, inaczej pętla byłaby nieskończona.

                            j = 0;
                            //wróc do pierwszego elementu podciągu jak w toku sprawdzania ciągu wyszło,
                            //że to jednak nie ten podciąg np. 2 3 3 oraz 2 3 2 lub 2 1 oraz 2 2, podbieństwo pierwszych wyrazów podciągów
                        }

                        indexyDoWyrzucenia.Clear();
                        continue;
                    }
                }
            }

            else
            {
                gra.czyPoprawneLiczby = false; //jak podciąg jest niepoprawny, czyli jest parzysty, a nie jest spójny to koniec gry
            }

            if (indexyDoWyrzucenia.Count == 0)
            {
                gra.czyPoprawneLiczby = false;
            }

            return gra.czyPoprawneLiczby;
        } //jest w Game

        public void WyrzucWybraneLiczby(Game gra)
        {
            int[] zredukowanaTablica = new int[gra.tabWylosowaneLiczby.Length - WybranyPodciagSpojny.Length];

            //pętla sprawdza warunek nieprzekroczenia dlugosci tablic
            for (int i = 0, j = 0, k = 0; j < indexyDoWyrzucenia.Count && i < gra.tabWylosowaneLiczby.Length;)
            {

                if (indexyDoWyrzucenia[j] != i) //sprawdzenie czy i NIE jest na liście indeksów do wyrzucenia
                {
                    zredukowanaTablica[k] = gra.tabWylosowaneLiczby[i]; //jak nie jest (true) to dodaj element do nowej tablicy zredukowanej o wybrany podciąg
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
                    if (indexyDoWyrzucenia.Count == j) //jak jest to ostatni indeks do wyrzucenia to zmniejsz go, aby zapobiec wyjściu poza tablice
                    {
                        j--;
                    }
                }
                //nieciekawe rozwiązanie, ale działa. Optymalizacja?
            }
            gra.tabWylosowaneLiczby = zredukowanaTablica; //zamień tablicę wylosowanych liczb na nową, zredukowaną o wybrany podciąg
        } // jest w GameS

        public bool SprawdzCzyMoznaKontynuowac(Game gra)
        {

            int suma = 0;
            int[] tab = gra.tabWylosowaneLiczby;
            if (gra.tabWylosowaneLiczby.Length == 1)
            {
                gra.grajDalej = false;
                return gra.grajDalej;
            }
            else
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    //sprawdzenie pojedynczych liczb, jak jest jakaś parzysta to nie sprawdza dłuższych podciągów, bo nie ma po co
                    if (tab[i] % 2 == 0)
                    {
                        gra.grajDalej = true;
                        goto GameOn;
                    }
                    else
                    {
                        gra.grajDalej = false;
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
                            gra.grajDalej = true;
                            goto GameOn;
                        }
                        else
                        {
                            gra.grajDalej = false;
                            continue;
                        }
                    }
                }

            GameOn:;
                return gra.grajDalej;
            }
        } //jest z Game
    }
}