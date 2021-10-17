using System.Collections.Generic;
using CharacterStringsAlgorithms.T9;
using Xunit;

namespace CharacterStringsAlgorithms.Tests
{
    public class T9Tests
    {
        // http://poj.org/problem?id=1451

        [Fact]
        public void T9Test1()
        {
            var dic = new Dictionary<string, int>
            {
                ["hell"] = 3,
                ["hello"] = 4,
                ["idea"] = 8,
                ["next"] = 8,
                ["super"] = 3
            };

            var t9 = new T9DictionaryCalculator(dic);

            Assert.Equal("i", t9.Propose("4"));
            Assert.Equal("id", t9.Propose("43"));
            Assert.Equal("hel", t9.Propose("435"));
            Assert.Equal("hell", t9.Propose("4355"));
            Assert.Equal("hello", t9.Propose("43556"));

            Assert.Equal("i", t9.Propose("4"));
            Assert.Equal("id", t9.Propose("43"));
            Assert.Equal("ide", t9.Propose("433"));
            Assert.Equal("idea", t9.Propose("4332"));
        }

        [Fact]
        public void T9Test2()
        {
            var dic = new Dictionary<string, int>
            {
                ["another"] = 5,
                ["contest"] = 6,
                ["follow"] = 3,
                ["give"] = 13,
                ["integer"] = 6,
                ["new"] = 14,
                ["program"] = 4
            };

            var t9 = new T9DictionaryCalculator(dic);

            Assert.Equal("p", t9.Propose("7"));
            Assert.Equal("pr", t9.Propose("77"));
            Assert.Equal("pro", t9.Propose("776"));
            Assert.Equal("prog", t9.Propose("7764"));
            Assert.Equal("progr", t9.Propose("77647"));
            Assert.Equal("progra", t9.Propose("776472"));
            Assert.Equal("program", t9.Propose("7764726"));

            Assert.Equal("n", t9.Propose("6"));
            Assert.Equal("ne", t9.Propose("63"));
            Assert.Equal("new", t9.Propose("639"));

            Assert.Equal("g", t9.Propose("4"));
            Assert.Equal("in", t9.Propose("46"));
            Assert.Equal("int", t9.Propose("468"));

            Assert.Equal("c", t9.Propose("2"));
            Assert.Equal("co", t9.Propose("26"));
            Assert.Equal("con", t9.Propose("266"));
            Assert.Equal("cont", t9.Propose("2668"));
            Assert.Equal("anoth", t9.Propose("26684"));
            Assert.Equal("anothe", t9.Propose("266843"));
            Assert.Equal("another", t9.Propose("2668437"));

            Assert.Equal("p", t9.Propose("7"));
            Assert.Equal("pr", t9.Propose("77"));
            Assert.Equal("MANUALLY", t9.Propose("777"));
            Assert.Equal("MANUALLY", t9.Propose("7777"));
        }
    }
}
