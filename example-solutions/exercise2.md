# Exercise 2

## Exists

```csharp
public static bool Exists(int[] numbers, int number)
{
    if (numbers.Length == 0)
    {
        return false;
    }

    bool found = false;

    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] == number)
        {
            found = true;
            break;
        }
    }

    return found;
}

[Fact]
public void Exists_given_empty_list_returns_false()
{
    // Arrange
    int[] numbers = [];
    int number = 42;

    // Act
    var result = ArrayFunctions.Exists(numbers, number);

    // Assert
    Assert.False(result);
}

[Fact]
public void Exists_given_1_2_3_4_5_and_42_returns_false()
{
    // Arrange
    int[] numbers = [1, 2, 3, 4, 5];
    int number = 42;

    // Act
    var result = ArrayFunctions.Exists(numbers, number);

    // Assert
    Assert.False(result);
}

[Fact]
public void Exists_given_1_2_3_4_5_and_3_returns_true()
{
    // Arrange
    int[] numbers = [1, 2, 3, 4, 5];
    int number = 3;

    // Act
    var result = ArrayFunctions.Exists(numbers, number);

    // Assert
    Assert.True(result);
}
```

## Evens

```csharp
public static int[] Evens(int[] numbers)
{
    var result = new List<int>();

    int i = 0;
    while (i < numbers.Length)
    {
        int number = numbers[i++];
        if (number % 2 == 1)
        {
            continue;
        }
        result.Add(number);
    }

    return [.. result];
}

[Fact]
public void Evens_given_1_2_3_4_5_returns_2_4()
{
    // Arrange
    int[] numbers = [1, 2, 3, 4, 5];

    // Act
    var result = ArrayFunctions.Evens(numbers);

    // Assert
    Assert.Equal([2, 4], result);
}
```

## Smallest

```csharp
public static int Smallest(int[] numbers)
{
    if (numbers.Length == 0)
    {
        throw new ArgumentException($"{nameof(numbers)} can not be empty.", nameof(numbers));
    }

    var result = int.MaxValue;

    foreach (var number in numbers)
    {
        if (number < result)
        {
            result = number;
        }
    }

    return result;
}

[Fact]
public void Smallest_given_empty_list_throws_ArgumentException()
{
    Assert.Throws<ArgumentException>(() => ArrayFunctions.Smallest([]));
}

[Fact]
public void Smallest_given_1_2_3_4_5_returns_1()
{
    // Arrange
    int[] numbers = [1, 2, 3, 4, 5];

    // Act
    var result = ArrayFunctions.Smallest(numbers);

    // Assert
    Assert.Equal(1, result);
}
```

## Unique

```csharp
public static int[] Unique(int[] numbers)
{
    var result = new List<int>();

    foreach (var number in numbers)
    {
        if (!result.Contains(number))
        {
            result.Add(number);
        }
    }

    return [.. result];
}

[Fact]
public void Unique_given_1_1_2_3_1_3_returns_1_2_3()
{
    // Arrange
    int[] numbers = [1, 1, 2, 3, 1, 3];

    // Act
    var result = ArrayFunctions.Unique(numbers);

    // Assert
    Assert.Equal([1, 2, 3], result);
}
```

## OlderThan

```csharp
public static Duck[] OlderThan(Duck[] ducks, int age)
{
    var result = new List<Duck>();

    foreach (var duck in ducks)
    {
        if (duck.Age > age)
        {
            result.Add(duck);
        }
    }

    return [.. result];
}

[Fact]
public void OlderThan_given_Ducks_and_60_returns_Flintheart_and_Magica()
{
    // Arrange
    var repository = new DuckRepository();
    var ducks = repository.Read();
    var age = 60;

    // Act
    var result = ArrayFunctions.OlderThan(ducks, age);

    // Assert
    Assert.Equal([new("Magica De Spell", 302), new("Flintheart Glomgold", 66)], result);
}
```
