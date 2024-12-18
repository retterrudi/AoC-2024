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
        }

        var memoryWithIds = memory.Select((number, index) => (number, index));
        
        
    }
}