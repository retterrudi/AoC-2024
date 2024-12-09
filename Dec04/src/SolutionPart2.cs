namespace Dec04;

public class SolutionPart2(string inputFile)
{
    public void CalculateSolution()
    {
        var lines = File.ReadAllLines(inputFile);
        var array = lines.Select(line => line.ToCharArray()).ToArray();


        var matchCounter = FindWords(array);
        Console.WriteLine($"Solution Part 1: {matchCounter}");
    }

    private static int FindWords(char[][] array)
    {
        var matchCounter = 0;
        for (var y = 1; y < array.Length - 1; y++)
        {
            for (var x = 1; x < array[0].Length - 1; x++)
            {
                if (array[y][x] == 'A' && IsMatch(x, y, array))
                {
                    matchCounter++;
                }
            }
        }

        return matchCounter;
    }

    private static bool IsMatch(int x, int y, char[][] array)
    {
        bool upperLeftLowerRight = (array[y - 1][x - 1] == 'M' && array[y + 1][x + 1] == 'S') 
                                   || (array[y - 1][x - 1] == 'S' && array[y + 1][x + 1] == 'M');

        bool upperRightLowerLeft = (array[y - 1][x + 1] == 'M' && array[y + 1][x - 1] == 'S') 
                                   || (array[y - 1][x + 1] == 'S' && array[y + 1][x - 1] == 'M');
            
        return upperRightLowerLeft && upperLeftLowerRight;
    }
}