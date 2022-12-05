using julealgon.AdventOfCode.Extensions;

namespace julealgon.AdventOfCode._2022._5_SupplyStacks;

internal sealed class CargoShip 
{
    public CargoShip(IEnumerable<CargoStackConfiguration> cargoStackConfigurations)
    {
        foreach (var config in cargoStackConfigurations.OrderBy(c => c.StackNumber))
        {
            this.CrateStacks.Add(config.Crates);
        }
    }

    public IList<Stack<Crate>> CrateStacks { get; } = new List<Stack<Crate>>();

    public void OperateCrane(int numberOfCrates, int sourceStack, int targetStack)
    {
        foreach (var _ in 1..numberOfCrates)
        {
            var crate = CrateStacks[sourceStack].Pop();
            CrateStacks[targetStack].Push(crate);
        }
    }

    public void OperateCrane9001(int numberOfCrates, int sourceStack, int targetStack)
    {
        var crates = CrateStacks[sourceStack].PopMany(numberOfCrates);
        CrateStacks[targetStack].PushAsOne(crates);
    }
}
