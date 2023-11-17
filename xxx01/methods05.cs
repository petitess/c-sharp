//Program.cs
Car audi = new Car("Audi");
audi.Drive();
audi.Stop();
//Car.cs
  namespace exercise01
{
    internal class Car
    {
        private string _name; 
        public Car(string name) 
        {
            _name = name;
            Console.WriteLine(name + " was created");
        }
        public void Drive()
        {
            Console.WriteLine(_name + " is driving");
        }
        public void Stop() 
        {
            Console.WriteLine(_name + " stopped");
        }
    }
}
////////////
