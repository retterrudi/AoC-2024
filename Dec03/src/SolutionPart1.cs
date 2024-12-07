using System.Text.RegularExpressions;

namespace Dec03;

internal class SolutionPart1(string inputFile)
{
    public void CalculateSolution()
    {
        var input = File.ReadAllText(inputFile);
        var matches = Regex.Matches(input, @"mul\((\d{1,3}),(\d{1,3})\)");

        var result = matches.Select(match =>
            int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value)
        ).Aggregate(0, (acc, cur) => acc + cur);
        
        Console.WriteLine($"Solution Part 1: {result}");
    }
}