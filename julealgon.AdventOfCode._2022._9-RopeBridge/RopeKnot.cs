using System.Diagnostics;
using System.Numerics;
using System.Reactive.Subjects;
using static System.Numerics.Vector2;

namespace julealgon.AdventOfCode._2022._9_RopeBridge;

[DebuggerDisplay("Index: {Index} Position: {position.Value}")]
internal record RopeKnot
{
    private readonly BehaviorSubject<Vector2> position = new(Zero);

    public RopeKnot(string index)
    {
        Position = position;
        Index = index;
    }

    public IObservable<Vector2> Position { get; }

    public string Index { get; }

    public void MoveTowards(Direction direction)
    {
        position.OnNext(position.Value + direction.ToDelta());
    }

    public void MoveTowards(Vector2 targetPosition)
    {
        var delta = targetPosition - position.Value;
        MoveTowards(delta.ToDirection());
    }
}
