using StreamCompanionTypes.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
                token = new Token(value, type, format, defaultValue, whitelist) { PluginName = pluginName };
                _AllTokens[tokenName] = token;

                if ((type & TokenType.Live) != 0)
                    OutputPattern.AddLiveToken(tokenName);

                AllTokensChanged?.Invoke(null, tokenName);
            }

            return token;
        }

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