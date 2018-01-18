using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalcKata
{
    public class StringCalculator
    {
        private List<string> _delimiters = new List<string>();
        private string _numbers;
        private IDelimiterFactory _delimiterFactory = new DelimiterFactory();

        public int Add(string numbers)
        {
            _numbers = numbers;
            return AddImpl();
        }

        private int AddImpl()
        {
            if (string.IsNullOrEmpty(_numbers)) return 0;

            var result = _delimiterFactory.GetAndTrimDelimiters(_numbers);
            _numbers = result.InputNumbers;
            _delimiters = result.Delimiters;

            var numberList = _numbers
                .Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(n => Int32.Parse(n))
                .ToList();

            CheckForNegatives(numberList);

            numberList = FilterInvalidNumbers(numberList);

            return numberList.Sum();
        }

        private List<int> FilterInvalidNumbers(List<int> numberList)
        {
            return numberList
                .Where(n => n <= 1000)
                .ToList();
        }

        private void CheckForNegatives(List<int> sortedNumbers)
        {
            if (!sortedNumbers.Any(n => n < 0)) return;

            var negatives = sortedNumbers.Where(n => n < 0)
                .Select(n => n.ToString())
                .ToArray();

            string numberString = String.Join(',', negatives);

            throw new NegativeNotAllowedException($"Negatives not allowed: {numberString}");

        }
    }
}
