using static julealgon.AdventOfCode._2022._2_RockPaperScissors.Game.Move;
using static julealgon.AdventOfCode._2022._2_RockPaperScissors.Game.Outcome;

namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public sealed class MoveComparer : IComparer<Move>, IMoveComparer
{
    int IComparer<Move>.Compare(Move? x, Move? y)
        => (x.Value, y.Value) switch
        {
            (Paper, Rock) or (Scissors, Paper) or (Rock, Scissors) or (not null, null) => 1,
            (Rock, Paper) or (Paper, Scissors) or (Scissors, Rock) or (null, not null) => -1,
            _ => 0,
        };

    Outcome IMoveComparer.Compare(Move? x, Move? y)
    {
        IComparer<Move> @this = this;
        
        return @this.Compare(x, y) switch
        {
            < 0 => ISingleton<Loss>.Value,
            0 => ISingleton<Draw>.Value,
            > 0 => ISingleton<Win>.Value,
        };
    }
}
