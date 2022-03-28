using club_support_project_2021_Csharp.pl.dowhankuniewski.mapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace club_support_project_2021_Csharp.pl.dowhankuniewski.czlonkowie {
    /*
     * Klasa 'KMWCzlonek' reprezentująca członków Klubu Miłośników Wina w symulacji.
     * Rozszerza klasę abstrakcyjną 'ACzlonek'.
     */
    public class KMWCzlonek : ACzlonek {
        /* Cecha specjalna dla członków KMW. */
        private readonly bool czyPilWino;

        /*
         * Konstruktor obiektu 'KMWCzlonek'.
         * @see ACzlonek#ACzlonek(String, Mapa, int)
         */
        Random random = new Random();
        public KMWCzlonek(string poparcie, Mapa mapa, int predkosc) : base(poparcie, mapa, predkosc) {
            this.czyPilWino = ((int)(random.NextDouble() * 99 + 1)) < 67;
        }


        public override bool getCechaSpecjalna() {
            return czyPilWino;
        }
    }
}
