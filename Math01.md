### Functions
```cs
Console.WriteLine(Math.Ceiling(15.4));
Console.WriteLine(Math.Floor(15.4));
Console.WriteLine(Math.PI);
int num1 = 13;
int num2 = 5;
Console.WriteLine(Math.Min(num1, num2));
Console.WriteLine(Math.Max(num1, num2));
Console.WriteLine(Math.Pow(3,5));
Console.WriteLine(Math.Sqrt(25));
Console.WriteLine(Math.Abs(-25));
Console.WriteLine(Math.Cos(1));
```
### Program.cs
```cs
Console.WriteLine("Type a number");
string? x = Console.ReadLine();
int xToInt;
bool success = int.TryParse(x, out xToInt);
if (success && xToInt >= 0 && xToInt <= 180)
{
    //Math.Cos(xToInt);
    Console.WriteLine("Cos = " + Math.Cos(xToInt));
    //Math.Sin(xToInt);
    Console.WriteLine("Sin = " + Math.Sin(xToInt));
    //Math.Tan(xToInt);
    Console.WriteLine("Tg = " + Math.Tan(xToInt));
}
else
{
    Console.WriteLine("Check the input!");
    return;
}
```
