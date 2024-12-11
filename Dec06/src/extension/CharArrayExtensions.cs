namespace Dec06.dataTypes;

internal static class CharArrayExtensions
{
    internal static void PrintToConsole(this char[][] array)
    {
        foreach (var line in array)
        {
            Console.WriteLine(line.Aggregate("", (acc, curr) => acc + curr));
        }
    }
    
    internal static char[][] CopyArray(this char[][] array)
    {
        return array.Select(row => row.ToArray()).ToArray();
    }
}