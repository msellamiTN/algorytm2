using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytm22
{
    class frachty
    {
        double cena = 0;
        int kilometry;
        double czas;
        daty dzal = new daty();
        daty droz = new daty();
        double wspzal1;
        double wspzal2;
        double wsproz1;
        double wsproz2;
        public frachty()
        {
            cena = 0;
            czas = 0;
            wspzal1 = 0;
            wspzal2 = 0;
            wsproz1 = 0;
            wsproz2 = 0;
        }
        public static double getcena(frachty f)
        {
            return f.cena;
        }
        public static double getcenakm(frachty f)
        {
            double d = f.cena / f.kilometry;
            return d;
        }
        public static int getkilometry(frachty f)
        {
            return f.kilometry;
        }
        public static double getczas(frachty f)
        {
            return f.czas;
        }
        public static daty getdzal(frachty f)
        {
            return f.dzal;
        }
        public static daty getdroz(frachty f)
        {
            return f.droz;
        }
        public static double getwspzal1(frachty f)
        {
            return f.wspzal1;
        }
        public static double getwspzal2(frachty f)
        {
            return f.wspzal2;
        }
        public static double getwsproz1(frachty f)
        {
            return f.wsproz1;
        }
        public static double getwsproz2(frachty f)
        {
            return f.wsproz2;
        }
        public static void setwlasnosci(frachty p, string s)
        {
            char[] c = new char[10];
            int j = 0;
            int k = 0;
            int l = 0;
            p.cena = 0;
            int e = 0;
            int d = 0; //do dat
            int i;
            int minus = 1; //współrzędne mogą być -!!!
            //cena
            for (i = 0; s[i] != '.' && s[i] != ','; i++)
            {
                c[j] = s[i];
                j++;
            }
            for (j = j - 1; j >= 0; j--)
            {
                e = Convert.ToInt32(c[k] - 48);
                p.cena = p.cena + e * (int)Math.Pow(10, j);
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
                    p.cena = p.cena + e * Math.Pow(10, -l);
                    k++;
                }
            }

            k = 0;
            j = 0;
            //kilometry
            for (i = i + 1; s[i] != ','; i++)
            {
                c[j] = s[i];
                j++;
            }
            for (j = j - 1; j >= 0; j--)
            {
                e = Convert.ToInt32(c[k] - 48);
                p.kilometry = p.kilometry + e * (int)Math.Pow(10, j);
                k++;
            }
            k = 0;
            j = 0;
            //czas
            for (i = i + 1; s[i] != '.' && s[i] != ','; i++)
            {
                c[j] = s[i];
                j++;
            }
            for (j = j - 1; j >= 0; j--)
            {
                e = Convert.ToInt32(c[k] - 48);
                p.czas = p.czas + e * (int)Math.Pow(10, j);
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
                    p.czas = p.czas + e * Math.Pow(10, -l);
                    k++;
                }
            }
            j = 0;
            k = 0;

            //data zaladunku
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
            daty.setrok(p.dzal, d);

            d = 0;
            j = 0;
            k = 0;
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
            daty.setmiesiac(p.dzal, d);

            d = 0;
            j = 0;
            k = 0;
            for (i = i + 1; s[i] != ' '; i++)
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
            daty.setdzien(p.dzal, d);

            j = 0;
            d = 0;
            k = 0;
            for (i = i + 1; s[i] != ','; i++)
            {
                c[j] = s[i];
                j++;
            }
            d = Convert.ToInt32(c[0] - 48) * 1000 + Convert.ToInt32(c[1] - 48) * 100 + Convert.ToInt32(c[3] - 48) * 10 + Convert.ToInt32(c[4] - 48);
            daty.setgodzina(p.dzal, d);
            j = 0;
            k = 0;
            d = 0;

            //data rozladunku
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
            daty.setrok(p.droz, d);

            d = 0;
            j = 0;
            k = 0;
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
            daty.setmiesiac(p.droz, d);

            d = 0;
            j = 0;
            k = 0;
            for (i = i + 1; s[i] != ' '; i++)
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
            daty.setdzien(p.droz, d);
            j = 0;
            d = 0;
            k = 0;
            for (i = i + 1; s[i] != ','; i++)
            {
                c[j] = s[i];
                j++;
            }
            d = Convert.ToInt32(c[0] - 48) * 1000 + Convert.ToInt32(c[1] - 48) * 100 + Convert.ToInt32(c[3] - 48) * 10 + Convert.ToInt32(c[4] - 48);
            daty.setgodzina(p.droz, d);
            k = 0;
            j = 0;

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
                k = 1;
                minus = -1;
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
            for (i = i + 1; s[i] != '.' && s[i] != ','; i++)
            {
                c[j] = s[i];
                j++;
            }
            if (c[0] == '-')
            {
                k = 1;
                minus = -1;
                j--;
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
                for (i = i + 1; s[i] != ','; i++)
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
       public static double porownujfrachty(frachty[] f, punkty p, int lfrachtow)
        {
            daty data1 = new daty();
            daty datap = new daty();
            double wsp1;
            double wsp2;
            double wspp1;
            double wspp2;
            int odleglosc;
            double liczba=0;
            double mnoznikc=0;
            double mnoznikk = 0;

            datap = punkty.getdata(p);
  
            wspp1 = punkty.getwspr1(p);
            wspp2 = punkty.getwspr2(p);
            for (int i = 0; i < lfrachtow-1; i++)
            {
                data1 = frachty.getdzal(f[i]);
                if (daty.roznicaczasu(data1,datap) > -15 && daty.roznicaczasu(data1, datap) < 15)
                {
                    wsp1 = frachty.getwspzal1(f[i]);
                    wsp2 = frachty.getwspzal2(f[i]);
                    odleglosc = (int)(Math.Acos((Math.Sin(wsp1 * Math.PI / 180) * Math.Sin(wspp1 * Math.PI / 180) + Math.Cos(wsp1 * Math.PI / 180) * Math.Cos(wspp1 * Math.PI / 180) * Math.Cos((wsp2 - wspp2) * Math.PI / 180))) * 6371);
                    if (odleglosc <= 90)
                    {
                        if (frachty.getcenakm(f[i]) <= 1.5) mnoznikc = 0.9 * frachty.getcenakm(f[i]);
                        else
                        {
                            if (frachty.getcenakm(f[i]) <= 2) mnoznikc = 1.1 * frachty.getcenakm(f[i]);
                            else
                            {
                                mnoznikc = 1.4 * frachty.getcenakm(f[i]);
                            }
                        }
                        if (frachty.getkilometry(f[i]) <= 500) mnoznikk = 0.9 * frachty.getkilometry(f[i]) / 1000;
                        else
                        {
                            if (frachty.getkilometry(f[i]) <= 1000) mnoznikk = 1.1 * frachty.getkilometry(f[i]) / 1000;
                            else
                            {
                                if (frachty.getkilometry(f[i]) <= 1500) mnoznikk = 1.3*frachty.getkilometry(f[i])/1000;
                                else mnoznikk = 1.6 * frachty.getkilometry(f[i]) / 1000;
                            }
                        }
                        liczba = liczba + 0.6 * mnoznikc + 0.4 * mnoznikk - odleglosc / 100 ;
                    }
                }
            }
            return liczba;
        }
    }
}
