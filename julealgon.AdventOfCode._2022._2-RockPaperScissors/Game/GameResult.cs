namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public sealed class GameResult
{
    public required Move Move { get; init; }

    public required Outcome Outcome { get; init; }

    public int TotalScore => Move.Score + Outcome.Score;
}
