namespace Dec02;

public class SolutionPart2(string inputFile)
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
        
        Console.WriteLine($"Solution Part2: {result}");
    }
    
    // Todo: If a check fails test the arrays without ith i + 1 th element
    private static bool IsArraySave(int[] array)
    {
        var increasing = IsArrayIncreasing(array);

        for (var i = 0; i < array.Length - 1; i++)
        {
            if (increasing)
            {
                if (array[i] >= array[i + 1])
                    return IsArrayReallySave(RemoveElement(array, i)) 
                    || IsArrayReallySave(RemoveElement(array, i + 1)) 
                    || IsArrayReallySave(RemoveElement(array, 0));
            }
            else
            {
                if (array[i] <= array[i + 1])
                    return IsArrayReallySave(RemoveElement(array, i)) 
                    || IsArrayReallySave(RemoveElement(array, i + 1)) 
                    || IsArrayReallySave(RemoveElement(array, 0));
            }
            if (Math.Abs(array[i] - array[i + 1]) > 3)
                return IsArrayReallySave(RemoveElement(array, i)) 
                || IsArrayReallySave(RemoveElement(array, i + 1));
        }
        return true;
    }

    private static bool IsArrayIncreasing(int[] array)
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
            return increasing;
        }

        return increasing;
    }

    private static bool IsArrayReallySave(int[] array)
    {
        var increasing = IsArrayIncreasing(array);
        
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

    private static T[] RemoveElement<T>(T[] array, int index)
    {
        var result = new T[array.Length - 1];
        Array.Copy(array, 0, result, 0, index);
        Array.Copy(array, index + 1, result, index, array.Length - index - 1);
        return result;
    }
}