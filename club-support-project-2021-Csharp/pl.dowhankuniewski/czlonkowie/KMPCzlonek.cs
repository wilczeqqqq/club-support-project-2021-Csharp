using club_support_project_2021_Csharp.pl.dowhankuniewski.mapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace club_support_project_2021_Csharp.pl.dowhankuniewski.czlonkowie {
    /*
     * Klasa 'KMPCzlonek' reprezentująca członków Klubu Miłośników Piwa w symulacji.
     * Rozszerza klasę abstrakcyjną 'ACzlonek'.
     */
    public class KMPCzlonek : ACzlonek {
        /* Cecha specjalna dla członków KMP. */
        private readonly bool czyMaPiwnyBrzuch;

        /*
         * Konstruktor obiektu 'KMPCzlonek'.
         * @see ACzlonek#ACzlonek(String, Mapa, int)
         */
        Random random = new Random();
        public KMPCzlonek(string poparcie, Mapa mapa, int predkosc) : base(poparcie, mapa, predkosc)  {    
            this.czyMaPiwnyBrzuch = ((int)(random.NextDouble() * 99 + 1)) < 34;
        }

        
        public override bool getCechaSpecjalna() {
            return czyMaPiwnyBrzuch;
        }
    }
}   
