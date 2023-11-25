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
//Polymorphism
IEnumerable<string> text = File.ReadLines(@"D:\INPUT.txt");
string phrase = "";
foreach (string line in text)
{
    if (line.Contains("split"))
    {
        //Console.WriteLine(line);
        string[] subs = line.Split();
        File.WriteAllText(@"D:\output.txt", subs[4]);
        phrase = phrase + " " + subs[4];
        Console.WriteLine(phrase);
    }
}
//
