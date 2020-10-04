using StreamCompanionTypes.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace StreamCompanionTypes.DataTypes
{
    /// <summary>
    /// IToken wrapper with static methods for creating, updating and accessing tokens
    /// </summary>
    public class Tokens : Dictionary<string, IToken>
    {
        public Tokens(string groupName = "Default")
        {
            GroupName = groupName;
        }

        public string GroupName { get; set; }

        internal IDictionary<string, double> NumericTokens => this.Where(kv =>
        {
            var value = kv.Value.Value;
            return value is sbyte || value is byte || value is short || value is ushort || value is int || value is uint
                   || value is long || value is ulong || value is float || value is double || value is decimal;
        }).ToDictionary(k => k.Key, v => Convert.ToDouble(v.Value.Value));

        /// <summary>
        /// Stores all created tokens<para/>
        /// </summary>
        private static Dictionary<string, IToken> _AllTokens { get; set; } = new Dictionary<string, IToken>();

        /// <summary>
        /// <inheritdoc cref="_AllTokens"/>
        /// </summary>
        public static ReadOnlyDictionary<string, IToken> AllTokens { get; } = new ReadOnlyDictionary<string, IToken>(_AllTokens);

        /// <summary>
        /// Event fired whenever any of the tokens in <see cref="AllTokens"/> updates, with token name as parameter
        /// </summary>
        public static event EventHandler<string> AllTokensChanged;

        /// <summary>
        /// Returns existing token instance with updated value or creates new instance if it doesn't exist
        /// </summary>
        internal static IToken SetToken(string pluginName, string tokenName, object value, TokenType type = TokenType.Normal, string format = null, object defaultValue = null, OsuStatus whitelist = OsuStatus.All)
        {
            IToken token;

            if (AllTokens.ContainsKey(tokenName))
            {
                token = AllTokens[tokenName];
                token.Value = value;
            }
            else
            {
                if (tokenName.Length == 0 || !char.IsLetter(tokenName[0]))
                    throw new Exception($"Token name must start with a letter (got: \"{tokenName}\")");

                if (tokenName.Any(char.IsWhiteSpace))
                    throw new Exception($"Token name can not contain whitespace characters (got: \"{tokenName}\")");

                if (!char.IsLower(tokenName[0]))
                    throw new Exception($"First token letter must be lowercase (token name ideally should be camelCase) (got: \"{tokenName}\")");

                bool isLazy = false;
                if (value != null)
                {
                    var valueType = value.GetType();
                    isLazy = valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(Lazy<>);
                }

                token = isLazy 
                    ? new LazyToken<object>((Lazy<object>)value, type, format, defaultValue, whitelist) 
                    : new Token(value, type, format, defaultValue, whitelist);
                token.PluginName = pluginName;

                _AllTokens[tokenName] = token;

                if ((type & TokenType.Live) != 0)
                    OutputPattern.AddLiveToken(tokenName);

                AllTokensChanged?.Invoke(null, tokenName);
            }

            return token;
        }

        /// <summary>
        /// Create factory function for creating and updating of <see cref="IToken"/>s
        /// </summary>
        /// <param name="pluginName"></param>
        /// <returns></returns>
        public static TokenSetter CreateTokenSetter(string pluginName)
        {
            return (tokenName, value, type, format, defaultValue, whitelist) => SetToken(pluginName, tokenName, value, type, format, defaultValue, whitelist);
        }

        /// <summary>
        /// <inheritdoc cref="Tokens.SetToken"/>
        /// </summary>
        public delegate IToken TokenSetter(string tokenName, object value, TokenType type = TokenType.Normal,
            string format = null, object defaultValue = null, OsuStatus whitelist = OsuStatus.All);
    }
}