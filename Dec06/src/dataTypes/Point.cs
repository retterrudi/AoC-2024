namespace Dec06.dataTypes;

internal record Point(int X, int Y)
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