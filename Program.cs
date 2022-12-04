using RockPaperScissors;

Console.WriteLine("Calculating strategy...");


var matchList = File.ReadLines("match_list.txt").ToList();

var matchesPlayed = matchList.Select(m =>
{
    var handsPlayed = m.Split(" ");
    var opponentHand = Glossary.InputToAction[handsPlayed[0]];
    var matchResult = Glossary.InputToMatchResult[handsPlayed[1]];
    
    var playerHand = Match.GetHandForMatchResult(opponentHand, matchResult);

    var match = new Match(playerHand, opponentHand);
    match.ComputeResults();
    
    return match;
}).ToList();

var totalPlayerWins = matchesPlayed.Count(m => m.PlayerMatchResult == MatchResult.Win);
var totalPlayerScore = matchesPlayed.Sum(m => m.PlayerScore);

Console.WriteLine($"Played {matchesPlayed.Count} matches, Won {totalPlayerWins} matches, Score {totalPlayerScore}");
Console.WriteLine("Done calculating strategy results");