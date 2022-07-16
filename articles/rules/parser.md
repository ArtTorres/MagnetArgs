# Parsers

Converts an argument into an object.

## Setup

1. Add the Parser attribute to your Magnet argument.
2. Provide or not the argument as an input with a value.
3. Catch the ArgumentNotFoundException to identify the missing arguments.

### Example >
``` csharp
using MagnetArgs;
...

[Magnetizable]
class Options{
    [Argument("point", Parser(typeof(Point)))]
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

# Parser Enabled 
C:\Demo> app.exe --point "[50,40]"
C:\Demo> Point: [50,40]

# Parser Disabled
C:\Demo> app.exe
C:\Demo> No point has been set

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
