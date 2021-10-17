using System.Collections.Generic;
using CharacterStringsAlgorithms.Anagrams;
using Xunit;

namespace CharacterStringsAlgorithms.Tests
{
    public class AnagramTests
    {
        [Fact]
        public void AnagramTest1()
        {
            string input = "below the car is a rat drinking cider and bending its elbow while this thing is an arc that can act like a cat which cried during the night caused by pain in its bowel";
            var expectedOutput = new List<HashSet<string>>
            {
                new() { "below", "elbow", "bowel" }, 
                new() { "car", "arc" },
                new() { "cider", "cried" },
                new() { "thing", "night" },
                new() { "act", "cat" }
            };
            
            List<HashSet<string>> output = AnagramCalculator.Anagrams(input.Split(' '));

            Assert.Equal(expectedOutput, output);
        }

        // https://www.spoj.com/problems/ANGRAM/

        [Fact]
        public void AnagramTest2()
        {
            string input = "tommarvoloriddle iamlordvoldemort";
            var expectedOutput = new List<HashSet<string>>
            {
                new() { "tommarvoloriddle", "iamlordvoldemort" }
            };

            List<HashSet<string>> output = AnagramCalculator.Anagrams(input.Split(' '));

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void AnagramTest3()
        {
            string input = "aaa aba";
            var expectedOutput = new List<HashSet<string>>();

            List<HashSet<string>> output = AnagramCalculator.Anagrams(input.Split(' '));

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void AnagramTest4()
        {
            string input = "iamaweakishspeller williamshakespeare";
            var expectedOutput = new List<HashSet<string>>
            {
                new() { "iamaweakishspeller", "williamshakespeare" }
            };

            List<HashSet<string>> output = AnagramCalculator.Anagrams(input.Split(' '));

            Assert.Equal(expectedOutput, output);
        }
    }
}
