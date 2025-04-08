# Exercise 1

## `Program.cs`

```csharp
var input = "World";

if (args.Length == 1)
{
    input = args[0];
}

if (args.Length > 1)
{
    throw new ArgumentOutOfRangeException(nameof(args));
}

Console.WriteLine($"Hello, {input}!");

public partial class Program {}
```

## `ProgramTests.cs`

```csharp
using System.Reflection;

namespace Exercise1.Tests;

public class UnitTest1
{
    [Fact]
    public void Main_given_no_arguments_writes_Hello_World()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        string[] input = [];

        // Act
        var entryPoint = typeof(Program).Assembly.EntryPoint!;
        entryPoint.Invoke(null, [input]);

        // Assert
        Assert.Equal("Hello, World!", output.GetStringBuilder().ToString().Trim());
    }

    [Fact]
    public void Main_given_Brian_as_argument_writes_Hello_Brian()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        string[] input = ["Brian"];

        // Act
        var entryPoint = typeof(Program).Assembly.EntryPoint!;
        entryPoint.Invoke(null, [input]);

        // Assert
        Assert.Equal("Hello, Brian!", output.GetStringBuilder().ToString().Trim());
    }

    [Fact]
    public void Main_given_multiple_arguments_throws_ArgumentOutOfRangeException()
    {
        // Arrange
        var output = new StringWriter();
        Console.SetOut(output);
        string[] input = ["Brian", "Johnson"];

        // Act
        var entryPoint = typeof(Program).Assembly.EntryPoint!;

        // Assert
        var exception = Assert.Throws<TargetInvocationException>(() => entryPoint.Invoke(null, [input]));
        Assert.IsType<ArgumentOutOfRangeException>(exception.InnerException);
    }
}
```
