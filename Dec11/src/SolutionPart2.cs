namespace Dec11;

internal class SolutionPart2(string inputFile)
{
    private Dictionary<(int, ulong), ulong> _resultCache = new Dictionary<(int, ulong), ulong>();
    internal void CalculateSolution()
    {
        var input = File.ReadAllText(inputFile)
            .Split(" ", StringSplitOptions.TrimEntries)
            .Select(ulong.Parse)
            .ToList();

        ulong result = 0L;
        
        foreach (var number in input)
        {
            result += ProcessNumber(75, number);
        }
        
        
        Console.WriteLine($"Solution Part 2: {result}");
    }
    
    private ulong ProcessNumber(int numberOfSteps, ulong stoneNumber)
    {
        if (_resultCache.ContainsKey((numberOfSteps, stoneNumber)))
        {
            return _resultCache[(numberOfSteps, stoneNumber)];
        }
        
        if (numberOfSteps ==0)
        {
            return 1;
        }
        
        if (stoneNumber == 0)
        {
            return ProcessNumber(numberOfSteps - 1, 1);
        }
        
        if (IsNumberOfDigitsEven(stoneNumber))
        {
            var splitNumbers = SplitNumber(stoneNumber);
            var total = ProcessNumber(numberOfSteps - 1, splitNumbers.left) +
                        ProcessNumber(numberOfSteps - 1, splitNumbers.right);

            _resultCache[(numberOfSteps, stoneNumber)] = total;

            return total;
        }

        return ProcessNumber(numberOfSteps - 1, 2024 * stoneNumber);
    }
    
    private bool IsNumberOfDigitsEven(ulong number)
    {
        return CountDigits(number) % 2 == 0;
    }
    
    private ulong CountDigits(ulong number)
    {
        ulong digitCounter = 0;
        while (number != 0)
        {
            number /= 10;
            digitCounter++;
        }

        return digitCounter;
    }
    
    private (ulong left, ulong right) SplitNumber(ulong number)
    {
        var digitCount = CountDigits(number);
        var midIndex = digitCount / 2;

        var divisor = (ulong)Math.Pow(10, midIndex);

        var leftHalf = number / divisor;
        var rightHalf = number % divisor;

        return (leftHalf, rightHalf);
    }
}