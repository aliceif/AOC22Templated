using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
   static class CsvHelpers
    {
        public static IEnumerable<(T1, T2)> ParseCsv<T1, T2>(
            this IEnumerable<string> input,
            Func<string, T1> parser1,
            Func<string, T2> parser2,
            char separator = ' ',
            bool multiple = true)
        {
            var parseRegex = new Regex(String.Join(separator + (multiple ? "+" : ""), Helpers.Times(2, $@"([^{separator}]+)")));
            return input.Select(line => parseRegex.Match(line).Groups)
                        .Select(group => (parser1.Invoke(group[1].Value), parser2.Invoke(group[2].Value)));
        }

        public static IEnumerable<(T1, T2, T3)> ParseCsv<T1, T2, T3>(
            this IEnumerable<string> input,
            Func<string, T1> parser1,
            Func<string, T2> parser2,
            Func<string, T3> parser3,
            char separator = ' ',
            bool multiple = true)
        {
            var parseRegex = new Regex(String.Join(separator + (multiple ? "+" : ""), Helpers.Times(3, $@"([^{separator}]+)")));
            return input.Select(line => parseRegex.Match(line).Groups)
                        .Select(group => (parser1.Invoke(group[1].Value), parser2.Invoke(group[2].Value), parser3.Invoke(group[3].Value)));
        }

        public static IEnumerable<(T1, T2, T3, T4)> ParseCsv<T1, T2, T3, T4>(
            this IEnumerable<string> input,
            Func<string, T1> parser1,
            Func<string, T2> parser2,
            Func<string, T3> parser3,
            Func<string, T4> parser4,
            char separator = ' ',
            bool multiple = true)
        {
            var parseRegex = new Regex(String.Join(separator + (multiple ? "+" : ""), Helpers.Times(4, $@"([^{separator}]+)")));
            return input.Select(line => parseRegex.Match(line).Groups)
                        .Select(group => (parser1.Invoke(group[1].Value), parser2.Invoke(group[2].Value), parser3.Invoke(group[3].Value), parser4.Invoke(group[4].Value)));
        }

        public static IEnumerable<IEnumerable<T>> ParseCsvLists<T>(
            this IEnumerable<string> Input,
            Func<string, T> parser,
            char separator = ' ') => Input.Select(line => line.Split(new string[] { separator.ToString() }, StringSplitOptions.RemoveEmptyEntries).Select(parser.Invoke));
    }
}