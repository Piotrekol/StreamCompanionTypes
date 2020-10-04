using StreamCompanionTypes.Enums;
using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace StreamCompanionTypes.DataTypes
{
    public class Token : IToken
    {
        public TokenType Type { get; set; }
        private object RawValue { get; set; }
        public bool FormatIsValid { get; private set; }

        /// <summary>
        /// in what <see cref="OsuStatus"/>es this token can be saved in
        /// </summary>
        public OsuStatus StatusWhitelist { get; set; }

        public virtual bool CanSave(OsuStatus status) => (StatusWhitelist & status) != 0;

        public virtual object Value
        {
            get => RawValue;
            set
            {
                //Allow null and type this token has been initialized with
                Debug.Assert(RawValue == null || value == null || value.GetType() == RawValue.GetType(), "Attempted changing type of already created token!");

                RawValue = value;
                _formattedValueCreated = false;
            }
        }

        protected string FormatTokenValue(object value)
        {
            string formattedValue;
            if (value is null)
                formattedValue = "";
            else
            {
                var formatIsValid = FormatIsValid;
                formattedValue = string.IsNullOrEmpty(Format)
                    ? value.ToString()
                    : TryFormat(CultureInfo.InvariantCulture, Format, out formatIsValid, value);

                if (formattedValue.StartsWith("Eval:"))
                {
                    var result = Evaluate(formattedValue.Substring(5, formattedValue.Length - 5));
                    formattedValue = result.ToString(CultureInfo.InvariantCulture);
                }

                FormatIsValid = formatIsValid;
            }

            return formattedValue;
        }

        protected object DefaultValue { get; private set; }
        private string _format;
        private string _formatedValue;
        private bool _formattedValueCreated;

        public string Format
        {
            get => _format;
            set
            {
                _format = value;
                FormatIsValid = true;
                Value = RawValue;
            }
        }

        public string FormatedValue
        {
            get
            {
                if (!FormatIsValid)
                    return string.Empty;

                if (!_formattedValueCreated)
                    _formatedValue = FormatTokenValue(Value);

                return _formatedValue;
            }
            set => _formatedValue = value;
        }

        /// <summary>
        /// Name of the plugin that created this token
        /// </summary>
        public string PluginName { get; set; }

        internal Token(object value, TokenType type = TokenType.Normal, string format = null,
            object defaultValue = null, OsuStatus whitelist = OsuStatus.All)
        {
            Debug.Assert(!(value is IToken));

            _format = format;
            StatusWhitelist = whitelist;
            DefaultValue = defaultValue;
            Type = type;
            RawValue = value;
        }

        public void Reset()
        {
            Value = DefaultValue;
        }

        public IToken Clone()
        {
            return (IToken)this.MemberwiseClone();
        }

        private static string TryFormat(IFormatProvider formatProvider, string format, out bool valid,
            params object[] args)
        {
            var result = "INVALID FORMAT";
            try
            {
                if (args[0] is IEnumerable enumerableArg)
                    result = string.Join(format, enumerableArg.Cast<object>());
                else
                    result = string.Format(formatProvider, format, args);

                valid = true;
            }
            catch (FormatException)
            {
                valid = false;
            }

            return result;
        }

        public double Evaluate(string expression)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("expression", typeof(string), expression);
                DataRow row = table.NewRow();
                table.Rows.Add(row);
                return double.Parse(((string)row["expression"]).Replace(',', '.'), CultureInfo.InvariantCulture);
            }
            catch
            {
                FormatIsValid = false;
                return Double.NaN;
            }
        }
    }
}