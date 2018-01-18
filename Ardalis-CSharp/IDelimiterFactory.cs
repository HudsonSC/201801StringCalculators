using System.Collections.Generic;

namespace StringCalcKata
{
    public interface IDelimiterFactory
    {
        ParsedInputResult GetAndTrimDelimiters(string input);
    }
}