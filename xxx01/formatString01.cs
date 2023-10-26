namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string myString = "My \"so-called\" Life";
            Console.WriteLine(myString);

            string newLine = "The first line. \nThe second line.";
            Console.WriteLine(newLine);

            string path = "Go to c:\\temp\\driver";
            Console.WriteLine(path);

            string path2 = @"Go to c:\temp\driver";
            Console.WriteLine(path2);

            string format = String.Format("{0} = {1}", "First", "Second");
            Console.WriteLine(format);

            string format2 = String.Format("{0:C}", 123.45);
            Console.WriteLine(format2);

            string format3 = String.Format("{0:N}", 123456789);
            Console.WriteLine(format3);

            string format4 = String.Format("{0:P}", .125);
            Console.WriteLine(format4);

            string format5 = String.Format("Phone Number: {0:(###) ###-####}", 1234567890);
            Console.WriteLine(format5);

            string lyric = " That summer we took threes across the board ";
            lyric = lyric.Substring(6,18);
            Console.WriteLine(lyric);
            lyric = lyric.ToUpper();
            Console.WriteLine(lyric);
            lyric = lyric.Replace(" ", "-");
            Console.WriteLine(lyric);
            lyric = lyric.Remove(2, 8);
            Console.WriteLine(lyric);

            string lyric2 = " When I met you in the summer. To my heartbeat's sound. We fell in love. As the leaves turned brown ";
            lyric2 = String.Format("Length befor: {0} -- Length after: {1}", 
                lyric2.Length, 
                lyric2.Trim().Length);
            Console.WriteLine(lyric2);

            string concat = "";
            for (int i = 0; i < 100; i++)
            {
                concat += "--" + i.ToString();
            }
            Console.WriteLine(concat);

            StringBuilder stringx = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                stringx.Append("-");
                stringx.Append(i);
            }
            Console.WriteLine(stringx);
        }
    }
}
