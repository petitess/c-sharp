```cs
DateTime dataTime = new DateTime(2018, 5, 20);
Console.WriteLine(dataTime);
Console.WriteLine(DateTime.Today);
Console.WriteLine(DateTime.Now);
Console.WriteLine(DateTime.Today.DayOfWeek);
DateTime tomorrow = GetTomorrow();
Console.WriteLine(tomorrow);
Console.WriteLine(GetTomorrow());
Console.WriteLine(DayofWeekTomorrow());
Console.WriteLine(GetFirstDayofYear(1999));
Console.WriteLine(GetFirstDayofYear2(1999));
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
