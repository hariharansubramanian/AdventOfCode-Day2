using RockPaperScissors;

Console.WriteLine("Calculating strategy...");

var inputToActionDict = new Dictionary<string, ActionType>
{
    { "A", ActionType.Rock },
    { "B", ActionType.Paper },
    { "C", ActionType.Scissors }
};

var inputToMatchResultDict = new Dictionary<string, MatchResult>
{
    { "X", MatchResult.Lose },
    { "Y", MatchResult.Draw },
    { "Z", MatchResult.Win }
};


var matchList = File.ReadLines("match_list.txt").ToList();

var matchesPlayed = matchList.Select(m =>
{
    var handsPlayed = m.Split(" ");
    var opponentHand = inputToActionDict[handsPlayed[0]];
    var matchResult = inputToMatchResultDict[handsPlayed[1]];

    var playerHand = Match.GetPlayerHandForResult(opponentHand, matchResult);

    var match = new Match(playerHand, opponentHand);
    match.ComputeResults();
    return match;
}).ToList();

var totalPlayerWins = matchesPlayed.Count(m => m.PlayerMatchResult == MatchResult.Win);
var totalPlayerScore = matchesPlayed.Sum(m => m.PlayerScore);

Console.WriteLine($"Played {matchesPlayed.Count} matches, Won {totalPlayerWins} matches, Score {totalPlayerScore}");
Console.WriteLine("Done calculating strategy results");