1. Make a method that prints a choosen string.
```cs
string text = "I like roses";
GetText(text);

static string GetText(string xxx)
{
    Console.WriteLine(xxx);
    return xxx;
}
```
2. Make a method that prints a name with reversed characters
```cs
Console.WriteLine("Whats your name?");
string? answer = Console.ReadLine();
if (answer != null)
ReversedName(answer);

static string ReversedName(string name)
{
    char[] array = name.ToCharArray();
    Array.Reverse(array);
    if (array.Length > 0)
    {
        Console.WriteLine(array);
        return String.Concat(array);
    }
    Console.WriteLine("No name provided");
    return String.Concat(array);
}
```
3. Make a method that sums an array of integers using `foreach`
```cs
static void Main(string[] args)
{
    int[] myNumbers = new int[] { 10, 15, 20, 25, 30, 12, 34 };
    GetSum(myNumbers);
;        }
static private int GetSum(int[] number)
{
    int totalValue = 0;
    foreach (int nr in number) 
    {
        totalValue += nr;
    }
    Console.WriteLine(totalValue);
    return totalValue;
}   
```
4. Make a method that sums an array of integers using `.Sum`
```cs
int[] myNumbers = new int[] {4,7,23,9,3};
GetSum(myNumbers);

static int GetSum(int[] numbers)
{
    Console.WriteLine(numbers.Sum());
    return numbers.Sum();
}
```
5. Make a method that prints even numbers
```cs
int[] myNumbers = new int[] {4, 6, 7, 23,9,3,66,10};
foreach (int i in myNumbers)
    GetEven(i);

static int GetEven(int numbers)
{
    if (numbers % 2 == 0)
    {
        Console.WriteLine(numbers);
        return numbers;
    }
    return numbers;
}
```
