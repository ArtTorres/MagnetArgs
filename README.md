# MagnetArgs
MagnetArgs helps in the task of mapping arguments to objects. Accelerating the process of define option variables in console applications or map complex objects in a variety of scenarios.
----
## Basic Tasks
- Map your option objects.
- Magnetize them.
- Enjoy!

----

### How to set an Option Object
It's as simple as define a class, extend from MagnetOption and define the Arg-ument attribute in the properties you want to map.
You can define an alias if you need a shorcut word for your arguments.

Example:
```
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
```
var args = new string[];
var obj = new TypeObject();

Magnet.Magnetize(obj, args);
```

### How to manage Exceptions
What happens if an error occurred? All errors are stored in the Exceptions property in your option object.
You can access them as in the example:
```
foreach (var ex in obj.Exceptions)
{
    throw ex;
}
```

### What about Complex Options
Any complex object like classes need to be parsed. You can define how convert an input string to any object with the rules you define.

Define a custom parser implementing the interface IParser.
```
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
```
class CustomObject : MagnetOption
{
    [Arg("custom-point", Alias = "point"), Parser(typeof(CustomPointParser))]
    public CustomPoint Point { get; set; }
}
```

It's done, now you can Magnetize your instance.
```
var obj = new ComplexObject();

Magnet.Magnetize(obj, args);
```
----