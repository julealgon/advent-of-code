using OneOf;
using static julealgon.AdventOfCode._2022._7_NoSpaceLeftOnDevice.ElfConsoleCommand;

namespace julealgon.AdventOfCode._2022._7_NoSpaceLeftOnDevice;

internal readonly record struct ElfFileSystem
{
    public ElfFileSystem()
    {
        RootDirectory = new();
    }

    public ElfDirectory RootDirectory { get; }
}

internal readonly record struct ElfFile
{
    public required string Name { get; init; }

    public required int Size { get; init; }
}

internal sealed record class ElfDirectory
{
    public ElfDirectory()
    {
        Files = new List<ElfFile>();
        Directories= new List<ElfDirectory>();
    }

    public ICollection<ElfFile> Files { get; }

    public ICollection<ElfDirectory> Directories { get; }

    public ElfDirectory? Parent { get; set; }

    public string? Name { get; set; }

    public int Size => Files.Sum(f => f.Size) + Directories.Sum(d => d.Size);
}

[GenerateOneOf]
public sealed partial class ElfConsoleCommand : OneOfBase<ListDirectoryContents, ChangeDirectory>
{
    public sealed class ListDirectoryContents
    {
    }

    public sealed class ChangeDirectory
    {
    }
}

