using CharacterStringsAlgorithms.MaximalBoundaries;
using Xunit;

namespace CharacterStringsAlgorithms.Tests
{
    public class MaximalBoundariesTests
    {
        [Fact]
        public void MaximalBorderLengthTest1()
        {
            string input = "abaababaa";
            int[] expectedOutput = { 0, 0, 1, 1, 2, 3, 2, 3, 4 };

            int[] output = MaximalBoundariesCalculator.MaximumBorderLength(input);
            
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void KnuthMorrisPrattTest1()
        {
            string input1 = "supercalifragilisticexpialidocious";
            string input2 = "fragil";
            int expectedOutput = 9;

            int output = MaximalBoundariesCalculator.KnuthMorrisPratt(input1, input2);

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void KnuthMorrisPrattTest2()
        {
            string input1 = "ababaabaa";
            string input2 = "abaa";
            int expectedOutput = 2;

            int output = MaximalBoundariesCalculator.KnuthMorrisPratt(input1, input2);

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void PowerstringTest1()
        {
            string input = "blablabla";
            int expectedOutput = 3;

            int output = MaximalBoundariesCalculator.PowerstringByBorder(input);

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void PowerstringTest2()
        {
            string input = "blablabla";
            int expectedOutput = 3;

            int output = MaximalBoundariesCalculator.PowerstringByFind(input);

            Assert.Equal(expectedOutput, output);
        }

        // https://open.kattis.com/problems/powerstrings
        [Fact]
        public void PowerstringTest3()
        {
            Assert.Equal(1, MaximalBoundariesCalculator.PowerstringByFind("abcd"));
            Assert.Equal(4, MaximalBoundariesCalculator.PowerstringByFind("aaaa"));
            Assert.Equal(3, MaximalBoundariesCalculator.PowerstringByFind("ababab"));
        }

        [Fact]
        public void ConjugateTest1()
        {
            string input1 = "sweetsour";
            string input2 = "soursweet";

            bool output = MaximalBoundariesCalculator.Conjugate(input1, input2);

            Assert.True(output);
        }
    }
}
