using System;

namespace Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bob´s big giveaway");
            Console.WriteLine("Choose a door: 1, 2 or 3: ");
            string userValue = Console.ReadLine();

            string message = "";

            if (userValue == "1")
                message = "You won a new car";
            else if (userValue == "2")
                message = "You won a new boat";
            else if (userValue == "3")
                message = "You won a new cat";
            else
            {
                message = "Sorry, we didn´t understand. ";
                message = message + "You lose";
            }

            Console.WriteLine(message);
        }
    }
}
