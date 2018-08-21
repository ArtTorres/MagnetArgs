# MagnetArgs
MagnetArgs helps in the task of mapping arguments to objects. Accelerating the process of define option variables in console applications or map complex objects in a variety of scenarios.
----
## Basic Tasks
1. Map your option objects.
2. Magnetize them.
3. Enjoy!

----

### How to set an Option Object
It's as simple as define a class, extend from MagnetOption and define the Arg-ument attribute in the properties you want to map.
You can define an alias if you need a shorcut word for your arguments.

Example:
``` csharp
class TypeObject : MagnetOption
{
    [Arg("string-value", Alias = "string")]
    public string StringValue { get; set; }

    [Arg("char-value", Alias = "char")]
    public char CharValue { get; set; }

    [Arg("integer-value", Alias = "int")]
    public int IntegerValue { get; set; }

    [Arg("long-value", Alias = "long")]
    public long LongValue { get; set; }

    [Arg("boolean-value", Alias = "bool")]
    public bool BooleanValue { get; set; }

    [Arg("float-value", Alias = "float")]
    public float FloatValue { get; set; }

    [Arg("double-value", Alias = "double")]
    public double DoubleValue { get; set; }

    [Arg("decimal-value", Alias = "decimal")]
    public decimal DecimalValue { get; set; }
}
```

### How can you Magnetize an Object
If you have an instance of your option object, then you can magnetize it. Provide the object and the arguments to Magnet. It will be automatically mapped.

Example:
``` csharp
var args = new string[];
var obj = new TypeObject();

Magnet.Magnetize(obj, args);
```

### How to manage Exceptions
What happens if an error occurred? All errors are stored in the Exceptions property in your option object.
You can access them as in the example:
``` csharp
foreach (var ex in obj.Exceptions)
{
    throw ex;
}
```

### What about Complex Options
Any complex object like classes need to be parsed. You can define how convert an input string to any object with the rules you define.

Define a custom parser implementing the interface IParser.
``` csharp
class CustomPointParser : IParser
{
    public object Parse(string value)
    {
        var values = value.Replace("[", "").Replace("]", "").Trim().Split(',');
        if (values.Length == 2)
        {
            var obj = new CustomPoint();
            obj.X = int.Parse(values[0]);
            obj.Y = int.Parse(values[1]);

            return obj;
        }
        else
        {
            throw new Exception("Error parsing CustomPoint");
        }
    }
}
```

Set within an argument the Parser attribute, then specify your custom parser.
``` csharp
class CustomObject : MagnetOption
{
    [Arg("custom-point", Alias = "point"), Parser(typeof(CustomPointParser))]
    public CustomPoint Point { get; set; }
}
```

It's done, now you can Magnetize your instance.
``` csharp
var obj = new ComplexObject();

Magnet.Magnetize(obj, args);
```
----

## Argument Rules
With MagnetArgs you can define arguments with the following rules:
- Is-Required
- If-Present
- Default
- Parse
- OptionSet

Use any combination to archieve the behaviour you need.

### Is-Required Rule
This rule lauches an exception if there's no value or label in the arguments array.

Example:
``` csharp
// Option class
class ComplexObject : MagnetOption
{
    [Arg("required-value"), IsRequired]
    public string RequiredValue { get; set; }
}

// Magnetize
var obj = new ComplexObject();

Magnet.Magnetize(obj, args);

// If not found, complex object contains a IsRequiredException.
foreach (var ex in obj.Exceptions)
{
    throw ex;
}
```

### If-Present Rule
This rule evaluates if exist a label in the arguments array. 
If option is of boolean type, it will set with the value 'true'.
If option is of any other type, it will be set with the 'default' value.

Example:
``` csharp
// Option class
class ComplexObject : MagnetOption
{
    [Arg("present-value"), IfPresent]
    public bool PresentValue { get; set; }

    [Arg("default-value"), IfPresent, Default("25")]
    public int DefaultValue { get; set; }
}

// Magnetize
var obj = new ComplexObject();

Magnet.Magnetize(obj, args);
```

### Default Value Rule
This rule sets a default value if no value provided in the arguments array.
Complex values require a MagnetArgs.ParserAttribute definition.

Example:
``` csharp
// Option class
class ComplexObject : MagnetOption
{
    [Arg("default-value"), Default("25")]
    public int DefaultValue { get; set; }
}

// Magnetize
var obj = new ComplexObject();

Magnet.Magnetize(obj, args);
```

### Parse Value Rule
This rule specifies the parser required to convert a text input to a class instance.

Example:
``` csharp
// Option class
class ComplexObject : MagnetOption
{
    [Arg("custom-point", Alias = "point"), Parser(typeof(CustomPointParser))]
    public CustomPoint Point { get; set; }
}

// Magnetize
var obj = new ComplexObject();

Magnet.Magnetize(obj, args);
```
----

## Magnetize with OptionSet
When you have an object with multiple option classes, you can magnetize them at one using OptionSet.
Specify the OptionSet attribute in the properties with options who implement MagnetArgs.ArgAttribute.
You will be able to magnetize the full object.

Example:
``` csharp
// Option classes
class PresentObject : MagnetOption
{
    [Arg("present-value"), IfPresent]
    public bool PresentValue { get; set; }

    [Arg("raise-ex"), IfPresent]
    public int RaiseException { get; set; }
}

class CustomObject : MagnetOption
{
    [Arg("custom-point", Alias = "point"), Parser(typeof(CustomPointParser))]
    public CustomPoint Point { get; set; }
}

// OptionSet class
class OptionSetObject
{
    [OptionSet]
    public PresentPassObject PObject { get; set; }

    [OptionSet]
    public CustomObject CObject { get; set; }
}

// Magnetize
var obj = new OptionSetObject();

Magnet.Magnetize(obj, args);
```
----
