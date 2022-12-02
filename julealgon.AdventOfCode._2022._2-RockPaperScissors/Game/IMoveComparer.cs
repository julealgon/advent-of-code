namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public interface IMoveComparer
{
    Outcome Compare(Move? x, Move? y);
}
