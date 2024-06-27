// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text.RegularExpressions;

bool running = true;

while (running)
{
    Console.Write("Enter a Date in the Format (MM/DD/YYYY):");
    string? input = Console.ReadLine();
    if (input != null) {
        if (DateOnly.TryParse(input,out var date))
            Console.WriteLine($"Reversed Date: {ReverseDateFormat(input)}\n");
        else
            Console.WriteLine($"Date provided is invalid\n");
    }
}

string ReverseDateFormat(string dateString)
{
    TimeSpan Timeout = TimeSpan.FromSeconds(1);
    
    Stopwatch sw = Stopwatch.StartNew();
    Regex DateMatch = new(@"(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})", RegexOptions.None, Timeout);
    Match match = DateMatch.Match(dateString);
    sw.Stop();


    string month = match.Result("${month}");
    string day = match.Result("${day}");
    string year = match.Result("${year}");

    return $"{year}-{day}-{month}";
}
