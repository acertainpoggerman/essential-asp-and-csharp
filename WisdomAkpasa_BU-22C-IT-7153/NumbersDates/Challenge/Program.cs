// See https://aka.ms/new-console-template for more information

bool running = true;
DateOnly comparisonDate, today;
int dayDifferenceToNow;

string inputDate;

string[] dateFormatList = { "dd", "MM", "yyyy" };
string dateFormatDisplay = String.Join(' ', dateFormatList.Select(s => s.ToUpper()));

while (running)
{
    Console.Write(
        $"Enter Date in the Format - {dateFormatDisplay.Replace(' ', '/')} or {dateFormatDisplay.Replace(' ', '-')} (or type 'exit' to close the app): "
    );

    #pragma warning disable CS8602 // Dereference of a possibly null reference.
        inputDate = Console.ReadLine().Trim();
    #pragma warning restore CS8602 // Dereference of a possibly null reference.

    // Exit Program?
    if (inputDate.ToUpper() == "EXIT") {
        running = false;
        break;
    }
    
    inputDate = inputDate.Replace("-", "/");
    
    if (!DateOnly.TryParseExact(inputDate, $"{String.Join('/', dateFormatList)}", out comparisonDate)) {
        Console.WriteLine($"({inputDate}) is not a valid date in the format {dateFormatDisplay.Replace(' ', '/')} or {dateFormatDisplay.Replace(' ', '-')}\n");
        continue;
    }
    today = DateOnly.FromDateTime(DateTime.Today);
    
    // Comparisons
    dayDifferenceToNow = comparisonDate.DayNumber - today.DayNumber;
    if (dayDifferenceToNow > 0)
    {
        if (dayDifferenceToNow == 1) Console.WriteLine($"1 Day remains until {inputDate}");
        else Console.WriteLine($"{dayDifferenceToNow:N0} Days remain until {inputDate}");
    }
    else if (dayDifferenceToNow < 0)
    {
        dayDifferenceToNow = Math.Abs(dayDifferenceToNow);
        if (dayDifferenceToNow == 1) Console.WriteLine($"1 Day has passed since {inputDate}");
        else Console.WriteLine($"{dayDifferenceToNow:N0} Days have passed since {inputDate}");
    }
    else
        Console.WriteLine($"0 Days remain until {inputDate}, The date {inputDate} is today!");
    
    // FOR: Console Readability
    Console.WriteLine();
}

Console.WriteLine();