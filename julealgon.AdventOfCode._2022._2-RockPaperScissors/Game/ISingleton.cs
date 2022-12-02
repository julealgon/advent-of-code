namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public interface ISingleton<TSelf>
    where TSelf : ISingleton<TSelf>, new()
{
    private static readonly Lazy<TSelf> instance = new(() => new TSelf());

    public static TSelf Value => instance.Value;
}
