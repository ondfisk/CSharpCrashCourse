# Exercise 3

Create a console application

## Part 1

Examine the `Wizard.csv` file.

Create a `record` to hold wizard information.

Be sure to pick the right datatype for year (check out *Merlin* and *Morgana*).

## Part 2

Go to [NuGet](https://nuget.org/) and find the most popular package for handing `.csv` files.

Go to the *Project Website* and skim the *Getting Started* page.

Install the package

## Part 3

Read the CSV file and print out all wizards.

User should be able to supply a file path from the console (`Console.ReadLine`).

User should be able to supply a file path from command line as first argument.

## Part 4

Allow the user to select an option for examining wizards:

- `1`: Show all.
- Anything else: Exit

## Part 5

Allow the user to select an option for examining wizards:

- `2`: Ten youngest.
- `3`: Ten oldest.

**Note**: *Merlin* and *Morgana* are the oldest...

## Part 6

Allow the user to select an option for examining wizards:

- `4`: Find by `Year`.

Not a number should display error message and exit.

**Note**: Capture year with `Console.ReadLine` and `int.TryParse`.

## Part 7

Allow the user to select an option for examining wizards:

- `5`: Search for wizard by `Name`, `Medium`, or `Creator`.

**Note**: Implement `Name` first using `Contains`.

## Part 8

Allow the user to select an option for examining wizards:

- `6`: Export wizards to `.json`.

Capture output file path with `Console.ReadLine`.

When no path given, use current path.

## Part 9 (Homework)

Reset.

Do parts 1-8 using TDD.

Make search case insensitive and possibly accent insensitive.
