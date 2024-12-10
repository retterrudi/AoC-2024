namespace Dec06;

internal static class DirectionExtensions
{
    public static Direction Next(this Direction direction)
    {
        return (Direction)((int)(direction + 1) % 4);
    }
}