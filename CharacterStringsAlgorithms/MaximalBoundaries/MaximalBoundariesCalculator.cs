using System;
using System.Linq;

namespace CharacterStringsAlgorithms.MaximalBoundaries
{
    public class MaximalBoundariesCalculator
    {
        public static int[] MaximumBorderLength(string w)
        {
            int n = w.Length;

            var f = new int[n];                         // init f[0] = 0
            int k = 0;                                  // nåværende lengste grenselengde
            for (int i = 1; i < n; i++)                 // beregn f[i]
            {
                while (w[k] != w[i] && k > 0)
                {
                    k = f[k - 1];                       // mismatch: prøv neste grense
                }

                if (w[k] == w[i])                       // siste bokstaver matcher
                {
                    k++;                                // vi kan inkrementere grenselengden
                }

                f[i] = k;                               // vi har funnet den maksimale grensen til w[:i + 1]    
            }

            return f;
        }

        public static string LongestBoundaryPalindrome(string x)
        {
            string xPal = new(x.Reverse().ToArray());
            string x2 = x + xPal;
            int[] f = MaximumBorderLength(x + xPal);
            int length = f[x2.Length - 1];
            return x.Substring(x.Length - length, length);
        }

        public static int KnuthMorrisPratt(string s, string t)
        {
            char sep = '\x00';                          // spesielt ubrukt tegn
            if (s.Contains(sep) || t.Contains(sep))
            {
                throw new Exception("strengene inneholder separator");
            }
            
            int[] f = MaximumBorderLength(t + sep + s);

            int n = t.Length;

            for (int i = 0; i < f.Length; i++)
            {
                if (f[i] == n)                          // fant en grense med lengde t
                {
                    return i - 2 * n;                   // begynnelsen på grensen i s
                }
            }

            return -1;
        }

        // Denne fungerte i https://open.kattis.com/problems/powerstrings
        public static int PowerstringByBorder(string u)
        {
            int[] f = MaximumBorderLength(u);

            int n = u.Length;

            if (n % (n - f[^1]) == 0)                   // deler justeringsforskyvningen seg i n ?
            {
                return n / (n - f[^1]);                 // vi har funnet en potens-dekomposisjon
            }

            return 1;
        }

        // Denne timet ut i https://open.kattis.com/problems/powerstrings
        public static int PowerstringByFind(string u)
        {
            return u.Length / (u + u).IndexOf(u, 1);
        }

        public static bool Conjugate(string x, string y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            
            return KnuthMorrisPratt(x + x, y) >= 0;
        }
    }
}
