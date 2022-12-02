using OneOf;

namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

using static Outcome;

[GenerateOneOf]
public sealed partial class Outcome : OneOfBase<Loss, Draw, Win>
{
    public int Score => this.Match(
        IOutcomeValue<Loss>.GetScore,
        IOutcomeValue<Draw>.GetScore,
        IOutcomeValue<Win>.GetScore);
}
