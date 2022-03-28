using club_support_project_2021_Csharp.pl.dowhankuniewski.czlonkowie;
using club_support_project_2021_Csharp.pl.dowhankuniewski.mapa;
using club_support_project_2021_Csharp.pl.dowhankuniewski.specjalnepole;
using club_support_project_2021_Csharp.pl.dowhankuniewski.stworzliste;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace club_support_project_2021_Csharp {
    /*
     * Klasa 'Symulacja' reprezentująca proces symulacyjny całego programu.
     * @author Filip Dowhan
     * @version 1.1.2 - 08.11.2021 - C# GUI Edition
     */
    public class Symulacja {
        /* Mapa, na której rozgrywa się symulacja. */
        private readonly Mapa mapa;
        /* Lista obiektów członków klubów. */
        private readonly List<ICzlonek> czlonkowieLista;
        /* Lista obiektów pól specjalnych. */
        private readonly List<ISpecjalnePole> specjalnePoleLista;
        /* Ilość iteracji symulacji. */
        public readonly int maxIter;

        /*
         * Konstruktor obiektu 'Symulacja'
         * @param mapa Obiekt mapy, na której rozgrywa się symulacja.
         * @see Symulacja
         * @param stworzListeCzlonek Dostarcza listę członków klubów.
         * @param stworzListePole Dostarcza listę pól specjalnych.
         * @param maxIter Określa maksymalną ilość iteracji.
         * @param predkosc Określa prędkość podstawową poruszających się obiektów.
         */
        Random random = new Random();
        public Symulacja(Mapa mapa, StworzListeCzlonek stworzListeCzlonek, StworzListePole stworzListePole, int maxIter, int predkosc)
        {
            this.mapa = mapa;
            czlonkowieLista = stworzListeCzlonek.stworzListeCzlonkowie(mapa, predkosc);
            specjalnePoleLista = stworzListePole.stworzListePole(mapa);
            this.maxIter = maxIter;
        }

        /*
         * Wykonuje ruch o ilość jednostek równą nadanej prędkości.
         * Sprawdza, czy obiekt nie wyszedł poza granice mapy.
         * Jeśli obiekt potencjalnie wyszedł poza granice, wykonuje ruch przeciwny.
         */
        public void wykonajRuch()
        {
            foreach (ICzlonek czlonek in czlonkowieLista)
            {
                if (((int)(random.NextDouble() * 99 + 1)) > 50)
                {
                    czlonek.setPositionX(czlonek.getPositionX() + czlonek.getPredkosc());
                    if (czlonek.getPositionX() > mapa.getRozmiarMapy())
                    {
                        czlonek.setPositionX(czlonek.getPositionX() - czlonek.getPredkosc());
                    }
                }

                if (((int)(random.NextDouble() * 99 + 1)) > 50)
                {
                    czlonek.setPositionX(czlonek.getPositionX() - czlonek.getPredkosc());
                    if (czlonek.getPositionX() > mapa.getRozmiarMapy())
                    {
                        czlonek.setPositionX(czlonek.getPositionX() + czlonek.getPredkosc());
                    }
                }

                if (((int)(random.NextDouble() * 99 + 1)) > 50)
                {
                    czlonek.setPositionY(czlonek.getPositionY() + czlonek.getPredkosc());
                    if (czlonek.getPositionY() > mapa.getRozmiarMapy())
                    {
                        czlonek.setPositionY(czlonek.getPositionX() - czlonek.getPredkosc());
                    }
                }

                if (((int)(random.NextDouble() * 99 + 1)) > 50)
                {
                    czlonek.setPositionY(czlonek.getPositionY() - czlonek.getPredkosc());
                    if (czlonek.getPositionY() > mapa.getRozmiarMapy())
                    {
                        czlonek.setPositionY(czlonek.getPositionX() + czlonek.getPredkosc());
                    }
                }
            }
        }

        /*
         * Obsługuje spotkania obiektów na tym samym polu.
         * Przeprowadza dialog kończący się zmianą poglądów lub brakiem zmiany.
         */
        public void sprawdzSpotkanieCzlonkow()
        {
            int KMP = 0, KMW = 0;
            foreach (ICzlonek czlonekLicznik in czlonkowieLista)
            {
                if (czlonekLicznik.getPoparcie().Equals("KMP"))
                {
                    KMP++;
                }
                else
                {
                    KMW++;
                }
            }

            foreach (ICzlonek czlonek in czlonkowieLista)
            {
                foreach (ICzlonek czlonek2 in czlonkowieLista)
                {
                    if (czlonek.getPositionX() == czlonek2.getPositionX() && czlonek.getPositionY() == czlonek2.getPositionY() && !czlonek.getPoparcie().Equals(czlonek2.getPoparcie()))
                    {
                        if (!czlonek.getCzyChroniony())
                        {
                            if (czlonek.getPoparcie().Equals("KMP"))
                            {
                                if (((int)(random.NextDouble() * 99 + 1)) <= (51))
                                {
                                    czlonek.setPoparcie("KMW");
                                }
                            }
                            else
                            {
                                if (((int)(random.NextDouble() * 99 + 1)) <= (51))
                                {
                                    czlonek.setPoparcie("KMP");
                                }
                            }
                        }

                        if (!czlonek2.getCzyChroniony())
                        {
                            if (czlonek2.getPoparcie().Equals("KMP"))
                            {
                                if (((int)(random.NextDouble() * 99 + 1)) <= (51))
                                {
                                    czlonek2.setPoparcie("KMW");
                                }
                            }
                            else
                            {
                                if (((int)(random.NextDouble() * 99 + 1)) <= (51))
                                {
                                    czlonek2.setPoparcie("KMP");
                                }
                            }
                        }
                    }
                }
            }
        }

        /*
         * Obsługuje najście obiektów na pole specjalne.
         * Nadaje status chronionego, jeżeli naszedł.
         */
        public void sprawdzWejscieNaPole()
        {
            foreach (ICzlonek czlonek in czlonkowieLista)
            {
                foreach (ISpecjalnePole pole in specjalnePoleLista)
                {
                    if (czlonek.getPositionX() == pole.getPositionX() && czlonek.getPositionY() == pole.getPositionY())
                    {
                        czlonek.setCzyChroniony(true);
                    }
                }
            }
        }

        /*
         * Sprawdza posiadanie cechy specjalnej przez obiekty.
         * Jeśli posiadają, nadaje odpowiednie stałe wzmocnienia lub osłabienia.
         */
        public void sprawdzCechySpecjalne()
        {
            foreach (ICzlonek czlonek in czlonkowieLista)
            {
                if (czlonek.getCechaSpecjalna())
                {
                    if (czlonek.getPoparcie().Equals("KMP"))
                    {
                        czlonek.setPredkosc((int)(czlonek.getPredkosc() * 0.5));
                    }
                    else
                    {
                        czlonek.setPredkosc((int)(czlonek.getPredkosc() * 1.5));
                    }
                }
            }
        }

        /*
         * Zapisuje logi symulacji w odpowiednim formacie do pliku 'outFile.txt'.
         */
        public void zapisLogowDoPliku(int iter, string dateFile)
        {
            int KMP = 0, KMW = 0, chronieniKMP = 0, chronieniKMW = 0, suma;
            foreach (ICzlonek czlonek in czlonkowieLista)
            {
                if (czlonek.getPoparcie().Equals("KMP"))
                {
                    KMP++;
                }
                else
                {
                    KMW++;
                }

                if (czlonek.getCzyChroniony() && czlonek.getPoparcie().Equals("KMP"))
                {
                    chronieniKMP++;
                }

                if (czlonek.getCzyChroniony() && czlonek.getPoparcie().Equals("KMW"))
                {
                    chronieniKMW++;
                }
            }
            suma = chronieniKMP + chronieniKMW;

            using (StreamWriter writer = File.AppendText($"LOGS_{dateFile}.txt"))
            {
                writer.WriteLine(iter + " - - - KMP/Chronieni:" + KMP + "/" + chronieniKMP + " - - - KMW/Chronieni:" + KMW + "/" + chronieniKMW + " - - - Chronieni - suma:" + suma);
            }
        }

        public double KMWData()
        {
            double KMW = 0;
            foreach (ICzlonek czlonek in czlonkowieLista)
            {
                if (czlonek.getPoparcie().Equals("KMW"))
                {
                    KMW++;
                }

            }
            return KMW;
        }

        public double KMPData()
        {
            double KMP = 0;
            foreach (ICzlonek czlonek in czlonkowieLista)
            {
                if (czlonek.getPoparcie().Equals("KMP"))
                {
                    KMP++;
                }

            }
            return KMP;
        }

        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
