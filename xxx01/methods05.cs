//Program.cs
Car audi = new Car("Audi", 400, "black");
audi.Drive();
audi.Stop();
audi.Info();
Car car = new Car();
car.Info();
//Car.cs
namespace exercise01
{
    internal class Car
    {
        //Member variable/private filed
        private string _name; 
        private int _hp;
        private string _color;

        //Constractor nr1
        public Car() 
        {
            _name = "Car";
            _hp = 0;
            _color = "red";
        }
        //Constractor nr2
        public Car(string name,int hp = 0, string color = "black") 
        {
            _name = name;
            _hp = hp;
            _color = color;
            Console.WriteLine(name + " was created");
        }
        //Member method
        public void Drive()
        {
            Console.WriteLine(_name + " is driving");
        }
        public void Stop() 
        {
            Console.WriteLine(_name + " stopped");
        }
        public void Info()
        {
            Console.WriteLine(_name + " has " + _hp + " horsepower and is " + _color);
        }
    }
}
////////////
