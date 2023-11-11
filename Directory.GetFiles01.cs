string path = "D:\\MUZ";
string[] files = Directory.GetFiles(path);
foreach (string file in files)
Console.WriteLine(file.Replace(path + "\\", ""));
///////
string path = "D:\\MUZ";
string[] files = Directory.GetFiles(path);
foreach (string file in files)
{
    FileInfo fileInfo = new FileInfo(file);
    Console.WriteLine(fileInfo.Name);
}
