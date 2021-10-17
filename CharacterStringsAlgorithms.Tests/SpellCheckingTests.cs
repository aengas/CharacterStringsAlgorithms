using CharacterStringsAlgorithms.SpellChecking;
using Xunit;

namespace CharacterStringsAlgorithms.Tests
{
    public class SpellCheckingTests
    {
        // https://icpcarchive.ecs.baylor.edu/index.php?option=com_onlinejudge&Itemid=8&page=show_problem&problem=1873

        [Fact]
        public void SpellCheckerTest1()
        {
            var spellChecker = new SpellChecker(new[] { "CHILL", "CHELLO", "BELLOW", "HELL", "ASBJORN" });

            Assert.Equal("HELL", spellChecker.SpellCheck("HELL"));
            Assert.Equal("CHILL", spellChecker.SpellCheck("CHAMP"));
            Assert.Equal("CHILL", spellChecker.SpellCheck("CHELL"));
            Assert.Equal("CHELLO", spellChecker.SpellCheck("THELLO"));
            Assert.Equal("CHELLO", spellChecker.SpellCheck("THELLI"));
            Assert.Equal("ASBJORN", spellChecker.SpellCheck("ABSJORN"));
        }

        [Fact]
        public void SpellCheckerTest2()
        {
            var spellChecker = new SpellChecker(new[] { "HI", "HO" });

            Assert.Equal("HI", spellChecker.SpellCheck("HUM"));
        }
    }
}
