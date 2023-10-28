namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LINQ - helps filter, sort, etc. There is a query syntax and method syntax

            //Collection initializer
            List<Car> array = new List<Car>() {
                new Car {Make = "Toyota", Model = "Land Cruiser", VIN = "ASD456", Year = 2002, StrickerPrise = 10000 },
                new Car {Make = "Dodge", Model = "Charger", VIN = "POI098", Year = 2020, StrickerPrise = 800000 },
                new Car {Make = "Volvo", Model = "XC90", VIN = "ABC123", Year = 2023, StrickerPrise = 500000 },
                new Car {Make = "BMW", Model = "X6", VIN = "JKL345", Year = 2018, StrickerPrise = 250000},
                new Car {Make = "BMW", Model = "M3", VIN = "ZXC987", Year = 2023, StrickerPrise = 1000000},
            };

            //LINQ query syntax
            var bmw = from car in array
                      where car.Make == "BMW"
                      && car.Year > 2015
                      select car;

            var orderedCars = from car in array
                              orderby car.Year descending
                              select car;

            //LINQ method syntax
            var bmw2 = array.Where(p => p.Make == "BMW" && p.Year > 2015);

            var orderedCars2 = array.OrderByDescending(p => p.Year);

            var firstCar = array.OrderByDescending(p => p.Year).First(p => p.Make == "BMW");

            //Results
            foreach (var car in bmw)
            {
                Console.WriteLine("{0} {1}", car.Make, car.VIN);
            }

            foreach (var car in bmw2)
            {
                Console.WriteLine("{0} {1}", car.Make, car.VIN);
            }

            foreach (var car in orderedCars)
            {
                Console.WriteLine("{0} {1} {2}", car.Make, car.VIN, car.Year);
            }

            foreach (var car in orderedCars2)
            {
                Console.WriteLine("{0} {1} {2}", car.Make, car.VIN, car.Year);
            }

            Console.WriteLine("The first car is: {0} {1} {2}", firstCar.Make, firstCar.VIN, firstCar.Year);

            Console.ReadLine();
        }
    }
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public int Year { get; set; }
        public double StrickerPrise { get; set; }
    }
}
