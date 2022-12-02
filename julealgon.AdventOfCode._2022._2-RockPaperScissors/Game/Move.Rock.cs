namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public partial class Move
{
    public sealed class Rock : IMoveValue<Rock>, ISingleton<Rock>
    {
        public static int Score { get; } = 1;
    }
}
