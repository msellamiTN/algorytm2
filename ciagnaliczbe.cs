using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytm22
{
    class ciagnaliczbe
    {
        public static int ciagnaint(string s)
        {
            int wynik = 0;
            int w = 0;
            for (int i = 0; i < s.Length; i++)
            {
                w = Convert.ToInt32(s[i] - 48);
                wynik = wynik + w * (int)(Math.Pow(10, s.Length - i - 1));
            }
            return wynik;
        }
        public static double ciagnadouble(string s)
        {
            double wynik = 0;
            int w = 0;
            int j = 0;
            int i = 0;
            while (i < s.Length && s[i] != '.')
            {
                j++;
                i++;
            }
            if (i < s.Length)
            {
                for (i = 0; i < j; i++)
                {
                    w = Convert.ToInt32(s[i] - 48);
                    wynik = wynik + w * (int)(Math.Pow(10, j - i - 1));
                }
                for (i = j + 1; i < s.Length; i++)
                {
                    w = Convert.ToInt32(s[i] - 48);
                    wynik = wynik + w * Math.Pow(10, j - i);
                }
            }
            else
            {
                for (i = 0; i < s.Length; i++)
                {
                    w = Convert.ToInt32(s[i] - 48);
                    wynik = wynik + w * (int)(Math.Pow(10, s.Length - i - 1));
                }
            }
            return wynik;
        }
    }
}
