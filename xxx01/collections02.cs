namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car volvo = new Car();
            volvo.Make = "Volvo";
            volvo.Model = "XC90";

            Car bmw = new Car();
            bmw.Make = "BMW";
            bmw.Model = "X6";

            Book book = new Book();
            book.Titel = "Total recall";
            book.Author = "Schwarzenegger";
            book.ISBN = "123-123-123";

            //List<T> - Generic type
            List<Car> array = new List<Car>();
            array.Add(volvo);
            array.Add(bmw);

            foreach (Car car in array)
            {
                Console.WriteLine(car.Model);
            }

            Console.ReadLine();
        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
    }

    class Book 
    {
        public string Titel { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
