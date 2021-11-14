namespace CharacterStringsAlgorithms.NaivePatternSearch
{
    public class NaivePatternSearcher
    {
        public static int Search(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            for (int i = 0; i <= n - m; i++)
            {
                int j;
                for (j = 0; j < m; j++)
                {
                    if (t[j] != s[i + j])
                    {
                        break;
                    }
                }

                if (j == m)
                {   
                    return i;
                }
            }

            return -1;
        }
    }
}
