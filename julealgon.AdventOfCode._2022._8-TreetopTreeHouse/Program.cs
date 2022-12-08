// See https://aka.ms/new-console-template for more information
using julealgon.AdventOfCode.Extensions;
using MoreLinq;

var treeMap = Console.In
    .IterateLines()
    .Select(line => line.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray())
    .ToArray();

var score = GetScenicScore(2, 1);
var score2 = GetScenicScore(2, 3);

Part1();
//Part2();

void Part1()
{
    var x = IsVisible(1, 1);

    int visibleCount = 0;
    for (int i = 0; i < treeMap[0].Length; i++)
    {
        for (int j = 0; j < treeMap.Length; j++)
        {
            if (IsVisible(i, j))
            {
                visibleCount++;
            }
        }
    }

    _ = visibleCount;
}

void Part2()
{
    var x = GetScenicScores().Max();

    IEnumerable<int> GetScenicScores()
    {
        for (int i = 0; i < treeMap[0].Length; i++)
        {
            for (int j = 0; j < treeMap.Length; j++)
            {
                yield return GetScenicScore(i, j);
            }
        }
    }
}

int GetScenicScore(int x, int y)
{
    return TreesToTheLeft(x, y).TakeUntil(t => t >= treeMap[y][x]).Count() *
        TreesToTheRight(x, y).TakeUntil(t => t >= treeMap[y][x]).Count() *
        TreesToTheTop(x, y).TakeUntil(t => t >= treeMap[y][x]).Count() *
        TreesToTheBottom(x, y).TakeUntil(t => t >= treeMap[y][x]).Count();
}

bool IsVisible(int x, int y)
{
    // Left/Right border
    if (x is 0 || x == treeMap[0].Length - 1)
    {
        return true;
    }

    // Top/Bottom border
    if (y is 0 || y == treeMap.Length - 1)
    {
        return true;
    }

    return TreesToTheLeft(x, y).All(t => t < treeMap[y][x]) ||
        TreesToTheRight(x, y).All(t => t < treeMap[y][x]) ||
        TreesToTheTop(x, y).All(t => t < treeMap[y][x]) ||
        TreesToTheBottom(x, y).All(t => t < treeMap[y][x]);
}

IEnumerable<int> TreesToTheLeft(int x, int y)
{
    for (int i = x - 1; i >= 0; i--)
    {
        yield return treeMap[y][i];
    }
}

IEnumerable<int> TreesToTheRight(int x, int y)
{
    for (int i = x + 1; i < treeMap[0].Length; i++)
    {
        yield return treeMap[y][i];
    }
}

IEnumerable<int> TreesToTheTop(int x, int y)
{
    for (int i = y - 1; i >= 0; i--)
    {
        yield return treeMap[i][x];
    }
}

IEnumerable<int> TreesToTheBottom(int x, int y)
{
    for (int i = y + 1; i < treeMap.Length; i++)
    {
        yield return treeMap[i][x];
    }
}