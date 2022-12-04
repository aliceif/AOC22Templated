using AdventOfCode2022.Running;
namespace AdventOfCode2022;

public class Day4 : BaseChallenge
{
    private readonly string Input;

    public Day4()
    {
        Input = LoadInput(File.ReadAllText, nameof(Day4));
    }

    public override string SolvePartOne()
    {
        return Input.Lines().ParseCsv(x => x, x => x, ',')
            .Select(p => (p.Item1.Split('-').Select(int.Parse).ToList(), p.Item2.Split('-').Select(int.Parse).ToList()))
            .Select(pp => (pp.Item1[0].EnumerateTo(pp.Item1[1]), pp.Item2[0].EnumerateTo(pp.Item2[1])))
            .Count(px => px.Item1.Intersect(px.Item2).Count() == px.Item1.Count() || px.Item2.Intersect(px.Item1).Count() == px.Item2.Count())
            .ToString();
    }

    public override string SolvePartTwo()
    {
        return Input.Lines().ParseCsv(x => x, x => x, ',')
            .Select(p => (p.Item1.Split('-').Select(int.Parse).ToList(), p.Item2.Split('-').Select(int.Parse).ToList()))
            .Select(pp => (pp.Item1[0].EnumerateTo(pp.Item1[1]), pp.Item2[0].EnumerateTo(pp.Item2[1])))
            .Count(px => px.Item1.Intersect(px.Item2).Count() != 0 || px.Item2.Intersect(px.Item1).Count() != 0)
            .ToString();
    }
}