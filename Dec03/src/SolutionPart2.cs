using System.Text.RegularExpressions;

namespace Dec03;

public class SolutionPart2(string inputFile)
{
    public void CalculateSolution()
    {
        var input = File.ReadAllText(inputFile);
        var inputSplitDont = input.Split("don't()");
        var inputSplitDo = inputSplitDont
            .Skip(1)
            .Select(it =>
            {
                var split = it.Split("do()", 2);
                return split switch
                {
                    [_, var afterDo, ..] => afterDo,
                    _ => ""
                };
            })
            .Aggregate(inputSplitDont[0], (acc, curr) => acc + curr);
            
        
        var matches = Regex.Matches(inputSplitDo, @"mul\((\d{1,3}),(\d{1,3})\)");

        var result = matches.Select(match =>
            int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value)
        ).Aggregate(0, (acc, cur) => acc + cur);
        
        Console.WriteLine($"Solution Part 2: {result}");
    }
}