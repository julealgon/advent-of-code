using julealgon.AdventOfCode._2022._7_NoSpaceLeftOnDevice;
using julealgon.AdventOfCode.Extensions;
using MoreLinq;
using System.Text.RegularExpressions;

//Part1();
Part2();

void Part1()
{
    var fileSystem = new ElfFileSystem();
    var currentDirectory = fileSystem.RootDirectory;

    foreach (string line in Console.In.IterateLines())
    {
        if (line is "$ cd /")
        {
            currentDirectory = fileSystem.RootDirectory;
            continue;
        }

        if (line is "$ cd ..")
        {
            currentDirectory = currentDirectory!.Parent!;
            continue;
        }

        if (line.StartsWith("$ cd"))
        {
            var directoryName = line.Split(' ').Last();
            currentDirectory = currentDirectory!.Directories.Single(d => d.Name == directoryName);
            continue;
        }

        if (line is "$ ls")
        {
            continue;
        }

        if (line.StartsWith("dir "))
        {
            var directoryName = line.Split(' ').Last();
            currentDirectory.Directories.Add(new() { Name = directoryName, Parent = currentDirectory });
            continue;
        }

        var fileSize = line.Split(' ').First();
        var fileName = line.Split(' ').Last();
        currentDirectory.Files.Add(new() { Name = fileName, Size = int.Parse(fileSize) });
    }

    var sizeToDelete = MoreEnumerable
        .TraverseBreadthFirst(fileSystem.RootDirectory, d => d.Directories)
        .Where(d => d.Size <= 100_000)
        .Sum(d => d.Size);

    //var sizeToDelete = new Visitor().Visit(fileSystem.RootDirectory).Sum(d => d.Size);

}

void Part2()
{
    var fileSystem = new ElfFileSystem();
    var currentDirectory = fileSystem.RootDirectory;

    foreach (string line in Console.In.IterateLines())
    {
        if (line is "$ cd /")
        {
            currentDirectory = fileSystem.RootDirectory;
            continue;
        }

        if (line is "$ cd ..")
        {
            currentDirectory = currentDirectory!.Parent!;
            continue;
        }

        if (line.StartsWith("$ cd"))
        {
            var directoryName = line.Split(' ').Last();
            currentDirectory = currentDirectory!.Directories.Single(d => d.Name == directoryName);
            continue;
        }

        if (line is "$ ls")
        {
            continue;
        }

        if (line.StartsWith("dir "))
        {
            var directoryName = line.Split(' ').Last();
            currentDirectory.Directories.Add(new() { Name = directoryName, Parent = currentDirectory });
            continue;
        }

        var fileSize = line.Split(' ').First();
        var fileName = line.Split(' ').Last();
        currentDirectory.Files.Add(new() { Name = fileName, Size = int.Parse(fileSize) });
    }

    const int totalDiskCapacity = 70_000_000;
    const int updateDiskRequirement = 30_000_000;
    int currentDiskUsage = fileSystem.RootDirectory.Size;
    int freeDiskSpace = totalDiskCapacity - currentDiskUsage;
    int extraSpaceNeededForUpdate = updateDiskRequirement - freeDiskSpace;

    var sizeToDelete = MoreEnumerable
        .TraverseBreadthFirst(fileSystem.RootDirectory, d => d.Directories)
        .OrderBy(d => d.Size)
        .SkipWhile(d => d.Size < extraSpaceNeededForUpdate)
        .First().Size;
}

internal class Visitor
{
    public IEnumerable<ElfDirectory> Visit(ElfDirectory value)
    {
        if (value.Size <= 100_000)
        {
            yield return value;
        }
        else
        {
            foreach (var child in value.Directories)
            {
                foreach (var x in Visit(child))
                {
                    yield return x;
                }
            }
        }
    }
}