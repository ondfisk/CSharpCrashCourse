if (args.Length > 1)
{
    throw new ArgumentOutOfRangeException(nameof(args));
}

var name = args.Length == 1
    ? args[0]
    : "World";

Console.WriteLine($"Hello, {name}!");

public partial class Program {}
