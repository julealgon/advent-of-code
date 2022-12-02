namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public partial class Move
{
    public sealed class Scissors : IMoveValue<Scissors>, ISingleton<Scissors>
    {
        public static int Score { get; } = 3;
    }
}
