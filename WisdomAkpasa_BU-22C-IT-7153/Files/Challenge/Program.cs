// See https://aka.ms/new-console-template for more information

string resultsFileName = "results.txt";
string folderName = "FileCollection";

// Dictionary to hold file type information
Dictionary<string, Dictionary<string, long>> fileTypeTracker = new() {
    { ".docx", new(){ {"count", 0}, {"size", 0} } } ,
    { ".pptx", new(){ {"count", 0}, {"size", 0} } } ,
    { ".xlsx", new(){ {"count", 0}, {"size", 0} } } ,
};


int totalCount = 0;
long totalSize = 0;

// To Enumerate through all the folders in the specified directory
DirectoryInfo folder = new(folderName);
List<string> files = new(Directory.EnumerateFiles(folder.FullName));

foreach (string file in files)
{
    FileInfo fileInfo = new(file);
    if (fileTypeTracker.ContainsKey(fileInfo.Extension)) {
        fileTypeTracker[fileInfo.Extension]["count"]++;
        fileTypeTracker[fileInfo.Extension]["size"] += fileInfo.Length;
        
        totalCount++;
        totalSize += fileInfo.Length;
    }
}

// Forming the text to put in the "results.txt" file
const int columnSize = 18;
string hr = new('-', Math.Abs(columnSize) * 3);
string resultText = "\nSUMMARY\n\n";

resultText += $"{"File Type",-columnSize}{"Count",-columnSize}{"Size",columnSize}\n";
resultText += $"{hr}\n";

foreach (KeyValuePair<string, Dictionary<string, long>> fileType in fileTypeTracker) {
    resultText += $"{fileType.Key,-columnSize}{$"{fileType.Value["count"]} files",-columnSize}{$"{fileType.Value["size"]:N0} Bytes",columnSize}\n";
}

resultText += $"{hr}\n{"Total",-columnSize}{$"{totalCount} files",-columnSize}{$"{totalSize:N0} Bytes",columnSize}";

// Printing to Console
Console.WriteLine(resultText);
Console.WriteLine();
// Writing to the file (results.txt)
using StreamWriter sw = File.CreateText(resultsFileName);
sw.WriteLine(resultText);
sw.Close();


