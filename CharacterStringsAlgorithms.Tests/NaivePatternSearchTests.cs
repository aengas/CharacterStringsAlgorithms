using CharacterStringsAlgorithms.NaivePatternSearch;
using Xunit;

namespace CharacterStringsAlgorithms.Tests
{
    public class NaivePatternSearchTests
    {
        [Fact]
        public void NaivePatternSearchTest1()
        {
            const string InputString = "lalopalalali";
            const string InputPattern = "lala";
            const int ExpectedOutput = 6;

            int output = NaivePatternSearcher.Search(InputString, InputPattern);

            Assert.Equal(ExpectedOutput, output);
        }

        [Fact]
        public void NaivePatternSearchTest2()
        {
            const string InputString = "lalopalala";
            const string InputPattern = "lala";
            const int ExpectedOutput = 6;

            int output = NaivePatternSearcher.Search(InputString, InputPattern);

            Assert.Equal(ExpectedOutput, output);
        }
        
        [Fact]
        public void NaivePatternSearchTest3()
        {
            const string InputString = "lalopalila";
            const string InputPattern = "lala";
            const int ExpectedOutput = -1;

            int output = NaivePatternSearcher.Search(InputString, InputPattern);

            Assert.Equal(ExpectedOutput, output);
        }

        [Fact]
        public void NaivePatternSearchTest4()
        {
            const string InputString = "THIS IS A TEST TEXT";
            const string InputPattern = "TEST";
            const int ExpectedOutput = 10;

            int output = NaivePatternSearcher.Search(InputString, InputPattern);

            Assert.Equal(ExpectedOutput, output);
        }
    }
}
