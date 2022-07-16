# Optional Argument Rule

Sets a value in a property when the argument is provided.

## Setup

1. Set your Magnet argument.
2. Provide the argument as an input or..
3. Catch the ArgumentNotFoundException to identify the missing arguments.

### Example >
``` csharp
using MagnetArgs;
...

[Magnetizable]
class Options{
    [Argument("file")]
    public string Filename {get;set;}
}

string[] args = Environment.GetCommandLineArgs();
var object = Magnet.Attract<Options>(args);

Console.WriteLine(object.Filename);

```

### Terminal >
``` shell

C:\Demo> app.exe --file "demo.txt"
C:\Demo> demo.txt

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
