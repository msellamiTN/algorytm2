using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytm22
{
    class oferty
    {
        int numerpunktu; //w drugim poziomie!
        int lporzadkowa;
        daty datazal = new daty();
        double wspzal1;
        double wspzal2;
        double wsproz1;
        double wsproz2;
        int dlugosctrasy;
        bool czyaktywna;
        bool czyistnieje;
        public oferty()
        {
            czyistnieje = false;
            czyaktywna = true;
            dlugosctrasy = 0;
            wspzal1 = 0;
            wspzal2 = 0;
            wsproz1 = 0;
            wsproz2 = 0;
        }
        public static int getnrpunktu(oferty o)
        {
            return o.numerpunktu;
        }
        public static bool getczyistnieje(oferty o)
        {
            return o.czyistnieje;
        }
        public static void setczyistnieje(oferty o, int i)
        {
            o.czyistnieje = true;
            o.numerpunktu = i;
        }
        public static bool getczyaktywna(oferty o)
        {
            return o.czyaktywna;
        }
        public static void setaktywna(oferty o, bool t)
        {
            o.czyaktywna = t;
        }
        public static int getdltrasy(oferty o)
        {
            return o.dlugosctrasy;
        }
        public static void setdltrasy(oferty o)
        {
            int roznicakm = (int)(Math.Acos((Math.Sin(o.wsproz1 * Math.PI / 180) * Math.Sin(o.wspzal1 * Math.PI / 180) + Math.Cos(o.wsproz1 * Math.PI / 180) * Math.Cos(o.wspzal1 * Math.PI / 180) * Math.Cos((o.wsproz2 - o.wspzal2) * Math.PI / 180))) * 6371);
            o.dlugosctrasy = roznicakm;
        }
        public static int getlporzadkowa(oferty o)
        {
            return o.lporzadkowa;
        }
        public static void setlporzadkowa(oferty o, int l)
        {
            o.lporzadkowa = l;
        }
        public static daty getdatazal(oferty o)
        {
            return o.datazal;
        }
        public static double getwspzal1(oferty o)
        {
            return o.wspzal1;
        }
        public static double getwspzal2(oferty o)
        {
            return o.wspzal2;
        }
        public static double getwsproz1(oferty o)
        {
            return o.wsproz1;
        }
        public static double getwsproz2(oferty o)
        {
            return o.wsproz2;
        }
        public static void setwlasnosci(oferty p, string s, punkty punkt, int liczba, oferty[] o)
        {
            char[] c = new char[20];
            int i = 0;
            int j = 0;
            int k = 0;
            int e = 0;
            int d = 0;
            int minus = 1;
            //data zaladunku
            for (i = 0; s[i] != '/'; i++)
            {
                c[j] = s[i];
                j++;
            }
            for (j = j - 1; j >= 0; j--)
            {
                e = Convert.ToInt32(c[k] - 48);
                d = d + e * (int)Math.Pow(10, j);
                k++;
            }
            daty.setmiesiac(p.datazal, d);
            //System.Console.Write(d);
            d = 0;
            j = 0;
            k = 0;
            int l = 0;
            for (i = i + 1; s[i] != '/'; i++)
            {
                c[j] = s[i];
                j++;
            }
            for (j = j - 1; j >= 0; j--)
            {
                e = Convert.ToInt32(c[k] - 48);
                d = d + e * (int)Math.Pow(10, j);
                k++;
            }
            daty.setdzien(p.datazal, d);
            // System.Console.Write(d);

            d = 0;
            j = 0;
            k = 0;
            for (i = i + 1; s[i] != ','; i++)
            {
                c[j] = s[i];
                j++;
            }
            for (j = j - 1; j >= 0; j--)
            {
                e = Convert.ToInt32(c[k] - 48);
                d = d + e * (int)Math.Pow(10, j);
                k++;
            }
            daty.setrok(p.datazal, d - 2000);
            k = 0;
            j = 0;

            if (daty.roznicaczasu(oferty.getdatazal(p), punkty.getdata(punkt)) <= 6)
            {
                //współrzędne załadunku 1
                for (i = i + 1; s[i] != '.' && s[i] != ','; i++)
                {
                    c[j] = s[i];
                    j++;
                }
                for (j = j - 1; j >= 0; j--)
                {
                    e = Convert.ToInt32(c[k] - 48);
                    p.wspzal1 = p.wspzal1 + e * (int)Math.Pow(10, j);
                    k++;
                }
                if (s[i] == '.')
                {
                    k = 1;
                    j = 1;
                    for (i = i + 1; s[i] != ','; i++)
                    {
                        c[j] = s[i];
                        j++;
                    }
                    for (l = 1; l < j; l++)
                    {
                        e = Convert.ToInt32(c[k] - 48);
                        p.wspzal1 = p.wspzal1 + e * Math.Pow(10, -l);
                        k++;
                    }
                }
                k = 0;
                j = 0;

                //współrzędne załadunku 2
                for (i = i + 1; s[i] != '.' && s[i] != ','; i++)
                {
                    c[j] = s[i];
                    j++;
                }
                if (c[0] == '-')
                {
                    minus = -1;
                    k++;
                    j--;
                }
                for (j = j - 1; j >= 0; j--)
                {
                    e = Convert.ToInt32(c[k] - 48);
                    p.wspzal2 = p.wspzal2 + e * (int)Math.Pow(10, j);
                    k++;
                }
                if (s[i] == '.')
                {
                    k = 1;
                    j = 1;
                    for (i = i + 1; s[i] != ','; i++)
                    {
                        c[j] = s[i];
                        j++;
                    }
                    for (l = 1; l < j; l++)
                    {
                        e = Convert.ToInt32(c[k] - 48);
                        p.wspzal2 = p.wspzal2 + e * Math.Pow(10, -l);
                        k++;
                    }
                }
                p.wspzal2 = minus * p.wspzal2;
                minus = 1;
                k = 0;
                j = 0;

                //współrzędne rozladunku1
                for (i = i + 1; s[i] != '.' && s[i] != ','; i++)
                {
                    c[j] = s[i];
                    j++;
                }
                for (j = j - 1; j >= 0; j--)
                {
                    e = Convert.ToInt32(c[k] - 48);
                    p.wsproz1 = p.wsproz1 + e * (int)Math.Pow(10, j);
                    k++;
                }
                if (s[i] == '.')
                {
                    k = 1;
                    j = 1;
                    for (i = i + 1; s[i] != ','; i++)
                    {
                        c[j] = s[i];
                        j++;
                    }
                    for (l = 1; l < j; l++)
                    {
                        e = Convert.ToInt32(c[k] - 48);
                        p.wsproz1 = p.wsproz1 + e * Math.Pow(10, -l);
                        k++;
                    }
                }
                k = 0;
                j = 0;

                //współrzędne rozladunku2
                for (i = i + 1; s[i] != '.' && s[i] != ',' && s[i] != null; i++)
                {
                    c[j] = s[i];
                    j++;
                }
                if (c[0] == '-')
                {
                    k++;
                    j--;
                    minus = -1;
                }
                for (j = j - 1; j >= 0; j--)
                {
                    e = Convert.ToInt32(c[k] - 48);
                    p.wsproz2 = p.wsproz2 + e * (int)Math.Pow(10, j);
                    k++;
                }
                if (s[i] == '.')
                {
                    k = 1;
                    j = 1;
                    for (i = i + 1; i < s.Length; i++)
                    {
                        c[j] = s[i];
                        j++;
                    }
                    for (l = 1; l < j; l++)
                    {
                        e = Convert.ToInt32(c[k] - 48);
                        p.wsproz2 = p.wsproz2 + e * Math.Pow(10, -l);
                        k++;
                    }
                }
                p.wsproz2 = minus * p.wsproz2;
            }
            else p.czyaktywna = false;
            oferty.setdltrasy(p);
        }
    }
}
