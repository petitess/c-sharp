using System;

namespace Variables // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Whats your name?");
            Console.WriteLine("Type your first name: ");
            string myFirstName;
            myFirstName = Console.ReadLine();

            string myLastName;
            Console.Write("Type your last name: ");
            myLastName = Console.ReadLine();

            Console.WriteLine("Hi, " + myFirstName + " " + myLastName);
        }
    }
}

///////
///////
