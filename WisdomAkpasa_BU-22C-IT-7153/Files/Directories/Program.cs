// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Creating and Deleting Directories

const string dirname = "TestDir";

// TODO: Create a Directory if it doesn't already exist
if (!Directory.Exists(dirname))
    Directory.CreateDirectory(dirname);
else
    Directory.Delete(dirname);

// TODO: Get the path for the current directory
string currentPath = Directory.GetCurrentDirectory();
Console.WriteLine($"Current Directory is {currentPath}");

// TODO: Just like with files, you can retrieve info about a directory
DirectoryInfo dirInfo = new(currentPath);
Console.WriteLine($"{dirInfo.Name}");
Console.WriteLine($"{dirInfo.Parent}");
Console.WriteLine($"{dirInfo.CreationTime}");
Console.WriteLine("-----------------------");

// TODO: Enumerate the contents of directories
Console.WriteLine("Just directories:");
List<string> directories = new(Directory.EnumerateDirectories(currentPath));
foreach (string dir in directories)
    Console.WriteLine(dir);

Console.WriteLine("---------------");

Console.WriteLine("Just files:");
List<string> files = new(Directory.EnumerateFiles(currentPath));
foreach (string file in files)
    Console.WriteLine(file);
    
Console.WriteLine("---------------");

Console.WriteLine("All directory contents:");
List<string> allContents = new(Directory.EnumerateFileSystemEntries(currentPath));
foreach (string content in allContents)
    Console.WriteLine(content);