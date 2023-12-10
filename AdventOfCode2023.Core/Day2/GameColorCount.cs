namespace AdventOfCode2023.Core
{
    public record GameColorCount(
        int Id,
        TurnColorCount MinimalBag,
        IEnumerable<TurnColorCount> Turns
    );
}
