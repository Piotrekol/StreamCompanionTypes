using NUnit.Framework;

namespace StreamCompanionTypes.DataTypes.Tests
{
    [TestFixture()]
    public class TokensTests
    {
        private Tokens.TokenSetter _tokenSetter;
        private static int _tokenNumber;
        private static string TokenName() => $"token_{nameof(TokensTests)}_{_tokenNumber++}";
        [SetUp]
        public void Initialize()
        {
            _tokenSetter = Tokens.CreateTokenSetter("test");
        }

        [Test]
        public void OutputsSameValue()
        {
            var value = "testValue";
            var token = _tokenSetter(TokenName(), value);
            Assert.IsTrue(token.FormatIsValid);
            Assert.AreEqual(value, token.Value);
            Assert.AreEqual(value, token.FormatedValue);
        }

        [Test]
        public void FormatsValue()
        {
            var value = 123;
            var token = _tokenSetter(TokenName(), value, format: "{0}1234");
            Assert.IsTrue(token.FormatIsValid);
            Assert.AreEqual(value, token.Value);
            Assert.AreEqual($"{value}1234", token.FormatedValue);
        }

        [Test]
        public void UpdatesCorrectlyUsingValue()
        {
            var value = 123;
            var token = _tokenSetter(TokenName(), value);

            token.Value = value = 333;

            Assert.IsTrue(token.FormatIsValid);
            Assert.AreEqual(value, token.Value);
            Assert.AreEqual($"{value}", token.FormatedValue);
        }

        [Test]
        public void UpdatesCorrectlyUsingTokenSetter()
        {
            var value = 123;
            var tokenName = TokenName();
            var token1 = _tokenSetter(tokenName, value);
            value = 333;
            var token2 = _tokenSetter(tokenName, value);

            Assert.AreEqual(token1, token2);
            Assert.IsTrue(token1.FormatIsValid);
            Assert.AreEqual(value, token1.Value);
            Assert.AreEqual($"{value}", token1.FormatedValue);
        }
    }
}