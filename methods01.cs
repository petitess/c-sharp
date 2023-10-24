namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HelloWorld();
            Console.ReadLine();
        }
        private static void HelloWorld()
        { 
            Console.WriteLine("Hello world");
        }

    }
}
//////////////////
namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's your name?");
            ReverseString(Console.ReadLine());
             
            Console.WriteLine("What's your dogs name?");
            ReverseString(Console.ReadLine());
        }
        private static void ReverseString(string message)
        {
            char[] firstNameArray = message.ToCharArray();
            Array.Reverse(firstNameArray);
            foreach (char item in firstNameArray)
            {
                Console.Write(item);
            }
            Console.Write(" ");
        }

    }
}
