// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Example file for .NET Data Types

// Declare some types with values
int a = 1;
char c = 'A';
float f = 123.45f;
decimal d = 400.85m;
int b = default;
bool tf = default;

Console.WriteLine($"{a}, {b}, {tf}, {c}, {f}, {d}");

// TODO: implicit type conversion
Console.WriteLine($"{a + c}");
Console.WriteLine($"{(char)(a + c)}");

Console.WriteLine($"{a + f}");
Console.WriteLine($"{(int)(a + f)}");
Console.WriteLine($"{f + c}");

// TODO: Create an instance of a struct (which is a value type)
s aCertainStruct; // Name it whatever you want
aCertainStruct.a = 12;
aCertainStruct.b = false;

// Perform an operation on a struct
void StructOp(s theStruct) {
    // Modify the struct properties inside the function
    theStruct.a = 100;
    theStruct.b = true;
    Console.WriteLine($"{aCertainStruct.a}, {aCertainStruct.b}");
}

Console.WriteLine("Structs are passed by copy, since they are value types:");
Console.WriteLine($"{aCertainStruct.a}, {aCertainStruct.b}");
StructOp(aCertainStruct);
Console.WriteLine($"{aCertainStruct.a}, {aCertainStruct.b}");

// TODO: Create an object instance of a class (which is a reference type)
MyClass aCertainClass = new MyClass(); // Name it whatever you want
aCertainClass.a = 100;
aCertainClass.b = false;

// Perform an operation on the class
void ClassOp(MyClass theClass) {
    // Modify some of the properties of the class inside the function
    theClass.a = 10;
    theClass.b = true;
    Console.WriteLine($"{theClass.a}, {theClass.b}");
}

Console.WriteLine("\nObjects are passed by reference, since they are reference types:");
Console.WriteLine($"{aCertainClass.a}, {aCertainClass.b}");
ClassOp(aCertainClass);
Console.WriteLine($"{aCertainClass.a}, {aCertainClass.b}");

// These are declared at the bottom of the file because C# requires
// top-level statements to come before type declarations
class MyClass {
    public int a;
    public bool b;
}

struct s {
    public int a;
    public bool b;
}
