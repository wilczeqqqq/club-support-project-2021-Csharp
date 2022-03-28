using club_support_project_2021_Csharp.pl.dowhankuniewski.mapa;
using club_support_project_2021_Csharp.pl.dowhankuniewski.specjalnepole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace club_support_project_2021_Csharp.pl.dowhankuniewski.stworzliste {
    /*
     * Klasa 'StworzListePole' odpowiedzialna za utworzenie list obiektów pól specjalnych.
     */
    public class StworzListePole {
        /* Ilość pól specjalnych. */
        private readonly int iloscPol;

        /*
         * Konstruktor obiektu 'StworzListePole'.
         * @param iloscPol Ilość pól specjalnych.
         * @see StworzListePole
         */
        public StworzListePole(int iloscPol) {
            this.iloscPol = iloscPol;
        }

        /*
         * Metoda 'stworzListePole()' odpowiedzialna za stworzenie listy pól specjalnych.
         * @param mapa Mapa, na której rozgrywa się symulacja.
         * @return Listy obiektów pól specjalnych.
         */
        public List<ISpecjalnePole> stworzListePole(Mapa mapa) {
            List<ISpecjalnePole> lista = new List<ISpecjalnePole>();

            for (int i = 0; i < iloscPol; i++) {
                lista.Add(new SpecjalnePole(mapa));
            }
            return lista;
        }
    }
}
