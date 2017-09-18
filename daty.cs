using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytm22
{
    class daty
    {
        int rok;
        int miesiac;
        int dzien;
        int godzina;
        public daty()
        {
            rok = 0;
            miesiac = 0;
            dzien = 0;
            godzina = 0;
        }
        public static int getrok(daty d)
        {
            return d.rok;
        }
        public static int getmiesiac(daty d)
        {
            return d.miesiac;
        }
        public static int getdzien(daty d)
        {
            return d.dzien;
        }
        public static int getgodzina(daty d)
        {
            return d.godzina;
        }
        public static void setrok(daty d, int k)
        {
            d.rok = k;
        }
        public static void setmiesiac(daty d, int k)
        {
            d.miesiac = k;
        }
        public static void setdzien(daty d, int k)
        {
            d.dzien = k;
        }
        public static void setgodzina(daty d, int k)
        {
            d.godzina = k;
        }
        public static int roznicaczasu(daty data1, daty data2) //nie bierze pod uwagę roku!
        {
            int dzien1 = daty.getdzien(data1);
            int miesiac1 = daty.getmiesiac(data1);
            int dzien2 = daty.getdzien(data2);
            int miesiac2 = daty.getmiesiac(data2);
            int rok2 = daty.getrok(data2);
            int roznicadni = 0;
            if (miesiac1 == miesiac2)
            {
                roznicadni = dzien2 - dzien1;
            }
            else
            {
                if (miesiac2 == 1 || miesiac2 == 3 || miesiac2 == 5 || miesiac2 == 7 || miesiac2 == 8 || miesiac2 == 10 || miesiac2 == 12)
                {
                    roznicadni = dzien2 + 31 - dzien1;
                }
                if(miesiac2==2)
                {
                    if (rok2 % 4 == 0) roznicadni = dzien2 + 29 - dzien1;
                    else roznicadni = dzien2 + 28 - dzien1;
                }
                else
                {
                    roznicadni = dzien2 + 30 - dzien1;
                }
            }
            return roznicadni;
        }
    }
}
