namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public partial class Outcome
{
    public interface IOutcomeValue<TSelf>
        where TSelf : IOutcomeValue<TSelf>
    {
        public static abstract int Score { get; }

        internal static int GetScore(TSelf _) => TSelf.Score;
    }
}
