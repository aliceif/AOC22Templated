using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace AdventOfCode2022.Running;


[MemoryDiagnoser(false)]
[Orderer(SummaryOrderPolicy.Method, MethodOrderPolicy.Alphabetical)]
public class Bench
{
    public Type Challenge => Program.DayInput;

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
}