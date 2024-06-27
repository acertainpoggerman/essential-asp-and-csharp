// Application Programming .NET Programming with C# by Abdullahi Tijjani
// Working with file information

// Make sure the example file exists
const string filename = "TestFile.txt";

if (!File.Exists(filename)) {
    using StreamWriter sw = File.CreateText(filename);
    sw.WriteLine("This is a text file.");
}

// // TODO: Get some information about the file
Console.WriteLine($"File '{filename}' created at {File.GetCreationTime(filename)}");
Console.WriteLine($"File '{filename}' last written at {File.GetLastWriteTime(filename)}");
Console.WriteLine($"File '{filename}' last accessed at {File.GetLastAccessTime(filename)}");

File.SetAttributes(filename, FileAttributes.ReadOnly);

Console.WriteLine($"File '{filename}' attributes: {File.GetAttributes(filename)}");


// TODO: We can also get general information using a FileInfo 
try
{
    FileInfo fileInfo = new(filename);
    Console.WriteLine($"Length of {fileInfo.Length}");
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e}");
}


// TODO: File information can also be manipulated
DateTime dateTime = DateTime.Now;
File.SetCreationTime(filename, dateTime);
Console.WriteLine($"File '{filename}' created at {File.GetCreationTime(filename)}");
