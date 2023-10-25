namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MainMenu();
        }

        private static void MainMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Option 1");
            Console.WriteLine("2) Option 2");
            Console.WriteLine("3) Exit");
            string results = Console.ReadLine();
            if(results == "1")
            {
                PrintNumbers();
            }
            else if (results == "2")
            {
                GuessingGame();
            }
            else if (results == "3")
            {

            }
        }

        private static void PrintNumbers()
        {
            Console.WriteLine("Print numbers!");
        }

        private static void GuessingGame() 
        {
            Console.WriteLine("Guessing game!");
        }


    }
}
