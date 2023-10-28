namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car volvo = new Car();
            volvo.Make = "Volvo";
            volvo.Model = "XC90";
            volvo.VIN = "ABC123";

            Car bmw = new Car();
            bmw.Make = "BMW";
            bmw.Model = "X6";
            bmw.VIN = "ZXC987";

            Book book = new Book();
            book.Titel = "Total recall";
            book.Author = "Schwarzenegger";
            book.ISBN = "123-123-123";

            //Dictionary<TKey, TValue>
            Dictionary<string, Car> array = new Dictionary<string, Car>();
            array.Add(volvo.VIN, volvo);
            array.Add(bmw.VIN, bmw);

            Console.WriteLine(array["ABC123"].Model);

            Console.ReadLine();
        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
    }

    class Book 
    {
        public string Titel { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
