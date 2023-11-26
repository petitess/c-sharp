### Program.cs
```cs
Car slowCar = new Car("Nissan", "Navara", 2015);
slowCar.Color = "White";
slowCar.Hp = 250;
slowCar.Drive();
slowCar.ShowDetails();

BMW bmw = new BMW("BMW", "X6", 2022);
bmw.Color = "Black";
bmw.Hp = 500;
bmw.Drive();
bmw.ShowDetails();
```
### Car.cs
```cs
namespace exercise01
{
    internal class Car
    {
        public string Maker { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Hp { get; set; }
        public string Color { get; set; }
        public Car(string maker, string model, int year) 
        {
            Maker = maker;
            Model = model;
            Year = year;
        }    
        public virtual void Drive()
        {
            Console.WriteLine("{0} {1} is going slowly", Maker, Model);
        }
        public void ShowDetails()
        {
            Console.WriteLine("HP: {0}, Color: {1}", Hp, Color);
        }
    }
}
```
### BMW.cs
```cs
namespace exercise01
{
    internal class BMW : Car
    {
        public BMW(string maker, string model, int year):base(maker, model, year) 
        {
        }
        public override void Drive()
        {
            Console.WriteLine("{0} {1} is going fast", Maker, Model);
        }
    }
}
```
