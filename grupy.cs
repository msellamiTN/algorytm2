using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytm22
{
    class grupy
    {
        int nrgrupy;
        int lpingwinow;
        double podstawapunktu; //dla każdego pingwina z grupy mamy taką samą wartość "początkową" wynikającą z łowiska grupy
        punkty punkt=new punkty();
        pingwiny[] pingwin=new pingwiny[4000];
        pingwiny pbest = new pingwiny(0, 50000);

        public grupy(int i)
        {
            int j = 0;
            nrgrupy = i;
            for(j=0;j<4000;j++)
            {
                if(j<30) this.pingwin[j]=new pingwiny(i, (i)*30+j);
                else this.pingwin[j] = new pingwiny(i, 50000);

            }
            lpingwinow = 20; //zakłądamy początkową liczbę pingwinów
        }
        public static int getnrgrupy(grupy g)
        {
            return g.nrgrupy;
        }
        public static void setlpingwinow(grupy g, int i)
        {
            g.lpingwinow=i;
        }
        public static int getlpingwinow(grupy g)
        {
            return g.lpingwinow;
        }
        public static pingwiny getbest(grupy g)
        {
            return g.pbest;
        }
        public static void setpunkt(grupy g, punkty p)
        {
            g.punkt = p;
        }
        public static punkty getpunkt(grupy g)
        {
            return g.punkt;
        }
        public static void obliczpodstawe(grupy g, punkty ppocz, frachty[] f, int lfrachtow)
        {
            double wp1 = punkty.getwspz1(ppocz);
            double wp2 = punkty.getwspz2(ppocz);
            double wg1 = punkty.getwspz1(g.punkt);
            double wg2 = punkty.getwspz2(g.punkt);
            double wgr1 = punkty.getwspr1(g.punkt);
            double wgr2 = punkty.getwspr2(g.punkt);

            int odleglosc = (int)(Math.Acos((Math.Sin(wp1 * Math.PI / 180) * Math.Sin(wg1 * Math.PI / 180) + Math.Cos(wp1 * Math.PI / 180) * Math.Cos(wg1 * Math.PI / 180) * Math.Cos((wg2 - wp2) * Math.PI / 180))) * 6371);
            int dl = (int)(Math.Acos((Math.Sin(wg1 * Math.PI / 180) * Math.Sin(wgr1 * Math.PI / 180) + Math.Cos(wg1 * Math.PI / 180) * Math.Cos(wgr1 * Math.PI / 180) * Math.Cos((wg2 - wgr2) * Math.PI / 180))) * 6371);

            g.podstawapunktu = 200 - odleglosc + 0.4 * dl - daty.roznicaczasu(punkty.getdata(ppocz), punkty.getdata(g.punkt)) + frachty.porownujfrachty(f, g.punkt, lfrachtow) + punkty.getlsasiadow(g.punkt);
        }
        public static void dodajpingwina(grupy g, pingwiny p)
        {
            g.pingwin[g.lpingwinow] = p;
            g.lpingwinow++;
            pingwiny.setnrgrupy(p, g.nrgrupy);
        }
        public static void zabierzpingwina(grupy g, pingwiny p)
        {
            int nr = pingwiny.getlporzadkowa(p);
            int i = 0;
            int j=0;
            for(i=0;i<g.lpingwinow;i++)
            {
                if (pingwiny.getlporzadkowa(g.pingwin[i]) == nr)
                {
                    j=i+1;
                    while (j < g.lpingwinow - 1)
                    {
                        g.pingwin[i] = g.pingwin[j];
                        i++;
                        j++;
                    }
                }
            }
            g.lpingwinow--;
        }
        public static void wymianainformacji(grupy g)
        {
            int j=0;
            double best;
            pingwiny p = new pingwiny(0, 50000);
            p = g.pingwin[j];
            best = pingwiny.getpozywienie(g.pingwin[j]);
                for (j = 0; j < g.lpingwinow; j++)
                {
                    if (pingwiny.getpozywienie(g.pingwin[j]) > best)
                    {
                        best = pingwiny.getpozywienie(g.pingwin[j]);
                        p = g.pingwin[j];
                    }
                }
                   
            g.pbest = p;
        }
        public static double getpodstawe(grupy g)
        {
            return g.podstawapunktu;
        }
        public static void zacznijpolowanie(grupy g, punkty ppocz, int liczba1, int liczba2, punkty[] p, int lfrachtow, frachty[] f, int nr, populacja pop)
        {

            int i = 0;
            obliczpodstawe(g, ppocz, f,lfrachtow);
            for (i = 0; i < g.lpingwinow; i++)
            {
                pingwiny.nurkuj(g.pingwin[i], liczba1, liczba2, g,p,lfrachtow,f,nr,pop);
            }
            grupy.wymianainformacji(g);

        }
        public static void najliczniejsze(populacja pop, grupy[] g)
        {
            grupy gi = new grupy(0);
            int j=0;
            int i = 1;
            while (j <= populacja.getlgrup(pop))
            {
                for (i =0; i <populacja.getlgrup(pop)-1; i++)
                {
                    if (grupy.getlpingwinow(g[i])>grupy.getlpingwinow(g[i+1]))
                    {
                        gi = g[i+1];
                        g[i+1] = g[i];
                        g[i] = gi;
                    }
                }
                j++;
            }
            for(j=populacja.getlgrup(pop)-1;j>=populacja.getlgrup(pop)-5;j--)
            {
                System.Console.WriteLine(populacja.getlgrup(pop)-j +" miejsce z prawdopodobienstwem "+ grupy.getlpingwinow(g[j]) + "/"+populacja.getlgrup(pop)*30 +" "+ grupy.getnrgrupy(g[j]));
                System.Console.WriteLine("współrzędne załadunku: "+punkty.getwspz1(grupy.getpunkt(g[j]))+";"+punkty.getwspz2(grupy.getpunkt(g[j])));
                System.Console.WriteLine("współrzędne rozładunku: " + punkty.getwspr1(grupy.getpunkt(g[j])) + ";" + punkty.getwspr2(grupy.getpunkt(g[j])));
                System.Console.WriteLine("data załadunku: " + daty.getdzien(punkty.getdata(grupy.getpunkt(g[j]))) + "/" + daty.getmiesiac(punkty.getdata(grupy.getpunkt(g[j]))) + "/" +daty.getrok(punkty.getdata(grupy.getpunkt(g[j]))));
            }
        }
    }
}
