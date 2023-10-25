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
//////////////////
namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What's your first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("What's your last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("In what city you were born");
            string city = Console.ReadLine();


            Console.Write("Results: ");
            string reversedFirstName = ReverseString(firstName);
            string reversedLastName = ReverseString(lastName);
            string reversedCity = ReverseString(city);

            Console.Write(String.Format("{0} {1} {2}", 
                reversedFirstName, 
                reversedLastName, 
                reversedCity));
        }
        private static string ReverseString(string message)
        {
            char[] messageArray = message.ToCharArray();
            Array.Reverse(messageArray);
            return String.Concat(messageArray);
        }
    }
}
