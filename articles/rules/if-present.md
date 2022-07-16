# If-Present Rule

Sets a default value if the argument has been provided without a defined value.
If the argumment hasn't been provided, no action is taken.

Non boolean properties will require [Parsers]() and [Default]() attributes to propertly set the
required values.

## Setup

1. Add the IfPresent attribute to your Magnet argument.
2. Provide the argument as an input without value.
3. Catch the ArgumentNotFoundException to identify the missing arguments.

### Example >
``` csharp
using MagnetArgs;
...

[Magnetizable]
class Options{
    [Argument("show", IfPresent)]
    public bool Show {get;set;}
}

string[] args = Environment.GetCommandLineArgs();
var object = Magnet.Attract<Options>(args);

Console.WriteLine("Show Enabled: {object.Show}");

```

### Terminal >
``` shell

# Enabled
C:\Demo> app.exe --show
C:\Demo> Show Enabled: True

# Disabled
C:\Demo> app.exe
C:\Demo> Show Enabled: False

```

## If-Present Rule for native properties

Sets a default value to the property when the argument has been provided without value.

If an argument value is provided, the value is set.

### Example >
``` csharp
using MagnetArgs;
...

[Magnetizable]
class Options{
    [Argument("min", IfPresent, Default(10))]
    public int Minimum {get;set;}
}

string[] args = Environment.GetCommandLineArgs();
var object = Magnet.Attract<Options>(args);

Console.WriteLine("Minimum: {object.Minimum}");

```

### Terminal >
``` shell

# Enabled
C:\Demo> app.exe --min
C:\Demo> Minimum: 10

# Disabled
C:\Demo> app.exe
C:\Demo> Minimum: 0

# With input value
C:\Demo> app.exe --min 40
C:\Demo> Minimum: 40

```

## If-Present Rule for object properties

Sets a default value to the property when the argument has been provided without value. 

A parser attribute is required to convert the default value to an object.

If an argument value is provided, the value is set.

### Example >
``` csharp
using MagnetArgs;
...

[Magnetizable]
class Options{
    [Argument("point", IfPresent, Default("[15,20]"), Parser(typeof(Point)))]
    public Point Point {get;set;}
}

string[] args = Environment.GetCommandLineArgs();
var object = Magnet.Attract<Options>(args);

if(object.Point is null)
    Console.WriteLine("No point has been set");
else
    Console.WriteLine("Point: [{object.Point.X},{object.Point.Y}]");

```

### Terminal >
``` shell

# Enabled
C:\Demo> app.exe --point
C:\Demo> Point: [15,20]

# Disabled
C:\Demo> app.exe
C:\Demo> No point has been set

# With input value
C:\Demo> app.exe --point "[50,40]"
C:\Demo> Point: [50,40]

```

## Capture Exceptions

### Expected Exceptions >

- [Exception](). Triggered when xx
- [Exception](). Triggered when xx
- [Exception](). Triggered when xx

### Example >
``` csharp
...

try{

    string[] args = Environment.GetCommandLineArgs();
    var object = Magnet.Attract<Options>(args);

    Console.WriteLine(object.Filename);
}catch(Exception ex){
    Console.WriteLine("Argument not found");
}

```

### Terminal >
``` shell

C:\Demo> app.exe
C:\Demo> Argument not found

```

---
<center>
[<< Rules]() | [Home]() | [If-Present Rule >>]()
</center>
