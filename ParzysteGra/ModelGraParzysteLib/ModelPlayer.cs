using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGraParzysteLib
{
    public class ModelPlayer
    {
        public int[] WybranyPodciagSpojny { get; set; }
        public List<int> indexyDoWyrzucenia = new List<int>();
        public string Name { get; set; }
        public bool PodciagCheck { get; set; }

        public void WybierzLiczby(string wczytajLiczby)
        {
            wczytajLiczby = wczytajLiczby.Trim();
            string[] rozdzielLiczby = wczytajLiczby.Split(' ');

            WybranyPodciagSpojny = new int[rozdzielLiczby.Length];

            for (int i = 0; i < rozdzielLiczby.Length; i++)
            {
                WybranyPodciagSpojny[i] = int.Parse(rozdzielLiczby[i]);
            }
        }
    }
}
