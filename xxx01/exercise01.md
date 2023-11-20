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
int[] myNumbers = new int[] {5,8,1,7,45};
GetSum(myNumbers); 

int GetSum(int[] numbers)
{
    int totalValue = 0;
    foreach (int number in numbers)
    {
        totalValue += number;
    }
    Console.WriteLine(totalValue);
    return totalValue;
} 
```
4. Make a method that sums an array of integers using `.Sum`
```cs
int[] myNumbers = new int[] {5,8,1,7,45};
Console.WriteLine(myNumbers.Sum());
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
6. Calculate Average Age
```cs
int[] age = new int[] { 8, 44, 22, 37, 21, 44, 88 };

int sum = age.Sum();
int amount = age.Count();

Console.WriteLine("The average ages is: " + sum / amount);
```
```cs
int[] xxx = new int[] {4,3,6,77};
GetNr(xxx);
double GetNr(int[] ints)
{  
   double totalValue = 0;
       foreach (int x in ints)
    {
        totalValue += x;
    }
    Console.WriteLine(totalValue / ints.Length);
    return totalValue;
}
```
7. Print a range of numbers using Enumerable
```cs
static List<int> Solution() 
{
    int[] list;
    list = Enumerable.Range(100, 71).ToArray();
    foreach (int i in list)
    {
        Console.WriteLine(i);
    }
    return list.ToList();
}
```
9. Add a range of numbers to a List using for loop
```cs
static List<int> Solution2()
{
    List<int> myList = new List<int>();
    for (int i = 100; i <= 170; i++) 
    {
        if (i % 2 == 0) 
        {
            myList.Add(i);
            Console.WriteLine(i);
        }
    }
    return myList;
}
```
10. Check if an integer exists in Dictionary
```cs
public static string Convert(int i)
{
    Dictionary<int, string> empDict = new Dictionary<int, string>()
    {
        {0, "zero" },
        {1, "one" },
        {2, "two"},
        {3, "three" },
        {4, "four"},
        {5, "five" }
    };
    if (empDict.ContainsKey(i))
        return empDict[i];
    else
        return "nope";
}
```
