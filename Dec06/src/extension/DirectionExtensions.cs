namespace Dec06.dataTypes;

internal static class DirectionExtensions
{
    internal static Direction Next(this Direction direction)
    {
        return (Direction)((int)(direction + 1) % 4);
    }
    
    internal static char ToChar(this Direction direction)
    {
        return direction switch
        {
            Direction.Up => '^',
            Direction.Right => '>',
            Direction.Down => 'v',
            Direction.Left => '<',
            _ => throw new ArgumentOutOfRangeException(nameof(direction))
        };
    }
}