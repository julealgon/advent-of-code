namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public partial class Outcome
{
    public sealed class Win : IOutcomeValue<Win>, ISingleton<Win>
    {
        public static int Score { get; } = 6;
    }
}
