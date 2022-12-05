namespace julealgon.AdventOfCode.Extensions;

public static class StackExtensions
{
    public static Stack<T> PopMany<T>(this Stack<T> stack, int numberOfElements)
    {
        ArgumentNullException.ThrowIfNull(stack);

        return new(stack.PopEnumerable(numberOfElements).Reverse());
    }

    public static void PushAsOne<T>(this Stack<T> stack, Stack<T> anotherStack)
    {
        ArgumentNullException.ThrowIfNull(stack);
        ArgumentNullException.ThrowIfNull(anotherStack);

        foreach (var element in anotherStack.PopEnumerable(anotherStack.Count).Reverse())
        {
            stack.Push(element);
        }
    }

    private static IEnumerable<T> PopEnumerable<T>(this Stack<T> stack, int numberOfElements)
    {
        foreach (var i in 1..numberOfElements)
        {
            yield return stack.Pop();
        }
    }
}
