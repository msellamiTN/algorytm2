﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytm22
{
    class populacja
    {
        int liczbagrup;
        grupy[] gr=new grupy[700];
        pingwiny pgbest=new pingwiny(0,50000);

        public populacja()
        {
            liczbagrup = 0;
            for (int j = 0; j < 700; j++)
            {
                this.gr[j] = new grupy(j);
            }
        }
        public static void setgrupa(populacja p, grupy g)
        {
            p.gr[p.liczbagrup] = g;
            p.liczbagrup++;
        }
        public static grupy getgrupa(populacja p, int i)
        {
            return p.gr[i];
        }
        public static pingwiny getpgbest(populacja p)
        {
            return p.pgbest;
        }
        public static void setlgrup(populacja p, int l)
        {
            p.liczbagrup = l;
        }
        public static int getlgrup(populacja p)
        {
            return p.liczbagrup;
        }
        public static void wymianamiedzygrupami(populacja p)
        {
            int i = 0;
            for (i = 0; i < p.liczbagrup; i++)
            {
                grupy.wymianainformacji(p.gr[i]);
            }
            double best = pingwiny.getpozywienie(grupy.getbest(p.gr[0]));
            pingwiny pin = new pingwiny(0,50000);
            pin=grupy.getbest(p.gr[0]);
            for (i = 1; i < p.liczbagrup; i++)
            {
                if (pingwiny.getpozywienie(grupy.getbest(p.gr[i])) > best)
                {
                    best = pingwiny.getpozywienie(grupy.getbest(p.gr[i]));
                    pin = grupy.getbest(p.gr[i]);
                }
            }
            p.pgbest = pin;
        }
    }
}
