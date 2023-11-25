### Program 
```cs
Day fr = Day.Fr;

Console.WriteLine(fr);
Console.WriteLine((int)Day.Fr);

Console.WriteLine(Month.January);
Console.WriteLine((int)Month.January);
Console.WriteLine(Month.February);
Console.WriteLine((int)Month.February);
```
### Enum
```cs
namespace exercise01
{
    enum Day { Mo, Tu, We, Th, Fr, Sa, Su };
    enum Month { January = 1, February, March, April, May, June, July, August, September, October, November, December };
}
```
