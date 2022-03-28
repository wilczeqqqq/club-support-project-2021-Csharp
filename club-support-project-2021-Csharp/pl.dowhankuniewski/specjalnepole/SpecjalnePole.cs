using club_support_project_2021_Csharp.pl.dowhankuniewski.mapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace club_support_project_2021_Csharp.pl.dowhankuniewski.specjalnepole {
    /*
     * Klasa 'SpecjalnePole' reprezentująca pole specjalne w symulacji.
     * Implementuje interfejs 'ISpecjalnePole'.
     */
    public class SpecjalnePole : ISpecjalnePole {
        /* Pozycja X pola specjalnego. */
        private readonly int positionX;
        /* Pozycja Y pola specjalnego. */
        private readonly int positionY;

        /*
         * Konstruktor obiektu 'SpecjalnePole'.
         * @param mapa Mapa, na której odbywa się symulacja.
         * @see SpecjalnePole
         */
        Random random = new Random();
        public SpecjalnePole(Mapa mapa) {
        this.positionX = (int)(random.NextDouble() * mapa.getRozmiarMapy());
        this.positionY = (int)(random.NextDouble() * mapa.getRozmiarMapy());
        }

        public int getPositionX() {
        return positionX;
        }

        public int getPositionY() {
        return positionY;
        }
    }
}
