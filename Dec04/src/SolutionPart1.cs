namespace Dec04;

internal class SolutionPart1(string inputFile)
{
    private const string TargetWord = "XMAS";
    
    public void CalculateSolution()
    {
        var lines = File.ReadAllLines(inputFile);
        var array = lines.Select(line => line.ToCharArray()).ToArray();


        var matchCounter = FindWords(array);
        Console.WriteLine($"Solution Part 1: {matchCounter}");
        // return matchCounter;
    }
    
    internal int FindWords(char[][] array)
    {
        var matchCounter = 0;
        for (var y = 0; y < array.Length; y++)
        {
            for (var x = 0; x < array[0].Length; x++)
            {
                if (array[y][x] == 'X')
                {
                    matchCounter += FindMatches(x, y, array);
                }
            }
        }

        return matchCounter;
    }

    private static int FindMatches(int x, int y, char[][] array)
    {
        var matchCounter = 0;
        // Right
        // 5 - 3 > 4
        if (array[y].Length - x >= TargetWord.Length)
        {
            if (array[y][x] == 'X' 
                && array[y][x + 1] == 'M' 
                && array[y][x + 2] == 'A' 
                && array[y][x + 3] == 'S')
            {
                matchCounter++;
            }
        }
        // Down Right
        // x = 1
        // y = 1
        // 5 - x > 4
        if (array[y].Length - x >= TargetWord.Length 
            && array.Length - y >= TargetWord.Length)
        {
            if (array[y][x] == 'X' 
                && array[y + 1][x + 1] == 'M' 
                && array[y + 2][x + 2] == 'A' 
                && array[y + 3][x + 3] == 'S')
            {
                matchCounter++;
            }
        }
        // Down
        if (array.Length - y >= TargetWord.Length)
        {
            if (array[y][x] == 'X' 
                && array[y + 1][x] == 'M' 
                && array[y + 2][x] == 'A' 
                && array[y + 3][x] == 'S')
            {
                matchCounter++;
            }
        }
        // Down Left
        if (x >= TargetWord.Length - 1
            && array.Length - y >= TargetWord.Length)
        {
            if (array[y][x] == 'X' 
                && array[y + 1][x - 1] == 'M' 
                && array[y + 2][x - 2] == 'A' 
                && array[y + 3][x - 3] == 'S')
            {
                matchCounter++;
            }
        }
        // Left
        if (x >= TargetWord.Length - 1)
        {
            if (array[y][x] == 'X' 
                && array[y][x - 1] == 'M' 
                && array[y][x - 2] == 'A' 
                && array[y][x - 3] == 'S')
            {
                matchCounter++;
            }
        }
        // Up Left
        if (x >= TargetWord.Length - 1
            && y >= TargetWord.Length - 1)
        {
            if (array[y][x] == 'X' 
                && array[y - 1][x - 1] == 'M' 
                && array[y - 2][x - 2] == 'A' 
                && array[y - 3][x - 3] == 'S')
            {
                matchCounter++;
            }
        }
        // Up
        if (y >= TargetWord.Length - 1)
        {
            if (array[y][x] == 'X' 
                && array[y - 1][x] == 'M' 
                && array[y - 2][x] == 'A' 
                && array[y - 3][x] == 'S')
            {
                matchCounter++;
            }
        }
        // Up Right
        if (array[y].Length - x >= TargetWord.Length
            && y >= TargetWord.Length - 1)
        {
            if (array[y][x] == 'X' 
                && array[y - 1][x + 1] == 'M' 
                && array[y - 2][x + 2] == 'A' 
                && array[y - 3][x + 3] == 'S')
            {
                matchCounter++;
            }
        }

        return matchCounter;
    }
}