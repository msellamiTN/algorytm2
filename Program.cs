using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace algorytm22
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0; //zmienne do ew liczenia
            int j = 0;
            int k = 0;
            int l = 0;
            double d = 0;
            string s = "A";
            string s1 = "A";
            bool b;
            int lofert = 0;
            int lfrachtow = 0;
            int lpunktow = 0;
            oferty[] ofer = new oferty[40000];
            frachty[] fra = new frachty[9000];
            populacja pop = new populacja();
            grupy[] gr=new grupy[700]; //potem inicjować
            punkty[] pun = new punkty[30000];
            punkty ppocz = new punkty();
            //wczytanie ofert i frachtów- skopiować

            ppocz = punkty.wczytppocz(); //oferty, frachty- w ten sam sposób wczytywane, też warunki dla ofert wziętych pod uwagę
            s = "C:/Users/Nina/Documents/Visual Studio 2013/Projects/algorytm11/Arkusz1.txt"; //jak odnośnik krótszy?!
            if (File.Exists(s))
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader(s);
                s1 = sr.ReadLine();
                while (s1 != null)
                {
                    s1 = sr.ReadLine();
                    if (s1 != null)
                    {
                        fra[j] = new frachty();
                        frachty.setwlasnosci(fra[j], s1);
                    }
                    j++;
                }
                sb.AppendLine(s1);
                sr.Close();
            }
            lfrachtow = j;
            s = "C:/Users/Nina/Documents/Visual Studio 2013/Projects/algorytm22/oferty.txt";
            j = 0;
            if (File.Exists(s))
            {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader(s);
                s1 = sr.ReadLine();
                while (s1 != null && s1 != "")
                {
                    s1 = sr.ReadLine();
                    ofer[j] = new oferty();
                    if (s1 != null && s1 != "")
                    {
                        oferty.setwlasnosci(ofer[j], s1, ppocz, j - 1, ofer);
                        oferty.setlporzadkowa(ofer[j], j);
                    }
                    for (i = 0; i < j; i++) //powtarzające się oferty!!!!!!!!!!
                    {
                        if (daty.getdzien(oferty.getdatazal(ofer[i])) == daty.getdzien(oferty.getdatazal(ofer[j])) && daty.getmiesiac(oferty.getdatazal(ofer[i])) == daty.getmiesiac(oferty.getdatazal(ofer[j])) && daty.getrok(oferty.getdatazal(ofer[i])) == daty.getrok(oferty.getdatazal(ofer[j])) && oferty.getwspzal1(ofer[i]) == oferty.getwspzal1(ofer[j]) && oferty.getwspzal2(ofer[i]) == oferty.getwspzal2(ofer[j]) && oferty.getwsproz1(ofer[i]) == oferty.getwsproz1(ofer[j]) && oferty.getwsproz2(ofer[i]) == oferty.getwsproz2(ofer[j]))
                        {
                            oferty.setaktywna(ofer[j], false);
                            i = j;
                        }

                    }
                    if (oferty.getczyaktywna(ofer[j]) == true) j++;
                }
                sb.AppendLine(s1);
                sr.Close();
            }
            lofert = j;
            lpunktow = 0; //poczatkowy jest zerowy!
            for (i = 1; i <= lofert; i++)
            {
                b = punkty.czyistpolaczenie(ppocz, 90, 2, 0, ofer[i - 1]);
                if (b == true)
                {
                    lpunktow++;
                    pun[lpunktow] = punkty.ofertanapunkt(ofer[i - 1], lpunktow,fra,lfrachtow);
                    gr[lpunktow-1] = new grupy(lpunktow-1);
                    populacja.setgrupa(pop, gr[lpunktow - 1]);
                    grupy.setpunkt(gr[lpunktow-1], pun[lpunktow]);
                }
            }
            k = lpunktow;
            int lpunktow1w = lpunktow;
            populacja.setlgrup(pop, lpunktow);
            System.Console.WriteLine(k);
            for (i = 1; i <= k; i++)
            {
                for (j = 1; j <= lofert; j++)
                {
                    if (oferty.getczyaktywna(ofer[j - 1]) == true)
                    {
                        b = punkty.czyistpolaczenie(pun[i], 90, 3, 0, ofer[j - 1]);
                        if (b == true)
                        {
                            if (oferty.getczyistnieje(ofer[j - 1]) == false)
                            {
                                lpunktow++;
                                pun[lpunktow] = punkty.ofertanapunkt(ofer[j - 1], lpunktow,fra,lfrachtow);
                                oferty.setczyistnieje(ofer[j - 1], lpunktow);
                            }
                        }
                    }

                }
            }
            int lpunktow2w = lpunktow - lpunktow1w;
            for (i = 0; i < populacja.getlgrup(pop); i++)
            {
                grupy.zacznijpolowanie(gr[i], ppocz, lpunktow1w, lpunktow2w, pun, lfrachtow, fra, 1, pop);
                populacja.wymianamiedzygrupami(pop);
            }
            for (j = 1; j < 100; j++)
            {
                System.Console.WriteLine(j);
                //System.Console.ReadKey();
                for (i = 0; i < populacja.getlgrup(pop); i++)
                {
                    System.Console.WriteLine(i);
                    grupy.zacznijpolowanie(gr[i], ppocz, lpunktow1w, lpunktow2w, pun, lfrachtow, fra, 2, pop);
                    populacja.wymianamiedzygrupami(pop);
                }
            }
            grupy.najliczniejsze(pop, gr);
            System.Console.ReadKey();
        }
    }
}
