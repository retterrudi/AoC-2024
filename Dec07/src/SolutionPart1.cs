namespace Dec07;

internal class SolutionPart1(string inputFile)
{
    internal void CalculateSolution()
    {
        var lines = File.ReadAllLines(inputFile);
        var result = lines
            .Where(EvaluateLine)
            .Select(line => long.Parse(line.Split(":", StringSplitOptions.TrimEntries)[0]))
            .Aggregate(0L, (acc, curr) => acc + curr);

        Console.WriteLine($"Solution Part1: {result}");
    }
    
    
    internal bool EvaluateLine(string line)
    {
        var splitLine = line.Split(":", StringSplitOptions.TrimEntries);
        var target = long.Parse(splitLine[0]);
        var numbers = splitLine[1]
            .Split(" ")
            .Select(long.Parse)
            .ToArray();

        return CheckPermutations(target, numbers, 1, numbers[0], Operation.Multiply)
               || CheckPermutations(target, numbers, 1, numbers[0], Operation.Add);
    }
    
    internal bool CheckPermutations(
        long target, 
        long[] numbers, 
        int index, 
        long current, 
        Operation operation)
    {
        if (index > numbers.Length - 1)
        {
            return current == target;
        }
        
        if (current > target)
        {
            return false;
        }

        return operation switch
        {
            Operation.Multiply =>
                CheckPermutations(target, numbers, index + 1, current * numbers[index], Operation.Multiply)
                || CheckPermutations(target, numbers, index + 1, current * numbers[index], Operation.Add),
            Operation.Add =>
                CheckPermutations(target, numbers, index + 1, current + numbers[index], Operation.Multiply)
                || CheckPermutations(target, numbers, index + 1, current + numbers[index], Operation.Add),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
}
internal enum Operation
{
    Multiply,
    Add,
}