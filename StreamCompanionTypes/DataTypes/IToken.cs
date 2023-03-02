using StreamCompanionTypes.Enums;
using System;

namespace StreamCompanionTypes.DataTypes
{
    public interface IToken
    {
        string Name { get; }
        TokenType Type { get; set; }
        bool FormatIsValid { get; }
        /// <summary>
        /// in what <see cref="OsuStatus"/>es this token can be saved in
        /// </summary>
        OsuStatus StatusWhitelist { get; set; }

        object Value { get; set; }
        event EventHandler<IToken> ValueUpdated;
        string Format { get; set; }
        string FormatedValue { get; set; }

        /// <summary>
        /// Name of the plugin that created this token
        /// </summary>
        string PluginName { get; set; }

        bool CanSave(OsuStatus status);
        void Reset();
        IToken Clone();
        double Evaluate(string expression);
    }
}