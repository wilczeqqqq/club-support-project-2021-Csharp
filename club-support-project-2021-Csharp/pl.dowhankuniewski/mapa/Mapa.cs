using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace club_support_project_2021_Csharp.pl.dowhankuniewski.mapa {
    /*
     * Klasa 'Mapa' reprezentująca mapę, na której przeprowadzana jest symulacja.
     * Implementuje interfejs 'IMapa'.
     */
    public class Mapa : IMapa {
        /* Rozmiar boku kwadratowej mapy, na której odbywa się symulacja. */
        private readonly int rozmiarMapy;


        /*
         * Konstruktor obiektu 'Mapa'.
         * @param rozmiarMapy Rozmiar boku kwadratowej mapy.
         * @see Mapa
         */
        public Mapa(int rozmiarMapy) {
            this.rozmiarMapy = rozmiarMapy;
        }

        public int getRozmiarMapy() {
            return rozmiarMapy;
        }
    }
}
