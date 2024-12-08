using Xunit;
using Dec04;

namespace Dec04.tests.SolutionPart.Test;

public class BoundTests
{
    [Fact] 
    public void UpperLeftCornerOutgoing()
    {
        char[][] array = new[]
        {
            new[] { 'X', 'M', 'A', 'S', 'O' },
            new[] { 'M', 'M', 'O', 'O', 'O' },
            new[] { 'A', 'O', 'A', 'O', 'O' },
            new[] { 'S', 'O', 'O', 'S', 'O' },
            new[] { 'O', 'O', 'O', 'O', 'O' }
        };

        var solution = new SolutionPart1("");
        var result = solution.FindWords(array);
        
        Assert.Equal(3, result);
    }
    
    [Fact] 
    public void UpperRightCornerOutgoing()
    {
        char[][] array = new[]
        {
            new[] { 'O', 'S', 'A', 'M', 'X' },
            new[] { 'O', 'O', 'O', 'M', 'M' },
            new[] { 'O', 'O', 'A', 'O', 'A' },
            new[] { 'O', 'S', 'O', 'O', 'S' },
            new[] { 'O', 'O', 'O', 'O', 'O' }
        };

        var solution = new SolutionPart1("");
        var result = solution.FindWords(array);
        
        Assert.Equal(3, result);
    }
    
    [Fact] 
    public void LowerRightCornerOutgoing()
    {
        char[][] array = new[]
        {
            new[] { 'O', 'O', 'O', 'O', 'O' },
            new[] { 'O', 'S', 'O', 'O', 'S' },
            new[] { 'O', 'O', 'A', 'O', 'A' },
            new[] { 'O', 'O', 'O', 'M', 'M' },
            new[] { 'O', 'S', 'A', 'M', 'X' }
        };

        var solution = new SolutionPart1("");
        var result = solution.FindWords(array);
        
        Assert.Equal(3, result);
    }
    
    [Fact] 
    public void LowerLeftCornerOutgoing()
    {
        char[][] array = new[]
        {
            new[] { 'O', 'O', 'O', 'O', 'O' },
            new[] { 'S', 'O', 'O', 'S', 'O' },
            new[] { 'A', 'O', 'A', 'O', 'O' },
            new[] { 'M', 'M', 'O', 'O', 'O' },
            new[] { 'X', 'M', 'A', 'S', 'O' }
        };

        var solution = new SolutionPart1("");
        var result = solution.FindWords(array);
        
        Assert.Equal(3, result);
    }
    
    [Fact]
    public void UpperLeftCorningIncoming()
    {
        char[][] array = new[]
        {
            new[] { 'S', 'A', 'M', 'X', 'O' },
            new[] { 'A', 'A', 'O', 'O', 'O' },
            new[] { 'M', 'O', 'M', 'O', 'O' },
            new[] { 'X', 'O', 'O', 'X', 'O' },
            new[] { 'O', 'O', 'O', 'O', 'O' }
        };

        var solution = new SolutionPart1("");
        var result = solution.FindWords(array);
        
        Assert.Equal(3, result);
    }
    
    [Fact]
    public void UpperRightCorningIncoming()
    {
        char[][] array = new[]
        {
            new[] { 'O', 'X', 'M', 'A', 'S' },
            new[] { 'O', 'O', 'O', 'A', 'A' },
            new[] { 'O', 'O', 'M', 'O', 'M' },
            new[] { 'O', 'X', 'O', 'O', 'X' },
            new[] { 'O', 'O', 'O', 'O', 'O' }
        };

        var solution = new SolutionPart1("");
        var result = solution.FindWords(array);
        
        Assert.Equal(3, result);
    }
    
    [Fact]
    public void LowerRightCorningIncoming()
    {
        char[][] array = new[]
        {
            new[] { 'O', 'O', 'O', 'O', 'O' },
            new[] { 'O', 'X', 'O', 'O', 'X' },
            new[] { 'O', 'O', 'M', 'O', 'M' },
            new[] { 'O', 'O', 'O', 'A', 'A' },
            new[] { 'O', 'X', 'M', 'A', 'S' }
        };

        var solution = new SolutionPart1("");
        var result = solution.FindWords(array);
        
        Assert.Equal(3, result);
    }
    
    [Fact]
    public void LowerRightCorningIncoming1()
    {
        char[][] array = new[]
        {
            new[] { 'O', 'O', 'O', 'O', 'O' },
            new[] { 'O', 'O', 'O', 'O', 'O' },
            new[] { 'O', 'O', 'O', 'O', 'O' },
            new[] { 'O', 'O', 'O', 'O', 'O' },
            new[] { 'O', 'X', 'M', 'A', 'S' }
        };

        var solution = new SolutionPart1("");
        var result = solution.FindWords(array);
        
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void LowerRightCorningIncoming2()
    {
        char[][] array = new[]
        {
            new[] { 'O', 'O', 'O', 'O', 'O' },
            new[] { 'O', 'X', 'O', 'O', 'O' },
            new[] { 'O', 'O', 'M', 'O', 'O' },
            new[] { 'O', 'O', 'O', 'A', 'O' },
            new[] { 'O', 'O', 'O', 'O', 'S' }
        };

        var solution = new SolutionPart1("");
        var result = solution.FindWords(array);
        
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void LowerRightCorningIncoming3()
    {
        char[][] array = new[]
        {
            new[] { 'O', 'O', 'O', 'O', 'O' },
            new[] { 'O', 'O', 'O', 'O', 'X' },
            new[] { 'O', 'O', 'O', 'O', 'M' },
            new[] { 'O', 'O', 'O', 'O', 'A' },
            new[] { 'O', 'O', 'O', 'O', 'S' }
        };

        var solution = new SolutionPart1("");
        var result = solution.FindWords(array);
        
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void LowerLeftCorningIncoming()
    {
        char[][] array = new[]
        {
            new[] { 'O', 'O', 'O', 'O', 'O' },
            new[] { 'X', 'O', 'O', 'X', 'O' },
            new[] { 'M', 'O', 'M', 'O', 'O' },
            new[] { 'A', 'A', 'O', 'O', 'O' },
            new[] { 'S', 'A', 'M', 'X', 'O' }
        };

        var solution = new SolutionPart1("");
        var result = solution.FindWords(array);
        
        Assert.Equal(3, result);
    }
}