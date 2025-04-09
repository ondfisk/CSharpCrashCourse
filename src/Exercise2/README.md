# Exercise 2

This exercise focusses on loops.

Implement a set of functions using the keywords `foreach`, `for`, `while`, `break`, `continue` and:

- `src/Exercise2/ArrayFunctions.cs`
- `tests/Exercise2.Tests/ArrayFunctionsTests.cs`

Implement test `-->` Implement (part of) method.

Rinse and repeat.

## Notes

To create a new *list* and add numbers to it you can:

```csharp
var list = new List<int>();
list.Add(42);
```

For the last test you need some *ducks*:

```csharp
var repository = new DuckRepository();
var ducks = repository.Read();
```
