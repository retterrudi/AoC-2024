// See https://aka.ms/new-console-template for more information

using Dec02;

public class Program
{
    public static void Main(string[] args)
    {
        var solution1 = new SolutionPart1(args[0]);
        solution1.CalculateSolution();
        var solution2 = new SolutionPart2(args[0]);
        solution2.CalculateSolution();
    }
}