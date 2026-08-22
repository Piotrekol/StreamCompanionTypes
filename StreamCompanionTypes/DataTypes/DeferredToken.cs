using System;
using System.Threading;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.DataTypes
{
    /// <summary>
    /// Live token that stays dormant(its value is not computed) until its <see cref="Value"/> is read.
    /// When no read has occurred for <see cref="GraceMs"/> it goes back dormant and the updater stops running.
    /// </summary>
    public class DeferredToken : Token
    {
        /// <summary>
        /// Ms after the most recent read during which a deferred token keeps refreshing every worker tick before going dormant.
        /// </summary>
        public static int GraceMs
        {
            get => field;
            set => field = Math.Max(20, value);
        } = 2500;

        private long _lastReadTicks;

        internal DeferredToken(string name, object value, TokenType type = TokenType.Normal, string format = null,
            object defaultValue = null, OsuStatus whitelist = OsuStatus.All)
            : base(name, value, type, format, defaultValue, whitelist)
        {
        }

        public override object Value
        {
            get
            {
                Volatile.Write(ref _lastReadTicks, Environment.TickCount64);
                return base.Value;
            }
        }

        public void Recompute(Func<object> updater, OsuStatus status)
        {
            long last = Volatile.Read(ref _lastReadTicks);
            if (last == 0 || Environment.TickCount64 - last > GraceMs)
            {
                return;
            }

            if (!CanSave(status))
            {
                Reset();
            }
            else
            {
                Value = updater();
            }
        }
    }
}
