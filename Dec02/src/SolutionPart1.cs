namespace Dec02;

public class SolutionPart1(string inputFile)
{
    public void CalculateSolution()
    {
        var lines = File.ReadAllLines(inputFile);
        var result = lines
            .Select(line =>
                line.Split(' ', StringSplitOptions.TrimEntries)
                    .Select(int.Parse)
                    .ToArray()
            ).Where(IsArraySave)
            .Count();
        
        Console.WriteLine($"Solution Part1: {result}");
    }
    
    private bool IsArraySave(int[] array)
    {
        var increasing = false;
        if (array.Length >= 2) 
        {
            if (array[0] < array[1])
            {
                increasing = true;
            }
        } 
        else 
        {
            // Array with only 1 element
            return true;
        }
        
        for (var i = 0; i < array.Length - 1; i++)
        {
            if (increasing)
            {
                if (array[i] >= array[i + 1])
                    return false;
            }
            else
            {
                if (array[i] <= array[i + 1])
                    return false;
                
            }
            if (Math.Abs(array[i] - array[i + 1]) > 3)
                return false;
        }
        return true;
    }
}