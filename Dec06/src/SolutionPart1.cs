using System.Data;

namespace Dec06;

internal class SolutionPart1(string inputFile)
{
    internal void CalculateSolution()
    {
        var rawInput = File.ReadAllText(inputFile);
        var array = rawInput
            .Split("\n")
            .Select(line => line.ToCharArray())
            .ToArray();

        var startingPoint = FindStartingPoint(array);
        var startingDirection = array[startingPoint.Y][startingPoint.X] switch
        {
            '>' => Direction.Right,
            'v' => Direction.Down,
            '<' => Direction.Left,
            '^' => Direction.Up,
            _ => throw new ArgumentOutOfRangeException()
        };

        var result = CountSteps(startingPoint, startingDirection, array);
        Console.WriteLine($"Solution Part 1: {result}");
    }

    private int CountSteps(Point startingPoint, Direction startingDirection, char[][] array)
    {
        // var counter = 1;
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

        return array
            .SelectMany(line => 
                line.Where(character => character == 'X')
            ).Count();
    }
    
    private MoveOutCome MoveIsPossible(Point position, Direction direction, char[][] array)
    {
        var change = direction switch
        {
            Direction.Up => new Point(0, -1),
            Direction.Right => new Point(1, 0),
            Direction.Down => new Point(0, 1),
            Direction.Left => new Point(-1, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), "Direction error")
        };
        var nextPoint = position + change;
        
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
        return point.Y >= array.Length || point.X >= array[0].Length || point.X < 0 || point.Y < 0;
    }
}

public record Point(int X, int Y)
{
    public static Point operator +(Point left, Point right)
    {
        return new Point(left.X + right.X, left.Y + right.Y);
    }
    
    public static Point operator +(Point left, Direction right)
    {
        return right switch
        {
            Direction.Right => left + new Point(1, 0),
            Direction.Down => left + new Point(0, 1),
            Direction.Left => left + new Point(-1, 0),
            Direction.Up => left + new Point(0, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(right), right, null)
        };
    }
}

public enum Direction
{
    Up,
    Right,
    Down,
    Left
}

public static class DirectionExtensions
{
    public static Direction Next(this Direction direction)
    {
        return (Direction)((int)(direction + 1) % 4);
    }
}

internal enum MoveOutCome
{
    Valid,
    Obstacle,
    OutOfBounds
}