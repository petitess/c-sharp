string path = "D:\\MUZ";
string[] files = Directory.GetFiles(path);
foreach (string file in files)
{
    FileInfo fileInfo = new FileInfo(file);
    fileInfo.Delete();
}
