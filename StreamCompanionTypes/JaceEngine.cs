using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Jace;
using Jace.Execution;

namespace StreamCompanionTypes
{
    public class JaceEngine
    {
        public static JaceEngine Instance = new JaceEngine();
        public static string FormatErrorMessage = "One of the tokens is invalid";
        private readonly Regex _formulaMatcher = new Regex("\\{(.*?)\\}", RegexOptions.Compiled);
        private readonly Regex _formulaFormatMatcher = new Regex(" :(.*?)$", RegexOptions.Compiled);
        public CalculationEngine Engine { get; } = new CalculationEngine(CultureInfo.InvariantCulture, ExecutionMode.Compiled);

        private JaceEngine()
        {
        }

        public Dictionary<string, (string format, Func<IDictionary<string, double>, double> Func)> CompileFormulas(string formula)
        {
            var result = new Dictionary<string, (string format, Func<IDictionary<string, double>, double> Func)>();

            foreach (Match match in _formulaMatcher.Matches(formula))
            {
                var originalFormula = match.Groups[0].Value;
                var textFormula = match.Groups[1].Value;
                var formatMatch = _formulaFormatMatcher.Match(textFormula);
                string format = string.Empty;

                if (formatMatch.Success)
                {
                    format = formatMatch.Groups[1].Value;
                    textFormula = textFormula.Replace($" :{format}", "");
                }

                Func<IDictionary<string, double>, double> compiled = DoubleNaN;
                try
                {
                    compiled = Engine.Build(textFormula);
                }
                catch (Exception)
                {
                    format = string.Empty;
                }

                if (!result.ContainsKey(originalFormula))
                    result.Add(originalFormula, (format, compiled));
            }

            return result;
        }

        public string FormatFormulas(string textFormula,
            Dictionary<string, (string format, Func<IDictionary<string, double>, double> Func)> compiledFormulas, IDictionary<string, double> variables)
        {
            foreach (var formula in compiledFormulas)
            {
                try
                {
                    textFormula = textFormula.Replace(formula.Key,
                        formula.Value.Func(variables).ToString(formula.Value.format, CultureInfo.InvariantCulture));
                }
                catch (VariableNotDefinedException)
                {
                    textFormula = textFormula.Replace(formula.Key, $"{{{FormatErrorMessage}}}");
                }
            }

            return textFormula;
        }

        private double DoubleNaN(IDictionary<string, double> z) => double.NaN;
    }
}