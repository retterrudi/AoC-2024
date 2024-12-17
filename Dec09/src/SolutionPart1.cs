namespace Dec09;

internal class SolutionPart1(string inputFile)
{
    internal void CalculateSolution()
    {
        var input = File.ReadAllText(inputFile)
            .Select(character => int.Parse(character.ToString()))
            .ToList();

        var memory = CreateMemory(input);

        var left = 0;
        var right = memory.Length - 1;
        while (left <= right) 
        {
            while (memory[left] != -1 && left <= right)
            {
                left++;
            }

            if (left > right) break;
            memory[left] = memory[right];
            memory[right] = -1;
            
            while (memory[right] == -1)
            {
                right--;
            }

        }

        var result = CalculateChecksum(memory);

        Console.WriteLine($"Solution Part 1: {result}");
    }

    private static int[] CreateMemory(List<int> input)
    {
        var lengthArray = input.Sum();

        var memory = new int[lengthArray];
        var id = 0;
        var file = true;
        var i = 0;
        foreach (var number in input)
        {
            if (file)
            {
                for (var j = 0; j < number; j++)
                {
                    memory[i] = id;
                    i++;
                }

                id++;
                file = false;
            }
            else
            {
                for (var j = 0; j < number; j++)
                {
                    memory[i] = -1;
                    i++;
                }

                file = true;
            }
        }

        return memory;
    }

    internal long CalculateChecksum(int[] memory)
    {
        var result = 0L;
        var i = 0;
        while(memory[i] != -1)
        {
            result += i * memory[i];
            i++;
        }

        return result;
    }
}