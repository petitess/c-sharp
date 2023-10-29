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
2. Make a method that prints a names with reversed characters
```
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
3. c
