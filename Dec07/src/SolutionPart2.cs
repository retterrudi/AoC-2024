namespace Dec07;

internal class SolutionPart2(string inputFile)
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

        return CheckPermutations(target, numbers, 1, numbers[0], OperationPart2.Multiply)
               || CheckPermutations(target, numbers, 1, numbers[0], OperationPart2.Add)
               || CheckPermutations(target, numbers, 1, numbers[0], OperationPart2.Concatenate);
    }
    
    internal bool CheckPermutations(
        long target, 
        long[] numbers, 
        int index, 
        long current, 
        OperationPart2 operation)
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
            OperationPart2.Multiply =>
                CheckPermutations(target, numbers, index + 1, current * numbers[index], OperationPart2.Multiply)
                || CheckPermutations(target, numbers, index + 1, current * numbers[index], OperationPart2.Add)
                || CheckPermutations(target, numbers, index + 1, current * numbers[index], OperationPart2.Concatenate),
            OperationPart2.Add =>
                CheckPermutations(target, numbers, index + 1, current + numbers[index], OperationPart2.Multiply)
                || CheckPermutations(target, numbers, index + 1, current + numbers[index], OperationPart2.Add)
                || CheckPermutations(target, numbers, index + 1, current + numbers[index], OperationPart2.Concatenate),
            OperationPart2.Concatenate =>
                CheckPermutations(target, numbers, index + 1, Concatenate(current, numbers[index]), OperationPart2.Multiply)
                || CheckPermutations(target, numbers, index + 1, Concatenate(current, numbers[index]), OperationPart2.Add)
                || CheckPermutations(target, numbers, index + 1, Concatenate(current, numbers[index]), OperationPart2.Concatenate),
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }
    
    private long Concatenate(long left, long right)
    {
        return long.Parse(left.ToString() + right.ToString());
    }
}

internal enum OperationPart2
{
    Multiply,
    Add,
    Concatenate
}