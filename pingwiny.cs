using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytm22
{
    class pingwiny
    {
        int lporzadkowa;
        int nrgrupy;
        double polozenie1; //przesuniecie wzgledem grupy?
        double polozenie2;
        double zdobytepozywienie;
        int liczbanurkowan;
        public pingwiny()
        {
            lporzadkowa = 0;
        }
        public static int getlporzadkowa(pingwiny p)
        {
            return p.lporzadkowa;
        }
        public static int getnrgrupy(pingwiny p)
        {
            return p.nrgrupy;
        }
        public static void setnrgrupy(pingwiny p, int i)
        {
            p.nrgrupy = i;
        }
        public static double getpol1(pingwiny p)
        {
            return p.polozenie1;
        }
        public static double getpol2(pingwiny p)
        {
            return p.polozenie2;
        }
        public static void setpol1(pingwiny p, double d)
        {
            p.polozenie1=d;
        }
        public static void setpol2(pingwiny p, double d)
        {
            p.polozenie2=d;
        }
        public static double getpozywienie(pingwiny p)
        {
            return p.zdobytepozywienie;
        }
        public static void setpozywienie(pingwiny p, double d)
        {
            p.zdobytepozywienie = d;
        }
        public static int getlnurkowan(pingwiny p)
        {
            return p.liczbanurkowan;
        }
        public static void setlnurkowan(pingwiny p, int i)
        {
            p.liczbanurkowan = i;
        }
        public static void nurkuj(pingwiny p, int liczba1, int liczba2, grupy g, punkty[] pun, int lfrachtow, frachty[] f, int nrnurkowania, populacja pop) 
        {
            Random rnd = new Random();
            int i = 0;
            int j = 0;
            int nr = 0;
            int r1 = rnd.Next(-8000, 8000) / 10000;
            int r2 = rnd.Next(-8000, 8000) / 10000;
            int odleglosc = 0;
            int odleglosc1 = 0;
            double w1;
            double w2;
            double wp1;
            double wp2;
            punkty punkt = new punkty();
            bool czy = false;
            double k = 0;
            if (nrnurkowania == 1)
            {
                pingwiny.setpol1(p, punkty.getwspr1(grupy.getpunkt(g)) + r1);
                pingwiny.setpol2(p, punkty.getwspr2(grupy.getpunkt(g)) + r2);
                w1 = pingwiny.getpol1(p);
                w2 = pingwiny.getpol2(p);
                wp1 = punkty.getwspz1(pun[liczba1]);
                wp2 = punkty.getwspz2(pun[liczba1]);
                odleglosc = (int)(Math.Acos((Math.Sin(wp1 * Math.PI / 180) * Math.Sin(w1 * Math.PI / 180) + Math.Cos(wp1 * Math.PI / 180) * Math.Cos(w1 * Math.PI / 180) * Math.Cos((w2 - wp2) * Math.PI / 180))) * 6371);
                punkt = pun[liczba1];
                if (odleglosc < 20) czy = true;
                for (j = liczba1 + 1; j < liczba2; j++)
                {
                    wp1 = punkty.getwspz1(pun[j]);
                    wp2 = punkty.getwspz2(pun[j]);
                    odleglosc1 = (int)(Math.Acos((Math.Sin(wp1 * Math.PI / 180) * Math.Sin(w1 * Math.PI / 180) + Math.Cos(wp1 * Math.PI / 180) * Math.Cos(w1 * Math.PI / 180) * Math.Cos((w2 - wp2) * Math.PI / 180))) * 6371);
                    if (odleglosc1 < odleglosc && odleglosc1 < 20)
                    {
                        odleglosc = odleglosc1;
                        punkt = pun[j];
                        czy = true;
                    }
                    if (czy == true)
                    {
                        k = grupy.getpodstawe(g);
                        p.zdobytepozywienie = k + (200 - (Math.Sqrt((r1 * r1) + (r2 * r2)) + odleglosc)) + punkty.obliczryby(punkt, g, f, lfrachtow);
                    }
                    else p.zdobytepozywienie = grupy.getpodstawe(g);
                }
            }
            else
            {
                w1 = pingwiny.getpol1(p);
                w2 = pingwiny.getpol2(p);
                wp1 = punkty.getwspz1(pun[liczba1]);
                wp2 = punkty.getwspz2(pun[liczba1]);
                odleglosc = (int)(Math.Acos((Math.Sin(wp1 * Math.PI / 180) * Math.Sin(w1 * Math.PI / 180) + Math.Cos(wp1 * Math.PI / 180) * Math.Cos(w1 * Math.PI / 180) * Math.Cos((w2 - wp2) * Math.PI / 180))) * 6371);
                punkt = pun[liczba1];
                if (odleglosc < 20) czy = true;
                for (j = liczba1 + 1; j < liczba2; j++)
                {
                    wp1 = punkty.getwspz1(pun[j]);
                    wp2 = punkty.getwspz2(pun[j]);
                    odleglosc1 = (int)(Math.Acos((Math.Sin(wp1 * Math.PI / 180) * Math.Sin(w1 * Math.PI / 180) + Math.Cos(wp1 * Math.PI / 180) * Math.Cos(w1 * Math.PI / 180) * Math.Cos((w2 - wp2) * Math.PI / 180))) * 6371);
                    if (odleglosc1 < odleglosc && odleglosc1 < 20)
                    {
                        odleglosc = odleglosc1;
                        punkt = pun[j];
                        czy = true;
                    }
                }
                nr = 0;
                if(czy== true)
                {
                    w1 = punkty.getwspr1(grupy.getpunkt(populacja.getgrupa(pop, 0)));
                    w2 = punkty.getwspr2(grupy.getpunkt(populacja.getgrupa(pop, 0)));
                    odleglosc = (int)(Math.Acos((Math.Sin(wp1 * Math.PI / 180) * Math.Sin(w1 * Math.PI / 180) + Math.Cos(wp1 * Math.PI / 180) * Math.Cos(w1 * Math.PI / 180) * Math.Cos((w2 - wp2) * Math.PI / 180))) * 6371);
                    for (i = 1; i < populacja.getlgrup(pop); i++)
                    {
                        w1 = punkty.getwspr1(grupy.getpunkt(populacja.getgrupa(pop, i)));
                        w2 = punkty.getwspr2(grupy.getpunkt(populacja.getgrupa(pop, i)));
                        odleglosc1 = (int)(Math.Acos((Math.Sin(wp1 * Math.PI / 180) * Math.Sin(w1 * Math.PI / 180) + Math.Cos(wp1 * Math.PI / 180) * Math.Cos(w1 * Math.PI / 180) * Math.Cos((w2 - wp2) * Math.PI / 180))) * 6371);
                        if (odleglosc1 < odleglosc && daty.roznicaczasu(punkty.getdata(punkt), punkty.getdata(grupy.getpunkt(populacja.getgrupa(pop, i)))) > 0)
                        {
                            odleglosc = odleglosc1;
                            nr = i;
                        }
                    }
                }
                else
                {
                    wp1 = punkty.getwspr1(grupy.getpunkt(populacja.getgrupa(pop, 0)));
                    wp2 = punkty.getwspr2(grupy.getpunkt(populacja.getgrupa(pop, 0)));
                    odleglosc = (int)(Math.Acos((Math.Sin(wp1 * Math.PI / 180) * Math.Sin(w1 * Math.PI / 180) + Math.Cos(wp1 * Math.PI / 180) * Math.Cos(w1 * Math.PI / 180) * Math.Cos((w2 - wp2) * Math.PI / 180))) * 6371);
                    for (i = 1; i < populacja.getlgrup(pop); i++)
                    {
                        wp1 = punkty.getwspr1(grupy.getpunkt(populacja.getgrupa(pop, i)));
                        wp2 = punkty.getwspr2(grupy.getpunkt(populacja.getgrupa(pop, i)));
                        odleglosc1 = (int)(Math.Acos((Math.Sin(wp1 * Math.PI / 180) * Math.Sin(w1 * Math.PI / 180) + Math.Cos(wp1 * Math.PI / 180) * Math.Cos(w1 * Math.PI / 180) * Math.Cos((w2 - wp2) * Math.PI / 180))) * 6371);
                        if (odleglosc1 < odleglosc && daty.roznicaczasu(punkty.getdata(punkt), punkty.getdata(grupy.getpunkt(populacja.getgrupa(pop, i)))) > 0)
                        {
                            odleglosc = odleglosc1;
                            nr = i;
                        }
                    }
                }
                if (nr != pingwiny.getnrgrupy(p))
                {
                    grupy.zabierzpingwina(populacja.getgrupa(pop, p.nrgrupy), p);
                    grupy.dodajpingwina(populacja.getgrupa(pop, nr), p);
                    p.nrgrupy = nr;
                    g = populacja.getgrupa(pop, nr);
                }
                if (czy == true)
                {
                    k = grupy.getpodstawe(g);
                    p.zdobytepozywienie = k + (200 - (Math.Sqrt((r1 * r1) + (r2 * r2)) + odleglosc)) + punkty.obliczryby(punkt, g, f, lfrachtow);
                }
                else p.zdobytepozywienie = grupy.getpodstawe(g);
            }
        }
        public static void przemiescsie(pingwiny p, populacja pop)
        {
            double pol1=pingwiny.getpol1(populacja.getpgbest(pop));
            double pol2=pingwiny.getpol2(populacja.getpgbest(pop));
            Random rnd=new Random();
            double r1=rnd.Next(0,1000)/10000;
            double r2=rnd.Next(0,1000)/10000;
            if (p.lporzadkowa != pingwiny.getlporzadkowa(populacja.getpgbest(pop)))
            {
                if(p.polozenie1<=pol1)
                {
                    p.polozenie1=p.polozenie1+r1*(pol1-p.polozenie1);
                }
                else p.polozenie1=p.polozenie1-r1*(pol1-p.polozenie1);
                if (p.polozenie2 <= pol2)
                {
                    p.polozenie2 = p.polozenie2 + r2 * (pol2 - p.polozenie2);
                }
                else p.polozenie1 = p.polozenie2 - r1 * (pol2 - p.polozenie2);
            }
        }
    }
}
