// See https://aka.ms/new-console-template for more information
bool running = true;
DateOnly comparisonDate, today;

string[] dateFormat = { "MM", "dd", "yyyy" };
string dateFormatDisplay = String.Join(" ", dateFormat.Select(s => s.ToUpper()));

while (running)
{
    Console.Write(
        $"Enter Date in the Format - {dateFormatDisplay.Replace(" ", "-")} or {dateFormatDisplay.Replace(" ", "/")} (or type 'exit' to close the app): "
    );

    string inputDate = Console.ReadLine().Trim();

    if (inputDate.ToLower() == "exit")
    {
        running = false;
        break;
    }

    inputDate = inputDate.Replace("-", "/");

    if (!DateOnly.TryParseExact(inputDate, String.Join("/", dateFormat), out comparisonDate))
    {
        Console.WriteLine($"({inputDate}) is not a valid date in the format {dateFormatDisplay.Replace(" ", "-")} or {dateFormatDisplay.Replace(" ", "/")}\n");
        continue;
    }
    today = DateOnly.FromDateTime(DateTime.Today);

    int dayDifferenceToNow = comparisonDate.DayNumber - today.DayNumber;
    if (dayDifferenceToNow > 0)
    {
        if (dayDifferenceToNow == 1) Console.WriteLine($"1 Day remains until {comparisonDate}");
        else Console.WriteLine($"{dayDifferenceToNow} Days have passed since {comparisonDate}");
    }
    else if (dayDifferenceToNow < 0)
    {
        if (-dayDifferenceToNow == 1) Console.WriteLine($"1 Day has passed since {comparisonDate}");
        else Console.WriteLine($"{-dayDifferenceToNow} Days have passed since {comparisonDate}");
    }
    else
    {
        Console.WriteLine($"0 Days have passed since {comparisonDate}, {comparisonDate} is Today!");
    }

    Console.WriteLine();
}

Console.WriteLine();