# MagnetArgs
_"Simple argument parser with magnetism"_

MagnetArgs helps with the task of mapping arguments to objects. Accelerating the process of define option variables in console applications or map complex objects in a variety of scenarios.

---

## Install
Choose the method of your convenience.

Package Manager:
``` shell
PM> Install-Package MagnetArgs
```
.Net CLI:
``` shell
> dotnet add package MagnetArgs
```

[>> See more installation options](https://arttorres.github.io/MagnetArgs/articles/install.html)
---

## Basic Setup

### Step 1. Define your classes

It's as simple as define a class, decorating with the [Magnetizable] attribute and decorating the properties you want to map with the [Argument] attribute.

You can define an alias for your arguments, set mapping rules and add parsing functions as you need.

Example:
``` csharp
[Magnetizable]
class TypeObject
{
    [Argument("string-value", Alias = "string")]
    public string StringValue { get; set; }

    [Argument("char-value", Alias = "char")]
    public char CharValue { get; set; }

    [Argument("integer-value", Alias = "int")]
    public int IntegerValue { get; set; }

    [Argument("long-value", Alias = "long")]
    public long LongValue { get; set; }

    [Argument("boolean-value", Alias = "bool")]
    public bool BooleanValue { get; set; }

    [Argument("float-value", Alias = "float")]
    public float FloatValue { get; set; }

    [Argument("double-value", Alias = "double")]
    public double DoubleValue { get; set; }

    [Argument("decimal-value", Alias = "decimal")]
    public decimal DecimalValue { get; set; }
}
```

### Step 2. Attract All

With an instance of your object, you can magnetize and attract values. Provide the object and arguments to <Magnet.Attract>. They will be assigned automatically.

Example:
``` csharp
var inputArgs = new string[] {
    "-string", "This is an String",
    "-char", "C",
    "-int", "128",
    "-long", "128",
    "-bool", "true",
    "-float", "12.8",
    "-double", "12.8",
    "-decimal", "12.8"
};

// Get object from arguments
var yourObject = Magnet.Attract<TypeObject>(inputArgs);

// OR Send an object as reference
var yourObject = new TypeObject();
Magnet.Attract(inputArgs, yourObject);
```

### Step 3. Use

Example:

``` csharp
// Fully Mapped Object
Console.WriteLine(yourObject.StringValue);
Console.WriteLine(yourObject.IntegerValue);
Console.WriteLine(yourObject.DoubleValue);
...
```

[>> See more on Get Started](https://arttorres.github.io/TWidgets/articles/get-started.html)

---
## Project References
- [Homepage](https://arttorres.github.io/MagnetArgs)
- [Get Started](https://arttorres.github.io/MagnetArgs/articles/get-started.html)
- [Use Reference](https://arttorres.github.io/MagnetArgs/articles/intro.html)
- [API Documentation](https://arttorres.github.io/MagnetArgs/api/index.html)
- [Nuget Package](https://www.nuget.org/packages/MagnetArgs)
- [Release Notes](https://github.com/arttorres/MagnetArgs/releases)
- [Contributing Guidelines](https://github.com/ArtTorres/MagnetArgs/blob/master/.github/CONTRIBUTING.md)
- [License](https://github.com/ArtTorres/MagnetArgs/blob/master/LICENSE)
