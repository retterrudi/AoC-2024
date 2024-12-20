namespace Dec11;

internal class SolutionPart1(string inputFile)
{
    internal void CalculateSolution()
    {
        var input = File.ReadAllText(inputFile)
            .Split(" ", StringSplitOptions.TrimEntries)
            .Select(ulong.Parse)
            .ToList();

        var result = Enumerable.Range(0, 25).Aggregate(input, (acc, _) => PerformStep(acc)).Count;

        // var result = input.Select(number =>
        //     Enumerable.Range(0, 25).Aggregate(new List<ulong>() {number}, (acc, _) => PerformStep(acc)).Count).Sum();
        
        Console.WriteLine($"Solution Part 1: {result}");
    }
    
    private List<ulong> PerformStep(List<ulong> input)
    {
        return input.SelectMany(ProcessNumber).ToList();
    }
    
    private List<ulong> ProcessNumber(ulong stoneNumber)
    {
        return stoneNumber switch
        {
            0 => [1],
            var x when x.ToString().Length % 2 == 0 => SplitStone(x),
            _ => [stoneNumber * 2024L]
        };
    }
    
    private List<ulong> SplitStone(ulong stoneNumber)
    {
        var length = stoneNumber.ToString().Length;

        var first = ulong.Parse(stoneNumber.ToString()[..(length / 2)]);
        var second = ulong.Parse(stoneNumber.ToString()[(length /2)..]);

        return [first, second];
    }
}