//Program.cs
Car audi = new Car("Audi", "400", "black");
audi.Drive();
audi.Stop();
audi.Info();
//Car.cs
namespace exercise01
{
    internal class Car
    {
        //Member variable/private filed
        private string _name; 
        private string _hp;
        private string _color;
        public Car(string name,string hp, string color) 
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
