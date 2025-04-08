namespace Exercise2;

public class ArrayFunctions
{
    public static bool Exists(int[] numbers, int number) => throw new NotImplementedException();
    public static IEnumerable<int> Evens(int[] numbers) => throw new NotImplementedException();
    public static int Smallest(int[] numbers) => throw new NotImplementedException();
    public static int Unique(int[] numbers) => throw new NotImplementedException();
    public static int OlderThan(Duck[] ducks, int age) => throw new NotImplementedException();

    public static Duck[] Ducks { get; } =
    [
        new ("Huey Duck", 10),
        new ("Magica De Spell", 302),
        new ("Dewey Duck", 10),
        new ("Louie  Duck", 10),
        new ("Scrooge McDuck", 60),
        new ("Flintheart Glomgold", 66),
        new ("Donald Duck", 32),
        new ("Daisy Duck", 30),
        new ("John D. Rockerduck", 55)
    ];
}

public record Duck(string Name, int Age);
