using club_support_project_2021_Csharp.pl.dowhankuniewski.czlonkowie;
using club_support_project_2021_Csharp.pl.dowhankuniewski.mapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace club_support_project_2021_Csharp.pl.dowhankuniewski.stworzliste {
    /*
     * Klasa 'StworzListeCzlonek' odpowiedzialna za utworzenie list obiektów członków klubów.
     */
    public class StworzListeCzlonek {
        /* Ilość członków danego klubu. */
        private readonly int iloscCzlonkow;

        /*
         * Konstruktor obiektu 'StworzListeCzlonek'.
         * @param iloscCzlonkow Ilość członków danego klubu.
         * @see StworzListeCzlonek
         */
        public StworzListeCzlonek(int iloscCzlonkow) {
            this.iloscCzlonkow = iloscCzlonkow;
        }

        /*
         * Metoda 'stworzListeCzlonkowie()' odpowiedzialna za stworzenie listy członków dwóch klubów.
         * @param mapa Mapa, na której rozgrywa się symulacja.
         * @param predkosc Prędkość poruszania się klubowiczów.
         * @return Lista obiektów członków dwóch klubów.
         */
        public List<ICzlonek> stworzListeCzlonkowie(Mapa mapa, int predkosc) {
            List<ICzlonek> lista = new List<ICzlonek>();

            for (int i = 0; i < iloscCzlonkow; i++) {
                lista.Add(new KMPCzlonek("KMP", mapa, predkosc));
                lista.Add(new KMWCzlonek("KMW", mapa, predkosc));
            }
            return lista;
        }
    }
}
