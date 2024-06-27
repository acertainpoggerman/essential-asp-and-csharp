// See https://aka.ms/new-console-template for more information

void DoSomeBigOperation() {
    byte[] myArray = new byte[1_000_000];
    
    Console.WriteLine($"Allocated memory : {GC.GetTotalMemory(false)}");
    Console.ReadLine();
}

// Checking Memory before adding a Million Bytes
Console.WriteLine($"Allocated Memory is : {GC.GetTotalMemory(false)}");
Console.ReadLine();

DoSomeBigOperation(); // Allocating a Million Bytes to memory in a function
GC.Collect(); // Remove hanging memory

// Checking Memory after Garbage Collection
Console.WriteLine($"Allocated Memory is : {GC.GetTotalMemory(false)}");
Console.ReadLine();



