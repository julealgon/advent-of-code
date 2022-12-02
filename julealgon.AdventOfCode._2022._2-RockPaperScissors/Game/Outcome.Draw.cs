namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public partial class Outcome
{
    public sealed class Draw : IOutcomeValue<Draw>, ISingleton<Draw>
    {
        public static int Score { get; } = 3;
    }
}
