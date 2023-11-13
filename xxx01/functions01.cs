///contains, indexof
Console.WriteLine("Enter a string here:");
string? result = Console.ReadLine();

Console.WriteLine("Enter the character to search:");
char search = char.Parse(Console.ReadLine());

if (result.Contains(search))
{
    Console.WriteLine("Your string contains " + search);
    Console.WriteLine("The index of " + search + " is " + result.IndexOf(search));
}
else
{
    Console.WriteLine("Your string doesn't contain " + search);
}
///
