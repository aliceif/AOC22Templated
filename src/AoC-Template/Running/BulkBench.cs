using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Reflection;

namespace AdventOfCode2022.Running;

[MemoryDiagnoser(false)]
[Orderer(SummaryOrderPolicy.Method, MethodOrderPolicy.Alphabetical)]
public class BulkBench
{
    [ParamsSource(nameof(Challenges))]
    public Type Challenge { get; set; }

    private BaseChallenge _challenge;

    [GlobalSetup]
    public void Setup()
    {
        _challenge = (BaseChallenge)Activator.CreateInstance(Challenge)!;
    }

    [Benchmark(Description = "Part 1")]
    public string PartOne()
    {
        return _challenge.SolvePartOne();
    }

    [Benchmark(Description = "Part 2")]
    public string PartTwo()
    {
        return _challenge.SolvePartTwo();
    }

    public IEnumerable<Type> Challenges() => Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(BaseChallenge)));
}