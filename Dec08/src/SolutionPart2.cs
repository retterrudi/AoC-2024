namespace Dec08;

internal class SolutionPart2(string inputFile)
{
    internal void CalculateSolution()
    {
        var lines = File.ReadAllLines(inputFile);

        var antennas = new Dictionary<char, List<(int x, int y)>>();
        
        for (var y = 0; y < lines.Length; y++) 
        {
            for (var x = 0; x < lines[y].Length; x++)
            {
                if (lines[y][x] == '.') 
                    continue;
                if (antennas.ContainsKey(lines[y][x]))
                {
                    antennas[lines[y][x]].Add((x, y));
                }
                else
                {
                    antennas[lines[y][x]] = [(x, y)];
                }
            }
        }

        var map = new bool[lines.Length, lines[0].Length];
        map = antennas.Aggregate(map, (current, kvp) => AddAntiNodes(current, kvp.Value));

        var result = 0;
        
        for (var y = 0; y < map.GetLength(0); y++)
        {
            for (var x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x]) result++;
            }
        }
        
        Console.WriteLine($"Solution Part 1: {result}");
    }
    
    internal bool[,] AddAntiNodes(bool[,] map, List<(int x, int y)> antennas) 
    {
        if (antennas.Count == 1)
        {
            return map;
        }

        var antenna = antennas[0];
        antennas.RemoveAt(0);

        map = antennas.Aggregate(map, (current, matchAntenna) => CalculateAntiNodes(antenna, matchAntenna, current));

        return AddAntiNodes(map, antennas);
    }
    
    internal bool[,] CalculateAntiNodes((int x, int y) antenna, (int x, int y) matchAntenna, bool[,] map)
    {
        var diffX = antenna.x - matchAntenna.x;
        var diffY = antenna.y - matchAntenna.y;

        var Gcd = CalculateGcd(diffX, diffY);
        diffX /= Gcd;
        diffY /= Gcd;
        
        var possibleNode = antenna;
        while (true)
        {
            if (!IsOnMap(possibleNode, map))
            {
                break;
            }
            map[possibleNode.y, possibleNode.x] = true;
            
            possibleNode = (possibleNode.x + diffX, possibleNode.y + diffY);
        }
        
        possibleNode = antenna;
        while (true)
        {
            if (!IsOnMap(possibleNode, map))
            {
                break;
            }
            map[possibleNode.y, possibleNode.x] = true;
            
            possibleNode = (possibleNode.x - diffX, possibleNode.y - diffY);
        }

        return map;
    }
    
    internal bool IsOnMap((int x, int y) node, bool[,] map) => 
        node.x >= 0 
        && node.y >= 0 
        && node.x < map.GetLength(1) 
        && node.y < map.GetLength(0);
    
    internal static int CalculateGcd(int a, int b)
    {
        if (a == 0 || b == 0)
        {
            throw new ArgumentException("Both numbers must be non-zero.");
        }
        
        // Ensure a >= b
        if (a < b)
        {
            (a, b) = (b, a);
        }
        
        while (b != 0)
        {
            var  remainder = a % b;
            a = b;
            b = remainder;
        }

        return a;
    }
}