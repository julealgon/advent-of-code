using System.Data;
using System.Reactive.Linq;
using julealgon.AdventOfCode.Extensions;
using MoreLinq;
using static System.Numerics.Vector2;

namespace julealgon.AdventOfCode._2022._9_RopeBridge;

internal class Rope
{
    public Rope(int numberOfKnots)
    {
        Knots.Add(new("H"));
        foreach (var i in 2..numberOfKnots)
        {
            Knots.Add(new((i-1).ToString()));
        }

        foreach (var (lead, follower) in Knots.Pairwise((lead, follower) => (lead, follower)))
        {
            lead.Position
                .WithLatestFrom(follower.Position, (leadPosition, followerPosition) => (lead: leadPosition, follower:followerPosition))
                .Where(pair => Distance(pair.lead, pair.follower) > 1.5)
                .Subscribe(pair => follower.MoveTowards(pair.lead));
        }
    }

    public RopeKnot Head => Knots[0];

    public RopeKnot Tail => Knots[^1];

    public IList<RopeKnot> Knots { get; } = new List<RopeKnot>();

    public void DragByHead(Direction direction, int increments)
    {
        foreach (var _ in 1..increments)
        {
            Head.MoveTowards(direction);
        }
    }
}
