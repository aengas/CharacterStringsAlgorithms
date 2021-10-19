using System.Text;
using CharacterStringsAlgorithms.Levensthein;
using Xunit;
using Xunit.Abstractions;

namespace CharacterStringsAlgorithms.Tests
{
    public class LevenshteinTests
    {
        private readonly ITestOutputHelper m_output;

        public LevenshteinTests(ITestOutputHelper output)
        {
            m_output = output;
        }
        
        [Fact]
        public void LevenshteinTest1()
        {
            int[,] levenshteinArray = LevenshteinCalculator.Levenshtein("sitting", "kitten");

            Print2DArray("sitting", "kitten", levenshteinArray);
        }

        [Fact]
        public void LevenshteinTest2()
        {
            int[,] levenshteinArray = LevenshteinCalculator.Levenshtein("AUDI", "LADA");

            Print2DArray("AUDI", "LADA", levenshteinArray);
            Assert.Equal(3, levenshteinArray[4, 4]);
        }

        // https://www.spoj.com/problems/EDIST/
        [Fact]
        public void LevenshteinTest3()
        {
            int[,] levenshteinArray = LevenshteinCalculator.Levenshtein("FOOD", "MONEY");

            Print2DArray("FOOD", "MONEY", levenshteinArray);
            Assert.Equal(4, levenshteinArray[4, 5]);
        }

        private void Print2DArray<T>(string vertical, string horizontal, T[,] matrix)
        {
            int verticalCount = 0;
            var horStrb = new StringBuilder();
            horStrb.Append("\t\t");
            foreach (char h in horizontal)
            {
                horStrb.Append(h + "\t");
            }
            m_output.WriteLine(horStrb.ToString());
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var strb = new StringBuilder();
                if (i > 0)
                {
                    strb.Append(vertical[verticalCount++] + "\t");
                }
                else
                {
                    strb.Append('\t');
                }
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    strb.Append(matrix[i, j] + "\t");
                }
                m_output.WriteLine(strb.ToString());
            }
        }

        // Oppgave med utvidelse:
        // https://www.spoj.com/problems/ADVEDIST/
        
    }
}
