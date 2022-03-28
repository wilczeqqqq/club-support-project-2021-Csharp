using club_support_project_2021_Csharp.pl.dowhankuniewski.mapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace club_support_project_2021_Csharp.pl.dowhankuniewski.czlonkowie {
    /*
     * Klasa abstrakcyjna 'ACzlonek' zawierająca pola oraz implementacje metod wspólnych dla członków klubów.
     * Implementuje interfejs 'ICzlonek'
     */
    public abstract class ACzlonek : ICzlonek {
        /* Pogląd klubowicza. */
        protected string poparcie;
        /* Status ochrony klubowicza. */
        protected bool czyChroniony = false;
        /* Pozycja X klubowicza. */
        protected int positionX;
        /* Pozycja Y klubowicza. */
        protected int positionY;
        /* Prędkość poruszania się klubowicza. */
        protected int predkosc;

        /*
         * Konstruktor dla klas rozszerzających klasę 'ACzlonek'.
         * @param poparcie Pogląd klubowicza.
         * @param mapa Mapa, na której rozgrywana jest symulacja.
         * @param predkosc Prędkość poruszania się klubowicza.
         * @see ACzlonek
         */

        Random random = new Random();
        public ACzlonek(string poparcie, Mapa mapa, int predkosc) {
            this.poparcie = poparcie;
            this.positionX = (int)(random.NextDouble() * mapa.getRozmiarMapy());
            this.positionY = (int)(random.NextDouble() * mapa.getRozmiarMapy());
            this.predkosc = predkosc;
        }

        public string getPoparcie() {
                return poparcie;
        }

        public void setPoparcie(string poparcie) {
                this.poparcie = poparcie;
        }


        public bool getCzyChroniony() {
                return czyChroniony;
        }

        public void setCzyChroniony(bool czyChroniony) {
                this.czyChroniony = czyChroniony;
        }

        public int getPositionX() {
                return positionX;
        }

        public void setPositionX(int positionX) {
                this.positionX = positionX;
        }

        public int getPositionY() {
                return positionY;
        }

        public void setPositionY(int positionY) {
                this.positionY = positionY;
        }

        public int getPredkosc() {
                return predkosc;
        }

        public void setPredkosc(int predkosc) {
                this.predkosc = predkosc;
        }

        public virtual bool getCechaSpecjalna() {
            throw new NotImplementedException();
        }
    }
}
