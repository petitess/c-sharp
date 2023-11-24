//v1
string[] lines = { "Bananas", "Pineapple", "Oranges", };
File.WriteAllLines(@"D:\mytext.txt", lines);
//v2
string input = Console.ReadLine();
File.WriteAllText(@"D:\myscores.txt", input);
//v4
using (StreamWriter file = new StreamWriter(@"D:\myinput.txt"))
{
    foreach (string line in lines)
    {
        if (line.Contains("a"))
        {
            file.WriteLine(line);
        }
    }
}
//append new line
using (StreamWriter file = new StreamWriter(@"D:\myinput.txt", true))
{
    file.WriteLine("Lime");
}
