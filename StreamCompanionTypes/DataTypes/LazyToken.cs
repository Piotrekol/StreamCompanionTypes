using System;
using System.Diagnostics;
using StreamCompanionTypes.Enums;

namespace StreamCompanionTypes.DataTypes
{
    public class LazyToken<T> : Token
        where T : class
    {
        private readonly Lazy<T> _defaultLazy;
        protected Lazy<T> Lazy { get; private set; }
        internal LazyToken(Lazy<T> value, TokenType type = TokenType.Normal, string format = null, T defaultValue = null, OsuStatus whitelist = OsuStatus.All) : base(value, type, format, defaultValue, whitelist)
        {
            _defaultLazy = new Lazy<T>(() => defaultValue);
            Lazy = value ?? _defaultLazy;
        }

        public override object Value
        {
            get => Lazy.Value;
            set
            {

                base.Value = value;
                if (value == null)
                {
                    Lazy = _defaultLazy;
                    return;
                }
                
                Debug.Assert(value.GetType().IsGenericType && value.GetType().GetGenericTypeDefinition() == typeof(Lazy<>), "Cannot set plain value in LazyToken");
                Lazy = (Lazy<T>)value;
            }
        }
    }
}