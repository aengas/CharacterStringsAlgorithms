using System;

namespace CharacterStringsAlgorithms.Levensthein
{
    public class LevenshteinCalculator
    {
        public static int[,] Levenshtein(string x, string y)
        {
            int n = x.Length;
            int m = y.Length;

            // Lag tabellen A
            //   Rad 0 og kolonne 0 blir initialisert som det er påkrevd
            //   De gjenstående tallene blir overskrevet under beregningen
            var A = new int[n + 1, m + 1];
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < m + 1; j++)
                {
                    A[i, j] = i + j;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    A[i + 1, j + 1] = Min(A[i, j + 1] + 1,                               // innsetting
                        A[i + 1, j] + 1,                              // sletting
                        A[i, j] + Convert.ToInt32(x[i] != y[j]));     // bytting
                }
            }

            return A;
        }

        private static int Min(int x, int y, int z)
        {
            return Math.Min(x, Math.Min(y, z));
        }
    }
}
