namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public partial class Outcome
{
    public sealed class Loss : IOutcomeValue<Loss>, ISingleton<Loss>
    {
        public static int Score { get; } = 0;
    }
}
