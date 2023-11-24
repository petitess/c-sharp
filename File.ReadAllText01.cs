string text = File.ReadAllText(@"D:\text.txt");
//Show content v1
Console.WriteLine("The content of the file:\n" + text);
//Show content v2
string[] lines = File.ReadAllLines(@"D:\text.txt");
Console.WriteLine("The content of the file:\n");
foreach (string line in lines)
{
    Console.WriteLine("\t" + line);
}
