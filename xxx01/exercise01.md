1. Make a method that prints a choosen string.
```cs
static void Main(string[] args)
{
    string myText = "Hej Sverige";
    GetText(myText);
}
static private string GetText(string text)
{
    Console.WriteLine(text);
    return text;
}  
```
2. Make a method that prints a name with reversed characters
```cs
static void Main(string[] args)
{
    Console.WriteLine("what's your name");
    string name = Console.ReadLine();
    ReverseText(name);
}
static private string ReverseText(string name)
{
   char[] namex = name.ToCharArray();
   Array.Reverse(namex);
   Console.WriteLine(namex);
   return String.Concat(namex);
}

```
3. Make a method that sums an array of integers
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
