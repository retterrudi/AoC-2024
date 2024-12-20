using System.Runtime.InteropServices.ComTypes;

namespace Dec09;

internal class SolutionPart2(string inputFile)
{
    internal void CalculateSolution()
    {
        var numbers = File.ReadAllText(inputFile)
            .Select(character => int.Parse(character.ToString()))
            .ToList();

        var memory = new List<int>();
        var spaces = new List<int>();

        var file = true;
        foreach (var number in numbers) 
        {
            if (file)
            {
                memory.Add(number);
            }
            else 
            {
                spaces.Add(number);
            }

            file = !file;
        }
        spaces.Add(0);

        var memoryWithIds = memory.Select((length, index) => (length, index)).ToList();
        var fileNumber = memoryWithIds.Count - 1;
        
        while(fileNumber > 0)
        {
            // Index is needed so blocks can only be moved to the left
            var index = memoryWithIds.FindIndex(numberIndexPair => numberIndexPair.index == fileNumber);
            var length = memoryWithIds[index].length;

            var spacesIndex = 0;
            while (spacesIndex < index)
            {
                if (spaces[spacesIndex] >= length) 
                {
                    // Found a place
                    memoryWithIds.Insert(spacesIndex + 1, memoryWithIds[index]);
                    memoryWithIds.RemoveAt(index + 1);
                    var oldSpace = spaces[spacesIndex];
                    spaces[spacesIndex] -= length;
                    spaces[index - 1] += length + spaces[index];
                    spaces.Insert(spacesIndex, 0);
                    spaces.RemoveAt(index + 1);
                    break;
                }

                spacesIndex++;
            }

            fileNumber--;
        }

        var runningIndex = 0;
        var result = 0L;
        for (var i = 0; i < memoryWithIds.Count; i++)
        {
            for (var j = 0; j < memoryWithIds[i].length; j++)
            {
                result += runningIndex * memoryWithIds[i].index;
                runningIndex++;
            }

            runningIndex += spaces[i];
        }
        
        Console.WriteLine($"Solution Part2: {result}");
    }
}