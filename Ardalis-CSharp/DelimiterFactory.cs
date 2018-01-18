using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalcKata
{
    public class DelimiterFactory : IDelimiterFactory
    {
        private List<string> _defaultDelimiters = new List<string>() { ",", "\n" };
        private List<string> _customDelimiters = new List<string>();
        public ParsedInputResult GetAndTrimDelimiters(string input)
        {
            string numberString = GetDifferentDelimiters(input);
            _defaultDelimiters.AddRange(_customDelimiters);
            return new ParsedInputResult
            {
                Delimiters = _defaultDelimiters,
                InputNumbers = numberString
            };
        }

        private string GetDifferentDelimiters(string input)
        {
            if (!input.StartsWith("//")) return input;
            var parts = input.TrimStart('/').Split('\n');

            string delimiterString = parts.First();

            LoadCustomDelimiters(delimiterString);

            int numberStart = input.IndexOf('\n');
            return input.Substring(numberStart);
        }

        private void LoadCustomDelimiters(string delimiter)
        {
            // pull delimiters out of [*][**] format
            var delims = delimiter
                .TrimStart('[')
                .TrimEnd(']')
                .Split("][", StringSplitOptions.None)
                .ToArray();
            _customDelimiters.AddRange(delims);
        }


    }
}
