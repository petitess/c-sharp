//Program.cs
Car audi = new Car("Audi", 400, "black");
audi.Stop();
audi.Info();
Car volvo = new Car("Volvo");
volvo.Info();
//Getter, Setter
Car bmw = new Car("BMW", 500);
bmw.SetName("BMW X6");
bmw.Info();
Console.WriteLine("After chip tuning " + bmw.GetName() + " has " + bmw.GetHp() + " horsepower");
//The public property
Car vw = new Car("VW", 300, "white");
vw.Name = "Volkswagen Touareg";
vw.Info();
//Auto implemented property
vw.TopSpeed = 230;
Console.WriteLine(vw.GetName() + " Top speed is " + vw.TopSpeed + " km/h");
//ReadOnly property = get;, WriteOnly property = set;
Console.WriteLine("After chip tuning " + vw.GetName() + " Top speed is " + vw.TopSpeedAfterChipTuning + " km/h");
//Car.cs
namespace exercise01
{
    internal class Car
    {
        //Private member variable/private filed
        //Access Modifier private
        private string _name; 
        private int _hp;
        private string _color;
        private int _prise;

        //Constractor nr1
        public Car() 
        {
            _name = "Car";
            _hp = 0;
            _color = "red";
            Drive();
        }
        //Constractor nr2
        public Car(string name,int hp = 0, string color = "black") 
        {
            _name = name;
            _hp = hp;
            _color = color;
            Console.WriteLine(name + " was created");
            Drive();
        }
        //Member method
        private void Drive()
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
        //Getter
        public int GetHp()
        {
            return _hp + 50;
        }
        public string GetName()
        {
            return _name;
        }
        //Setter
        public void SetName(string name)
        {
            if (name == "")
            {
                _name = "DefaultName";
            }
            else
            {
                _name = name;
            }
        }
        //The public property
        public string Name 
        { 
            get { return _name; } //Get accessor
            set { _name = value; } //Set sccessor
        }
        //Auto implemented property
        public int TopSpeed { get; set; }
        //ReadOnly property = get;, WriteOnly property = set;
        public int TopSpeedAfterChipTuning { get; } = 280;
        public int Prise { set { _prise = value; } }
    }
}
////////////
