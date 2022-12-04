namespace AdventOfCode2022.Running;

public abstract class BaseChallenge
{
    private const string InputDir = "Inputs";
    private const string InputFileType = ".txt";

    public T LoadInput<T>(Func<string, T> dele, string challengeIdentifier)
    {
        return dele(Path.Combine(InputDir, challengeIdentifier + InputFileType));
    }

    public abstract string SolvePartOne();

    public abstract string SolvePartTwo();
}