namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public partial class Move
{
    public interface IMoveValue<TSelf>
        where TSelf : IMoveValue<TSelf>
    {
        public static abstract int Score { get; }

        public static int GetScore(TSelf _) => TSelf.Score;
    }
}
