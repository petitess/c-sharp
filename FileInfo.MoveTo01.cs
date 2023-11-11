string path = "D:\\MUZ";
string[] files = Directory.GetFiles(path);
int nr = 1;
foreach (string file in files)
{
    FileInfo fileInfo = new FileInfo(file);
    fileInfo.MoveTo(path + "\\" + nr++ + "." + fileInfo.Name);
}
////Number with leading eros
string path = "D:\\MUZ";
string[] files = Directory.GetFiles(path);
int nr = 1;
foreach (string file in files)
{
    FileInfo fileInfo = new FileInfo(file);
    fileInfo.MoveTo(path + "\\" + nr++.ToString("D3") + "." + fileInfo.Name);
}
