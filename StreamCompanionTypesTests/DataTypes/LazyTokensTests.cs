using System;
using NUnit.Framework;

namespace StreamCompanionTypes.DataTypes.Tests
{
    [TestFixture()]
    public class LazyTokensTests
    {
        private Tokens.TokenSetter _tokenSetter;
        private static int _tokenNumber;
        private static string TokenName() => $"token_{nameof(LazyTokensTests)}_{_tokenNumber++}";
        [SetUp]
        public void Initialize()
        {
            _tokenSetter = Tokens.CreateTokenSetter("test");
        }

        private Lazy<object> LValue(object value) => new Lazy<object>(() => value);

        [Test]
        public void OutputsSameValue()
        {
            var rawValue = "testValue";
            var value = LValue(rawValue);
            var token = _tokenSetter(TokenName(), value);
            Assert.IsTrue(token.FormatIsValid);
            Assert.AreEqual(rawValue, token.Value);
            Assert.AreEqual(value.Value, token.FormatedValue);
        }

        [Test]
        public void FormatsValue()
        {
            var rawValue = 123;
            var value = LValue(rawValue);
            var token = _tokenSetter(TokenName(), value, format: "{0}1234");
            Assert.IsTrue(token.FormatIsValid);
            Assert.AreEqual(rawValue, token.Value);
            Assert.AreEqual($"{rawValue}1234", token.FormatedValue);
        }

        [Test]
        public void UpdatesCorrectlyUsingValue()
        {
            var rawValue = 123;
            var value = LValue(rawValue);
            var token = _tokenSetter(TokenName(), value);

            rawValue = 333;
            token.Value = value = LValue(rawValue);

            Assert.IsTrue(token.FormatIsValid);
            Assert.AreEqual(rawValue, token.Value);
            Assert.AreEqual($"{rawValue}", token.FormatedValue);
        }

        [Test]
        public void UpdatesCorrectlyUsingTokenSetter()
        {
            var rawValue = 123;
            var value = LValue(rawValue);
            var tokenName = TokenName();
            var token1 = _tokenSetter(tokenName, value);
            rawValue = 333;
            var token2 = _tokenSetter(tokenName, LValue(rawValue));

            Assert.AreEqual(token1, token2);
            Assert.IsTrue(token1.FormatIsValid);
            Assert.AreEqual(rawValue, token1.Value);
            Assert.AreEqual($"{rawValue}", token1.FormatedValue);
        }
    }
}