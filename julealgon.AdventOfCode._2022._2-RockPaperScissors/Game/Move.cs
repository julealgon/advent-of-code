using OneOf;
using static julealgon.AdventOfCode._2022._2_RockPaperScissors.Game.Move;

namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

[GenerateOneOf]
public partial class Move : OneOfBase<Rock, Paper, Scissors>
{
    private static IEnumerable<Move> GetValues()
    {
        yield return ISingleton<Rock>.Value;
        yield return ISingleton<Paper>.Value;
        yield return ISingleton<Scissors>.Value;
    }

    public static IEnumerable<Move> Values => GetValues();

    public int Score => this.Match(
        IMoveValue<Rock>.GetScore,
        IMoveValue<Paper>.GetScore,
        IMoveValue<Scissors>.GetScore);
}
