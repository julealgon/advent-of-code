namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public partial class Move
{
    public sealed class Paper : IMoveValue<Paper>, ISingleton<Paper>
    {
        public static int Score { get; } = 2;
    }
}
