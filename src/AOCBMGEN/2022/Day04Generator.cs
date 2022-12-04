using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace AOCBM._2022
{
    [Generator]
    public class Day04Generator : ISourceGenerator
    {   
        public void Execute(GeneratorExecutionContext context)
        {
            var inFile = context.AdditionalFiles.Single(f => System.IO.Path.GetFileName(f.Path) == "Day4CG.txt");
            var lines = inFile.GetText().ToString().Lines().Select(l => l.ToString());

            var resultPart1 = lines.ParseCsv(x => x, x => x, ',')
                .Select(p => (p.Item1.Split('-').Select(int.Parse).ToList(), p.Item2.Split('-').Select(int.Parse).ToList()))
                .Select(pp => (pp.Item1[0].EnumerateTo(pp.Item1[1]), pp.Item2[0].EnumerateTo(pp.Item2[1])))
                .Count(px => px.Item1.Intersect(px.Item2).Count() == px.Item1.Count() || px.Item2.Intersect(px.Item1).Count() == px.Item2.Count());

            int Part2(IEnumerable<object> input)
            {
                return 0;
            }

            var resultPart2 = lines.ParseCsv(x => x, x => x, ',')
                .Select(p => (p.Item1.Split('-').Select(int.Parse).ToList(), p.Item2.Split('-').Select(int.Parse).ToList()))
                .Select(pp => (pp.Item1[0].EnumerateTo(pp.Item1[1]), pp.Item2[0].EnumerateTo(pp.Item2[1])))
                .Count(px => px.Item1.Intersect(px.Item2).Count() != 0 || px.Item2.Intersect(px.Item1).Count() != 0);


            var source = $@"
namespace AdventOfCode2022;

public static class Day04Runner
{{
    public static int Part1()
    {{
        return {resultPart1};
    }}

    public static int Part2()
    {{

        return {resultPart2};
    }}
}}
";

            // inject the created source into the users compilation
            context.AddSource("Day04", SourceText.From(source, Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // No initialization required for this one
        }
    }
}