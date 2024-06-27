// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text.RegularExpressions;

bool running = true;

// <Start> of Main Program
while (running)
{
    Console.Write("Enter a Date in the Format (MM/DD/YYYY): ");
    string? input = Console.ReadLine();
    if (input != null)
    {
        if (input.ToUpper() == "EXIT") break;
        
        if (DateOnly.TryParse(input, out var date))
            Console.WriteLine($"Reversed Date: {ReverseDateFormat(input)}\n");
        else
            Console.WriteLine($"Date provided is invalid\n");
    }
}
Console.WriteLine();
// <End> of Main Program


// Function to reverse the date string.
string ReverseDateFormat(string dateString)
{
    TimeSpan Timeout = TimeSpan.FromSeconds(1);

    try
    {
        // The attempted matching will timeout if it exceeds the given timespan
        Stopwatch sw = Stopwatch.StartNew();
        Regex DateMatch = new(@"(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})", RegexOptions.None, Timeout);
        Match match = DateMatch.Match(dateString);
        sw.Stop();

        // Getting the Captured Groups
        string month = match.Result("${month}");
        string day = match.Result("${day}");
        string year = match.Result("${year}");

        return $"{year}-{day}-{month}";
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    
    return "";
}
