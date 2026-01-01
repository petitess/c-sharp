namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += Timer_Elapsed;
            timer.Elapsed += Timer_Elapsed1;
            timer.Start();
            Console.WriteLine("Press enter to remove green event");
            Console.ReadLine();
            timer.Elapsed -= Timer_Elapsed1;
            Console.ReadLine() ;    
        }
        private static void Timer_Elapsed1(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elapsed1: {0:HH:mm:ss.ffff}", e.SignalTime);
        }
        private static void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Elapsed: {0:HH:mm:ss.ffff}", e.SignalTime);
        }
    }
}
