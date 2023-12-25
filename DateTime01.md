```cs
DateTime.Now.ToString("dd/MM/yyyy HH:mm");
DateTime dateTime = new DateTime(2018, 5, 20);
Console.WriteLine(dateTime);
Console.WriteLine(DateTime.Today);
Console.WriteLine(DateTime.Now);
Console.WriteLine(DateTime.Today.DayOfWeek);

Console.WriteLine(GetTomorrow());
Console.WriteLine(DayofWeekTomorrow());
Console.WriteLine(GetFirstDayofYear(1999));
Console.WriteLine(GetFirstDayofYear2(1999));

Console.WriteLine("Write a date in this format: yyyy-mm-dd");
DateTime now = DateTime.Today;
string? date = Console.ReadLine();
if (DateTime.TryParse(date, out dateTime))
{
    TimeSpan daysPassed = now.Subtract(dateTime);
    Console.WriteLine(daysPassed.Days + " days passed");
}
DateTime GetTomorrow()
{
    return DateTime.Now.AddDays(1);
}
DayOfWeek DayofWeekTomorrow()
{
    return DateTime.Now.AddDays(1).DayOfWeek;
}
DateTime GetFirstDayofYear(int year)
{
    return new DateTime(year, 1, 1);
}
DayOfWeek GetFirstDayofYear2(int year)
{
    return new DateTime(year, 1, 1).DayOfWeek;
}
```
```cs
DateTime time = DateTime.Now;
string timeStamp = time.AddHours(1).ToString("dd/MM/yyyy HH:mm");
```
