using System.Data;
using Dec06.dataTypes;

namespace Dec06;

public class SolutionPart2(string inputFile)
{
    
    internal void CalculateSolution()
    {
        var rawInput = File.ReadAllText(inputFile);
        var array = rawInput
            .Split("\n")
            .Select(line => line.ToCharArray())
            .ToArray();

        var startingPoint = FindStartingPoint(array);
        var startingDirection = array[startingPoint.Y][startingPoint.X].ToDirection();

        var trail = MarkTrail(startingPoint, startingDirection, array);
        var result = CountPossibleBlocks(trail, startingPoint, startingDirection);
        // trail.PrintToConsole();
        Console.WriteLine($"Solution Part 2: {result}");
    }

    private int CountPossibleBlocks(
        char[][] trail, 
        Point startingPoint, 
        Direction startingDirection)
    {
        var count = 0;
        
        for (var y = 0; y < trail.Length; y++)
        {
            for (var x = 0; x < trail[0].Length; x++)
            {
                if (trail[y][x] == 'X')
                {
                    var array = trail.CopyArray();
                    array[y][x] = '#';
                    if (TrailIsLoop(array, startingPoint, startingDirection))
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    private bool TrailIsLoop(
        char[][] trail, 
        Point startingPoint, 
        Direction startingDirection)
    {
        var currentPoint = startingPoint;
        var currentDirection = startingDirection;
        var map = new Dictionary<Direction, bool>[trail.Length, trail[0].Length];

        var followPath = true;
        while (followPath)
        {
            var move = CheckLoopMove(currentPoint, currentDirection, trail, map);
            switch (move)
            {
                case LoopMove.Valid:
                    currentPoint += currentDirection;
                    if (map[currentPoint.Y, currentPoint.X] is null) 
                    {
                        map[currentPoint.Y, currentPoint.X] = new Dictionary<Direction, bool>() {{currentDirection, true}};
                    }
                    else
                    {
                        map[currentPoint.Y, currentPoint.X][currentDirection] = true;
                    }
                    break;
                case LoopMove.Obstacle:
                    currentDirection = currentDirection.Next();
                    break;
                case LoopMove.OutOfBounds:
                    followPath = false;
                    break;
                case LoopMove.Loop:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return false;
    }
    
    private LoopMove CheckLoopMove(
        Point position, 
        Direction direction, 
        char[][] array, 
        Dictionary<Direction, bool>[,] map)
    {
        var nextPoint = position + direction;
    
        if (PointOutOffBounds(nextPoint, array))
        {
            return LoopMove.OutOfBounds;
        } 
        else if (array[nextPoint.Y][nextPoint.X] == '#')
        {
            return LoopMove.Obstacle;
        }
        else if (map[nextPoint.Y, nextPoint.X] != null)
        {
            if (map[nextPoint.Y, nextPoint.X].ContainsKey(direction))
            {
                return map[nextPoint.Y, nextPoint.X][direction] ? LoopMove.Loop : LoopMove.Valid;
            }
            else
            {
                return LoopMove.Valid;
            }
        }
        else
        {
            return LoopMove.Valid;
        }
    }

    private char[][] MarkTrail(
        Point startingPoint, 
        Direction startingDirection, 
        char[][] array)
    {
        var currentPoint = startingPoint;
        var currentDirection = startingDirection;
        array[currentPoint.Y][currentPoint.X] = 'X';

        var followPath = true;
        while (followPath)
        {
            var move = MoveIsPossible(currentPoint, currentDirection, array);
            switch (move)
            {
                case MoveOutCome.Valid:
                    currentPoint += currentDirection;
                    array[currentPoint.Y][currentPoint.X] = 'X';
                    break;
                case MoveOutCome.Obstacle:
                    currentDirection = currentDirection.Next();
                    break;
                case MoveOutCome.OutOfBounds:
                    followPath = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        array[startingPoint.Y][startingPoint.X] = startingDirection.ToChar();

        return array;
    }
    
    private MoveOutCome MoveIsPossible(
        Point position, 
        Direction direction, 
        char[][] array)
    {
        var nextPoint = position + direction;
        
        if (PointOutOffBounds(nextPoint, array))
        {
            return MoveOutCome.OutOfBounds;
        } 
        else if (array[nextPoint.Y][nextPoint.X] == '#')
        {
            return MoveOutCome.Obstacle;
        }
        else
        {
            return MoveOutCome.Valid;
        }
    }

    private Point FindStartingPoint(char[][] array)
    {
        for (var y = 0; y < array.Length; y++)
        {
            for (var x = 0; x < array[0].Length; x++) 
            {
                if (array[y][x] != '.' && array[y][x] != '#')
                {
                    return new Point(x, y);
                }
            }
        }

        throw new DataException();
    }
    
    private bool PointOutOffBounds(Point point, char[][] array)
    {
        return point.Y >= array.Length
               || point.Y < 0
               || point.X >= array[0].Length
               || point.X < 0;
    }
}

internal enum LoopMove
{
    Valid,
    Obstacle,
    OutOfBounds,
    Loop
}