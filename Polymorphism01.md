### Program.cs
```cs
var cars = new List<Car>
{
    new Audi("A4", 200,"Red"),
    new BMW("X6", 400,"White"),
    new Audi("Q8", 600, "Black")
};
foreach (var car in cars)
{
    car.Repair();
    car.ShowDetails();
}
//When you want to access new void, use given class
BMW bmw = new BMW("M3", 450, "Blue");
bmw.ShowDetails();
```
### Car.cs
```cs
namespace exercise01
{
    class Car
    {
        public int Hp { get; set; }
        public string Color { get; set; }
        public Car(int hp, string color) 
        {
            this.Hp = hp;
            this.Color = color;  
        }
        //you have to use virtual to be able to override the method
        public virtual void ShowDetails()
        {
            Console.WriteLine("Horsepower: {0}, Color: {1}", Hp, Color);
        }
        public virtual void Repair()
        {
            Console.WriteLine("Car was repaired");
        }
    }
}
```
### BMW.cs
```cs
namespace exercise01
{
    class BMW : Car
    {
        protected string Brand = "BMW";
        protected string Model {  get; set; }
        public BMW(string color, int hp, string model) :base(hp, color)
        {
            this.Model = model;
        }
        //new void has priority over base class (Car).
        public new void ShowDetails()
        {
            Console.WriteLine("This is {0} {1}. Horsepower: {2}, Color: {3}", Brand, Model, Hp, Color);
        }
        public override void Repair()
        {
            Console.WriteLine("{0} was repaired", Brand);
        }
    }
}
```
### Audi.cs
```cs
namespace exercise01
{
    class Audi : Car
    {
        private string Brand = "Audi";
        public string Model { get; set; }
        public Audi(string color, int hp, string model) : base(hp, color)
        {
            this.Model = model;
        }
        public override void ShowDetails()
        {
            Console.WriteLine("This is {0} {1}. Horsepower: {2}, Color: {3}", Brand, Model, Hp, Color);
        }
        public override void Repair()
        {
            Console.WriteLine("{0} was repaired", Brand);
        }
    }
}
```
