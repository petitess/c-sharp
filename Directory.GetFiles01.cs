string path = "D:\\MUZ";
string[] files = Directory.GetFiles(path);
foreach (string file in files)
Console.WriteLine(file.Replace(path + "\\", ""));
