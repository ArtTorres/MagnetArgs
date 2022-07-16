# Default Rule

Sets a default value if the argument hasn't been provided with a defined value.
If the argumment hasn't been provided, a default value is set.

Object properties will require [Parsers]() attribute to propertly set the
required values.

## Setup

1. Add the Default attribute to your Magnet argument.
2. Provide or not the argument as an input with a value.
3. Catch the ArgumentNotFoundException to identify the missing arguments.

### Example >
``` csharp
using MagnetArgs;
...

[Magnetizable]
class Options{
    [Argument("max", Default(20))]
    public int Maximum {get;set;}
}

string[] args = Environment.GetCommandLineArgs();
var object = Magnet.Attract<Options>(args);

Console.WriteLine("Maximum: {object.Maximum}");

```

### Terminal >
``` shell

# Default Disabled
C:\Demo> app.exe --max 50
C:\Demo> Maximum: 50

# Default Enabled
C:\Demo> app.exe
C:\Demo> Maximum: 20

```

## Default Rule for native properties

Sets a default value to the property when the argument hasn't been provided.

If an argument value is provided, the value is set.

### Example >
``` csharp
using MagnetArgs;
...

[Magnetizable]
class Options{
    [Argument("max", Default(20))]
    public int Maximum {get;set;}
}

string[] args = Environment.GetCommandLineArgs();
var object = Magnet.Attract<Options>(args);

Console.WriteLine("Maximum: {object.Minimum}");

```

### Terminal >
``` shell

# Default Disabled
C:\Demo> app.exe --max 50
C:\Demo> Maximum: 50

# Default Enabled
C:\Demo> app.exe
C:\Demo> Maximum: 20

```

## Default Rule for object properties

Sets a default value to the property when the argument hasn't been provided. 

A parser attribute is required to convert the default value to an object.

If an argument value is provided, the value is set.

### Example >
``` csharp
using MagnetArgs;
...

[Magnetizable]
class Options{
    [Argument("point", Default("[15,20]"), Parser(typeof(Point)))]
    public Point Point {get;set;}
}

string[] args = Environment.GetCommandLineArgs();
var object = Magnet.Attract<Options>(args);

Console.WriteLine("Point: [{object.Point.X},{object.Point.Y}]");

```

### Terminal >
``` shell

# Default Disabled
C:\Demo> app.exe --point "[50,40]"
C:\Demo> Point: [50,40]

# Default Enabled
C:\Demo> app.exe
C:\Demo> Point: [15,20]

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
