﻿namespace julealgon.AdventOfCode.Extensions;

public static class CollectionExtensions
{
    public static void Add<T>(this ICollection<T> collection, IEnumerable<T> elementsToAdd)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(elementsToAdd);

        foreach (var element in elementsToAdd)
        {
            collection.Add(element);
        }
    }
}
