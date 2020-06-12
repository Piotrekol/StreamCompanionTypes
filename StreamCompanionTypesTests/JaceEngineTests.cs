using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using StreamCompanionTypes;
using Assert = NUnit.Framework.Assert;

namespace StreamCompanionTypesTests
{
    [TestFixture()]
    public class JaceEngineTests
    {
        private Dictionary<string, double> variables;
        JaceEngine JaceEngine = JaceEngine.Instance;

        [SetUp]
        public void Initialize()
        {
            variables = new Dictionary<string, double>
            {
                {"var1", 1},
                {"var2", 50},
                {"vaR3", 3.3},
                {"liveVar1", 11d},
                {"liveVar2", 22d},
            };
        }

        [TestCase(@"{var1}!mapArtistTitle!", @"1!mapArtistTitle!", 1)]
        [TestCase(@"{var1*2}!mapArtistTitle!", @"2!mapArtistTitle!", 1)]
        [TestCase(@"{var1*2+2}!mapArtistTitle!", @"4!mapArtistTitle!", 1)]
        [TestCase(@"{var1+var2}!mapArtistTitle!", @"51!mapArtistTitle!", 1)]
        [TestCase(@"{var1+vAR2}!mapArtistTitle!", @"51!mapArtistTitle!", 1)]
        [TestCase(@"{if(var1>var2,2,3)}!mapArtistTitle!", @"3!mapArtistTitle!", 1)]
        [TestCase(@"{var1}{var1}!mapArtistTitle!", @"11!mapArtistTitle!", 1)]
        [TestCase(@"{var1} {var1}!mapArtistTitle!", @"1 1!mapArtistTitle!", 1)]
        [TestCase(@"{var1} {var2%20}!mapArtistTitle!", @"1 10!mapArtistTitle!", 2)]
        [TestCase(@"{var1*5} {var1}!mapArtistTitle! {var2}", @"5 1!mapArtistTitle! 50", 3)]
        [TestCase(@"{var3}!mapArtistTitle!", @"3.3!mapArtistTitle!", 1)]
        [TestCase(@"{var3 :0.00}!mapArtistTitle!", @"3.30!mapArtistTitle!", 1)]
        [TestCase(@"{var3 :0.}!mapArtistTitle!", @"3!mapArtistTitle!", 1)]
        [TestCase(@"{var3 ;0.}!mapArtistTitle!", @"NaN!mapArtistTitle!", 1)]
        [TestCase(@"{var33 :0.}!mapArtistTitle!", "{One of the tokens is invalid}!mapArtistTitle!", 1)]
        [TestCase(@"{var3+mods :0.}!mapArtistTitle!", "{One of the tokens is invalid}!mapArtistTitle!", 1)]
        [TestCase(@"{liveVar1 :0.}!mapArtistTitle!", "11!mapArtistTitle!", 1,true)]
        [TestCase(@"{liveVar1+var3 }!mapArtistTitle!", "14.3!mapArtistTitle!", 1,true)]
        [TestCase(@"{liveVar2 :0.}!mapArtistTitle!", "22!mapArtistTitle!", 1,true)]
        [Test()]
        public void FormatsCorrectly(string textFormula, string expectedOutput, int expectedCompiledFormulas, bool isLive = false)
        {
            var formulas = JaceEngine.CompileFormulas(textFormula);
            var formatted = JaceEngine.FormatFormulas(textFormula, formulas, variables);
            var usedTokens = formulas
                .SelectMany(kv => kv.Value.TokensUsed)
                .ToList();

            Assert.AreEqual(usedTokens.Contains("liveVar1") || usedTokens.Contains("liveVar2"), isLive);
            Assert.AreEqual(expectedCompiledFormulas, formulas.Count);
            Assert.AreEqual(expectedOutput, formatted);
        }
    }
}