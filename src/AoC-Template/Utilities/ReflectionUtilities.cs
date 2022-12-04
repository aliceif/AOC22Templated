using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace AdventOfCode2022.Utilities;

public static class ReflectionUtilities
{
    public static bool TryGetChallengeType(string challengeType, [NotNullWhen(true)] out Type? challenge)
    {
        challenge = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == challengeType);

        return challenge is not null;
    }
}