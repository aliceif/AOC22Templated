using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022
{
    public static class Helpers
    {
        /// <summary>
        /// Generates an <see cref="IEnumerable{T}"/> containing the given <paramref name="obj"/> <paramref name="times"/> times.
        /// Inspired by Integer#times from Ruby.
        /// </summary>
        public static IEnumerable<T> Times<T>(this int times, T obj)
        {
            for (var i = 0; i < times; i++)
            {
                yield return obj;
            }
        }

        /// <summary>
        /// Invokes the given <paramref name="action"/> <paramref name="times"/> times.
        /// Inspired by Integer#times from Ruby.
        /// </summary>
        public static void TimesDo(this int times, Action action)
        {
            for (var i = 0; i < times; i++)
            {
                action.Invoke();
            }
        }

        /// <summary>
        /// Invokes the given <paramref name="action"/> <paramref name="times"/> times, passing a counter 0..times-1 on each invocation.
        /// Inspired by Integer#times from Ruby.
        /// </summary>
        public static void TimesDo(this int times, Action<int> action)
        {
            for (var i = 0; i < times; i++)
            {
                action.Invoke(i);
            }
        }

        /// <summary>
        /// Invokes the given <paramref name="func"/> <paramref name="times"/> times and returns an <see cref="IEnumerable{T}"/> containing the results.
        /// Inspired by Integer#times from Ruby.
        /// </summary>
        public static IEnumerable<T> TimesDo<T>(this int times, Func<T> func)
        {
            for (var i = 0; i < times; i++)
            {
                yield return func.Invoke();
            }
        }

        /// <summary>
        /// Invokes the given <paramref name="func"/> <paramref name="times"/> times, passing a counter 0..times-1 on each invocation, and returns an <see cref="IEnumerable{T}"/> containing the results.
        /// Inspired by Integer#times from Ruby.
        /// </summary>
        public static IEnumerable<T> TimesDo<T>(this int times, Func<int, T> func)
        {
            for (var i = 0; i < times; i++)
            {
                yield return func.Invoke(i);
            }
        }

        /// <summary>
        /// Creates an enumerable containing the numbers from <paramref name="from"/> to <paramref name="to"/>.
        /// </summary>
        public static IEnumerable<int> EnumerateTo(this int from, int to)
        {
            if(from>to) throw new ArgumentException("from neesds to <= to.");
            for (var i = from; i <= to; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Smooshes the given strings together into a single string.
        /// </summary>
        public static string Smoosh(this IEnumerable<string> text) => string.Concat(text);

        /// <summary>
        /// Smooshes the given strings together into a multiline string.
        /// </summary>
        public static string SmooshLines(this IEnumerable<string> text) => string.Join(Environment.NewLine, text);

        /// <summary>
        /// Generates the Cartesian Product of the two given <see cref="IEnumerable{T}"/>s.
        /// </summary>
        public static IEnumerable<(T1, T2)> CartesianProduct<T1, T2>(this IEnumerable<T1> one, IEnumerable<T2> two) => one.SelectMany(i => two.Select(j => (i, j)));

        /// <summary>
        /// Equivalent to <see cref="Enumerable.Sum(IEnumerable{int})"/>
        /// </summary>
        public static int Product(this IEnumerable<int> source) => source.Aggregate(1, (value, accumulator) => accumulator * value);

        /// <summary>
        /// Equivalent to <see cref="Enumerable.Sum(IEnumerable{long})"/>
        /// </summary>
        public static long Product(this IEnumerable<long> source) => source.Aggregate(1L, (value, accumulator) => accumulator * value);

        /// <summary>
        /// Splits a text into lines.
        /// </summary>
        public static IEnumerable<string> Lines(this string text) => text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        /// <summary>
        /// Splits a text into blocks of lines. Split occurs on each empty line.
        /// </summary>
        public static IEnumerable<string> Blocks(this string text) => text.Trim().Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        /// <summary>
        /// Parses an <see cref="IEnumerable{string}"/> into an <see cref="IEnumerable{int}"/>.
        /// </summary>
        public static IEnumerable<int> Numbers(this IEnumerable<string> lines) => lines.Select(int.Parse);

        /// <summary>
        /// Parses an <see cref="IEnumerable{string}"/> into an <see cref="IEnumerable{IEnumerable{int}}"/>.
        /// </summary>
        public static IEnumerable<IEnumerable<int>> NumbersDigits(this IEnumerable<string> lines) => lines.Select(l => l.Select(c => c - '0'));

        /// <summary>
        /// Parses an <see cref="IEnumerable{string}"/> into an <see cref="IEnumerable{long}"/>.
        /// </summary>
        public static IEnumerable<long> LongNumbers(this IEnumerable<string> lines) => lines.Select(long.Parse);

        /// <summary>
        /// Provides an infinite enumerable of nothings to generate sequences
        /// </summary>
        public static IEnumerable<object> Infinite() { while (true) yield return default; }

        /// <summary>
        /// Provides an "infinite" number of <see cref="long"/>s, starting at 0
        /// </summary>
        public static IEnumerable<long> InfiniteLongs()
        {
            checked
            {
                for (long x = 0L; ; x++)
                    yield return x;
            }
        }

        /// <summary>
        /// Transposes a matrix.
        /// </summary>
        public static IEnumerable<IEnumerable<T>> Transpose<T>(this IEnumerable<IEnumerable<T>> matrix) =>
            matrix.Aggregate(
                seed: matrix.First().Count().Times(Enumerable.Empty<T>()),
                func: (acc, row) => acc.Zip(row, (col, n) => col.Append(n)));

        public static IEnumerable<int> ToDigits(this int number) =>
            InfiniteLongs()
                .Take((int)Math.Floor(Math.Log10(number)) + 1)
                .Select(x => (int)x)
                .Select(position => (number / (int)Math.Pow(10, position)) % 10)
                .Reverse();
    }
}
