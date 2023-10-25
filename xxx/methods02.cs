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

            DisplayResult(ReverseString(firstName),
            ReverseString(lastName),
            ReverseString(city));

        }
        private static string ReverseString(string message)
        {
            char[] messageArray = message.ToCharArray();
            Array.Reverse(messageArray);
            return String.Concat(messageArray);
        }
        private static void DisplayResult(string reversedFirstName, string reversedLastName, string reversedCity) 
        {
            Console.Write(String.Format("{0} {1} {2}",
                    reversedFirstName,
                    reversedLastName,
                    reversedCity));
        }
    }
}
