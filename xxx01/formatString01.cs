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

        }
    }
}
