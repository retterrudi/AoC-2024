namespace Dec1.SolutionPart2;

public class SolutionPart2(string inputFile)
{
    public void CalculateSolution()
    {
        var lines = File.ReadAllLines(inputFile);

        var left = new Dictionary<int, int>();
        var right = new Dictionary<int, int>();

        foreach (var line in lines)
        {
            var splitLine = line.Split("   ").Select(it => int.Parse(it)).ToList();
            
            if (left.ContainsKey(splitLine[0]))
            {
                left[splitLine[0]] += 1;
            } 
            else
            {
                left[splitLine[0]] = 1;
            }

            if (right.ContainsKey(splitLine[1]))
            {
                right[splitLine[1]] += 1;
            } 
            else
            {
                right[splitLine[1]] = 1;
            }
        }

        var similarityScore = 0;
        foreach (var (number, value) in left)
        {
            if (right.ContainsKey(number))
            {
                similarityScore += (right[number] * number) * value;
            }
        }
        
        Console.WriteLine($"Solution Part2: {similarityScore}");
    }
}