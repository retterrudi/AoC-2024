namespace Dec1.SolutionPart1;

public class SolutionPart1(string input)
{
    public void CalculateSolution()
    {
        var lines = File.ReadLines(input);

        List<int> left = new List<int>();
        List<int> right = new List<int>();

        foreach (var line in lines)
        {
            var splitLine = line.Split("   ").Select(it => int.Parse(it)).ToList();
            left.Add(splitLine[0]);
            right.Add(splitLine[1]);
        }
        
        left.Sort();
        right.Sort();

        var sum = 0;
        for (int i = 0; i < left.Count; i++)
        {
            sum += Math.Abs(left[i] - right[i]);
        }
        
        Console.WriteLine($"Solution Part1: {sum}");
    }
}