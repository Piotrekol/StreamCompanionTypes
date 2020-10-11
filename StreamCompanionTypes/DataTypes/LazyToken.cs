using System;
using System.Diagnostics;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.DataTypes
{
    public class LazyToken<T> : Token
        where T : class
    {
        protected Lazy<T> Lazy { get; private set; }
        internal LazyToken(Lazy<T> value, TokenType type = TokenType.Normal, string format = null, T defaultValue = null, OsuStatus whitelist = OsuStatus.All) : base(value, type, format, defaultValue, whitelist)
        {
            Lazy = value ?? new Lazy<T>(() => defaultValue);
        }

        public override object Value
        {
            get => Lazy.Value;
            set
            {
                base.Value = value;
                Debug.Assert(value.GetType().IsGenericType && value.GetType().GetGenericTypeDefinition() == typeof(Lazy<>), "Cannot set plain value in LazyToken");
                Lazy = (Lazy<T>)value;
            }
        }
    }
}