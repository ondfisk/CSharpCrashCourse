# Notes

## Testing `Main`

Make `Program` class visible:

```csharp
public partial class Program {}
```

Add test:

```csharp
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
```

Test exceptions:

```csharp
// Assert
var exception = Assert.Throws<TargetInvocationException>(() => entryPoint.Invoke(null, [input]));
Assert.IsType<ArgumentException>(exception.InnerException);
```

## Data

```csharp
IList<Superhero> superheroes =
[
    new("Superman", "1938", Studio.DC),
    new("Batman", "1939", Studio.DC),
    new("Wonder Woman", "1941", Studio.DC),
    new("Flash", "1940", Studio.DC),
    new("Green Lantern", "1940", Studio.DC),
    new("Aquaman", "1941", Studio.DC),
    new("Spider-Man", "1962", Studio.Marvel),
    new("Iron Man", "1963", Studio.Marvel),
    new("Thor", "1962", Studio.Marvel),
    new("Hulk", "1962", Studio.Marvel),
    new("Captain America", "1941", Studio.Marvel),
    new("Black Widow", "1964", Studio.Marvel),
    new("Hawkeye", "1964", Studio.Marvel),
    new("Doctor Strange", "1963", Studio.Marvel),
    new("Black Panther", "1966", Studio.Marvel),
    new("Scarlet Witch", "1964", Studio.Marvel)
];

foreach (var hero in superheroes)
{
    Console.WriteLine(hero);
}

public enum Studio { DC, Marvel }

public record Superhero(string Name, string Year, Studio studio);
```
