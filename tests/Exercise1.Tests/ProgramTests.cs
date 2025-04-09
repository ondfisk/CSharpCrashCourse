using System.Reflection;

namespace Exercise1.Tests;

public class ProgramTests
{
    [Fact]
    public void Main_prints_Hello_World()
    {
        // Arrange
        var writer = new StringWriter();
        Console.SetOut(writer);

        // Act
        var entryPoint = typeof(Program).Assembly.EntryPoint!;
        entryPoint.Invoke(null, [Array.Empty<string>()]);

        // Assert
        var output = writer.GetStringBuilder().ToString().Trim();
        Assert.Equal("Hello, World!", output);
    }

    [Fact]
    public void Main_given_argument_prints_Hello_argument()
    {
        // Arrange
        var writer = new StringWriter();
        Console.SetOut(writer);
        string[] input = ["Rasmus"];

        // Act
        var entryPoint = typeof(Program).Assembly.EntryPoint!;
        entryPoint.Invoke(null, [input]);

        // Assert
        var output = writer.GetStringBuilder().ToString().Trim();
        Assert.Equal("Hello, Rasmus!", output);
    }

    [Fact]
    public void Main_given_multiple_arguments_throws_ArgumentOutOfRangeException()
    {
        // Arrange
        var writer = new StringWriter();
        Console.SetOut(writer);
        string[] input = ["Rasmus", "Lystrøm"];

        // Act
        var entryPoint = typeof(Program).Assembly.EntryPoint!;
        var exception = Assert.Throws<TargetInvocationException>(() => entryPoint.Invoke(null, [input]));

        // Assert
        Assert.IsType<ArgumentOutOfRangeException>(exception.InnerException);
    }
}
