namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Car mini = new Car();
            mini.Make = "Mini";
            mini.Model = "Cooper";
            mini.Year = 2020;
            mini.Color = "Red";

            Console.WriteLine("{0} {1} {2} {3}", 
                mini.Make, 
                mini.Model, 
                mini.Year, 
                mini.Color);

            Console.WriteLine("{0:C}", mini.MarketValue());
        }
    }
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal MarketValue()
        {
            decimal value;
            if (Year > 2000)
            {
                value = 100000;
            }
            else
            {
                value = 20000;
            }
            return value;
        }
    }
}
