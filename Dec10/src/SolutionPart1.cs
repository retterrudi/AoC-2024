namespace Dec10;

internal class SolutionPart1(string inputFile)
{
    internal void CalculateSolution()
    {
        var map = File.ReadAllLines(inputFile)
            .Select(line => line.ToCharArray().Select(it => int.Parse(it.ToString())).ToArray()).ToArray();

        var startPoints = FindStartPoints(map);

        var result = startPoints
            .Select(point => CountEndPoints(point, map))
            .Sum();

        Console.WriteLine($"Solution Part 1: {result}");
    }
    
    private List<Point> FindStartPoints(int[][] map)
    {
        var pointList = new List<Point>();
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == 0)
                {
                    pointList.Add(new Point(x, y));
                }
            }
        }

        return pointList;
    }
    
    private int CountEndPoints(Point startPoint, int[][] map)
    {
        var endPoints = WalkPath(startPoint, 0, map);
        return endPoints.Distinct().Count();
    }
    
    private List<Point> WalkPath(Point currentPoint, int targetValue, int[][] map)
    {
        if (PointIsNotOnMap(currentPoint, map))
        {
            return [];
        }
        
        var currentValue = map[currentPoint.Y][currentPoint.X];
        
        if (currentValue != targetValue)
        {
            return [];
        }
        
        if (currentValue == 9)
        {
            return [currentPoint];
        }

        return WalkPath(currentPoint with { X = currentPoint.X + 1 }, currentValue + 1, map)
            .Concat(WalkPath(currentPoint with { Y = currentPoint.Y + 1 }, currentValue + 1, map)
            .Concat(WalkPath(currentPoint with { X = currentPoint.X - 1 }, currentValue + 1, map)
            .Concat(WalkPath(currentPoint with { Y = currentPoint.Y - 1 }, currentValue + 1, map)))).ToList();
    }

    private static bool PointIsNotOnMap(Point currentPoint, int[][] map)
    {
        return currentPoint.X < 0 
               || currentPoint.Y < 0 
               || currentPoint.X >= map[0].Length 
               || currentPoint.Y >= map.Length;
    }
}

internal record Point(int X, int Y);