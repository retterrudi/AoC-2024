using Dec1.SolutionPart1;
using Dec1.SolutionPart2;

class Programm
{
    public static void Main(string[] args)
    {
        var solution = new SolutionPart1(args[0]);
        solution.CalculateSolution();
        var solution2 = new SolutionPart2(args[0]);
        solution2.CalculateSolution();
    }
}