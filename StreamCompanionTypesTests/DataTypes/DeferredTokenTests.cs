using System;
using System.Threading;
using NUnit.Framework;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.DataTypes.Tests
{
    [TestFixture]
    public class DeferredTokenTests
    {
        private static int _tokenNumber;

        private static string TokenName()
        {
            return $"token_{nameof(DeferredTokenTests)}_{_tokenNumber++}";
        }

        [Test]
        public void ReadReturnsInitialValue()
        {
            var token = Tokens.CreateDeferredToken("test", TokenName(), "init");
            Assert.AreEqual("init", token.Value);
        }

        [Test]
        public void RecomputeSkippedWhenNotRead()
        {
            var calls = 0;
            var token = Tokens.CreateDeferredToken("test", TokenName(), 0);

            token.Recompute(() =>
            {
                calls++;
                return 1;
            }, OsuStatus.All);

            Assert.AreEqual(0, calls, "updater must not run while dormant");
            Assert.AreEqual(0, token.Value);
        }

        [Test]
        public void RecomputeRunsAndFiresAfterRead()
        {
            var token = Tokens.CreateDeferredToken("test", TokenName(), 0);
            var fired = 0;
            token.ValueUpdated += (s, t) => fired++;

            _ = token.Value;
            token.Recompute(() => 5, OsuStatus.All);

            Assert.AreEqual(1, fired, "ValueUpdated must fire once when the updater runs");
            Assert.AreEqual(5, token.Value);
        }

        [Test]
        public void StaysAwakeAcrossMultipleTicksWithinGrace()
        {
            var calls = 0;
            Func<object> updater = () =>
            {
                calls++;
                return calls;
            };
            var token = Tokens.CreateDeferredToken("test", TokenName(), 0);

            _ = token.Value;
            token.Recompute(updater, OsuStatus.All);
            token.Recompute(updater, OsuStatus.All);
            token.Recompute(updater, OsuStatus.All);
            token.Recompute(updater, OsuStatus.All);
            token.Recompute(updater, OsuStatus.All);

            Assert.AreEqual(5, calls, "updater must run every tick while within the grace window");
        }

        [Test]
        public void GoesDormantAfterGraceExpires()
        {
            var calls = 0;
            Func<object> updater = () =>
            {
                calls++;
                return calls;
            };
            var token = Tokens.CreateDeferredToken("test", TokenName(), 0);

            var previousGrace = DeferredToken.GraceMs;
            DeferredToken.GraceMs = 50;
            try
            {
                _ = token.Value;
                token.Recompute(updater, OsuStatus.All);
                Assert.AreEqual(1, calls, "updater must run immediately after a read");

                Thread.Sleep(150);
                token.Recompute(updater, OsuStatus.All);
                Assert.AreEqual(1, calls, "updater must not run once the grace window expires with no further read");
            }
            finally
            {
                DeferredToken.GraceMs = previousGrace;
            }
        }

        [Test]
        public void GraceMsClampedToMinimum()
        {
            var previousGrace = DeferredToken.GraceMs;
            DeferredToken.GraceMs = 5;
            try
            {
                Assert.AreEqual(20, DeferredToken.GraceMs, "GraceMs below 20 must be clamped to 20");
            }
            finally
            {
                DeferredToken.GraceMs = previousGrace;
            }
        }

        [Test]
        public void RecomputeResetsToDefaultWhenStatusDisallowed()
        {
            var token = Tokens.CreateDeferredToken("test", TokenName(), 9, defaultValue: 0, whitelist: OsuStatus.Playing);

            _ = token.Value;
            token.Recompute(() => 9, OsuStatus.Listening);

            Assert.AreEqual(0, token.Value);
        }
    }
}
