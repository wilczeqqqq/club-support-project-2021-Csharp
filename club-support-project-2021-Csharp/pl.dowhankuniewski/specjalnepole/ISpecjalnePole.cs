using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace club_support_project_2021_Csharp.pl.dowhankuniewski.specjalnepole {
    /*
     * Interfejs 'ISpecjalnePole' zawierający podstawowe metody dla pól specjalnych.
     */
    public interface ISpecjalnePole {

        /*
         * Metoda 'getPositionX()' stanowiąca getter.
         * @return Pozycja X pola specjalnego.
         */
        int getPositionX();

        /*
         * Metoda 'getPositionY()' stanowiąca getter.
         * @return Pozycja Y pola specjalnego.
         */
        int getPositionY();
    }
}
