# Exercise 3

## `Wizard.cs`

```csharp
namespace Exercise3;

public record Wizard(string Name, string Medium, int? Year, string Creator);
```

## `Program.cs`

```csharp
using System.Globalization;
using System.Text.Json;
using CsvHelper;
using Exercise3;

Console.WriteLine("Welcome to the Wizards App!");
Console.WriteLine();

string? path;
if (args.Length > 0)
{
    path = args[0];
}
else
{
    Console.Write("Input path to wizards csv: ");
    path = Console.ReadLine();

    Console.WriteLine();
}

if (string.IsNullOrWhiteSpace(path))
{
    Console.WriteLine("No file given!");
    return;
}

if (!File.Exists(path))
{
    Console.WriteLine("File not found!");
    return;
}

var wizards = Read(path);

Console.WriteLine($"File contains {wizards.Count} wizards. Select an option:");
Console.WriteLine();
Console.WriteLine("1: Show all");
Console.WriteLine("2: Ten youngest");
Console.WriteLine("3: Ten oldest");
Console.WriteLine("4: Find by year");
Console.WriteLine("5: Find by name, medium, or creator");
Console.WriteLine("6: Export to .json");
Console.WriteLine();
Console.Write("Input option: ");

var option = Console.ReadLine();

switch (option)
{
    case "1":
        Print(wizards);
        break;
    case "2":
        var youngest = wizards.OrderByDescending(w => w.Year).Take(10);
        Print(youngest);
        break;
    case "3":
        var oldest = wizards.OrderBy(w => w.Year).Take(10);
        Print(oldest);
        break;
    case "4":
        Console.Write("Input year: ");
        if (!int.TryParse(Console.ReadLine(), out var year))
        {
            Console.WriteLine("Invalid year, exiting.");
            return;
        }
        Console.WriteLine();
        var byYear = wizards.Where(w => w.Year == year);
        Print(byYear);
        break;
    case "5":
        Console.Write("Input search string: ");
        var searchString = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(searchString))
        {
            Console.WriteLine("Invalid search string, exiting.");
            return;
        }
        Console.WriteLine();
        var found = wizards.Where(w =>
            w.Name.Contains(searchString) ||
            w.Medium.Contains(searchString) ||
            w.Creator.Contains(searchString)
        );
        Print(found);
        break;
    case "6":
        Console.Write("Input output path: ");
        var outputPath = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(outputPath))
        {
            outputPath = path.Replace(".csv", ".json");
        }
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(wizards, options);
        File.WriteAllText(outputPath, json);
        Console.WriteLine($"File written to '{outputPath}'");
        break;
    default:
        Console.WriteLine("Unknown option, exiting.");
        break;
}

static void Print(IEnumerable<Wizard> wizards)
{
    foreach (var wizard in wizards)
    {
        Console.WriteLine(wizard);
    }
}

static ICollection<Wizard> Read(string path)
{
    using var reader = new StreamReader(path);

    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

    var wizards = csv.GetRecords<Wizard>().ToList();

    return wizards;
}
```
