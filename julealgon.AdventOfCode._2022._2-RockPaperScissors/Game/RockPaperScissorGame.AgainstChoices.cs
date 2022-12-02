namespace julealgon.AdventOfCode._2022._2_RockPaperScissors.Game;

public sealed partial class RockPaperScissorGame
{
    public sealed class AgainstChoices
    {
        private readonly IMoveComparer comparer = new MoveComparer();
        private readonly Move opposingMove;

        public AgainstChoices(Move opposingMove)
        {
            this.opposingMove = opposingMove;
        }

        public GameResult Play(Move move) => new()
        {
            Move = move,
            Outcome = comparer.Compare(move, opposingMove),
        };
    }
}
