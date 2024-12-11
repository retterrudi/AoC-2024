namespace Dec06.dataTypes;

internal static class CharExtensions
{
    internal static Direction ToDirection(this char character)
    {
        return character switch
        {
            '>' => Direction.Right,
            'v' => Direction.Down,
            '<' => Direction.Left,
            '^' => Direction.Up,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}