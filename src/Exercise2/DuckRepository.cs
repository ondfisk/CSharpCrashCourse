namespace Exercise2;

public class DuckRepository
{
    private readonly Duck[] _ducks =
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

    public Duck[] Read() => _ducks;
}