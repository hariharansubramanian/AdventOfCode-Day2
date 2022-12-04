namespace RockPaperScissors;

public static class Glossary
{
    public static readonly Dictionary<ActionType, int> ActionToValue = new()
    {
        { ActionType.Rock, 1 },
        { ActionType.Paper, 2 },
        { ActionType.Scissors, 3 }
    };

    public static readonly Dictionary<MatchResult, int> MatchResultToValue = new()
    {
        { MatchResult.Win, 6 },
        { MatchResult.Draw, 3 },
        { MatchResult.Lose, 0 }
    };

    public static readonly Dictionary<string, ActionType> InputToAction = new()
    {
        { "A", ActionType.Rock },
        { "B", ActionType.Paper },
        { "C", ActionType.Scissors }
    };

    public static readonly Dictionary<string, MatchResult> InputToMatchResult = new()
    {
        { "X", MatchResult.Lose },
        { "Y", MatchResult.Draw },
        { "Z", MatchResult.Win }
    };
}