namespace RockPaperScissors;

public class Match
{
    public Match(ActionType playerHand, ActionType opponentsHand)
    {
        PlayerHand = playerHand;
        OpponentsHand = opponentsHand;
    }

    private ActionType OpponentsHand { get; }
    public ActionType PlayerHand { get; init; }
    public MatchResult PlayerMatchResult { get; private set; }
    public int PlayerScore { get; private set; }

    public void ComputeResults()
    {
        if (PlayerHand == OpponentsHand)
            PlayerMatchResult = MatchResult.Draw;
        else
            PlayerMatchResult = PlayerHand switch
            {
                ActionType.Rock => OpponentsHand == ActionType.Scissors ? MatchResult.Win : MatchResult.Lose,
                ActionType.Paper => OpponentsHand == ActionType.Rock ? MatchResult.Win : MatchResult.Lose,
                ActionType.Scissors => OpponentsHand == ActionType.Paper ? MatchResult.Win : MatchResult.Lose,
                _ => throw new ArgumentOutOfRangeException(nameof(PlayerHand), PlayerHand, null)
            };

        PlayerScore = Glossary.MatchResultToValue[PlayerMatchResult] + Glossary.ActionToValue[PlayerHand];
    }

    public static ActionType GetHandForMatchResult(ActionType opponentHand, MatchResult matchResult)
    {
        if (matchResult == MatchResult.Draw) return opponentHand;
        return opponentHand switch
        {
            ActionType.Rock => matchResult == MatchResult.Win ? ActionType.Paper : ActionType.Scissors,
            ActionType.Paper => matchResult == MatchResult.Win ? ActionType.Scissors : ActionType.Rock,
            ActionType.Scissors => matchResult == MatchResult.Win ? ActionType.Rock : ActionType.Paper,
            _ => throw new ArgumentOutOfRangeException(nameof(opponentHand), opponentHand, null)
        };
    }
}