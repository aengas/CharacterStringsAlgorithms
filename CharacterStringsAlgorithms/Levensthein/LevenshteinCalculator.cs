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
            //   Dimensjonen til A er (n + 1) x (m + 1) selv om strengene x og y er av lengde n og m.
            //   Dette er fordi A regner med ale prefiksene til x og y, inkludert den tomme strengen.
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
                    A[i + 1, j + 1] = Min(
                        A[i, j] + Convert.ToInt32(x[i] != y[j]),        // bytting
                        A[i + 1, j] + 1,                                // sletting
                        A[i, j + 1] + 1                                 // innsetting
                        );     
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
