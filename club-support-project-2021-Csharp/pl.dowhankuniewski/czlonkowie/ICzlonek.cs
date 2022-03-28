using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace club_support_project_2021_Csharp.pl.dowhankuniewski.czlonkowie {
    public interface ICzlonek {
        /*
         * Metoda 'getPoparcie()' stanowiąca getter.
         * @return Wartość tekstowa poparcia klubowicza.
         */
        string getPoparcie();

        /*
         * Metoda 'setPoparcie()' stanowiąca setter.
         * @param poparcie Wartość tekstowa poparcia klubowicza.
         */
        void setPoparcie(string poparcie);

        /*
         * Metoda 'getCzyChroniony()' stanowiąca getter.
         * @return Wartość true/false ochrony poglądów.
         */
        bool getCzyChroniony();

        /*
         * Metoda 'setCzyChroniony()' stanowiąca setter.
         * @param czyChroniony Wartość true/false ochrony poglądów.
         */
        void setCzyChroniony(bool czyChroniony);

        /*
         * Metoda 'getPositionX()' stanowiąca getter.
         * @return Pozycja X klubowicza.
         */
        int getPositionX();

        /*
         * Metoda 'setPositionX()' stanowiąca setter.
         * @param positionX Pozycja X klubowicza.
         */
        void setPositionX(int positionX);

        /*
         * Metoda 'getPositionY()' stanowiąca getter.
         * @return Pozycja Y klubowicza.
         */
        int getPositionY();

        /*
         * Metoda 'setPositionY()' stanowiąca setter.
         * @param positionY Pozycja Y klubowicza.
         */
        void setPositionY(int positionY);

        /*
         * Metoda 'getPredkosc()' stanowiąca getter.
         * @return Wartość prędkości poruszania się klubowiczów.
         */
        int getPredkosc();

        /*
         * Metoda 'getCechaSpecjalna()' stanowiąca getter.
         * @return Wartość true/false posiadania cechy specjalnej.
         */
        bool getCechaSpecjalna();

        /*
         * Metoda 'setPositionY()' stanowiąca setter.
         * @param predkosc Wartość prędkości poruszania się klubowiczów.
         */
        void setPredkosc(int predkosc);
    }
}
