### Program.cs
```cs
Dog myDog = new Dog("Sif", 15);
Console.WriteLine($"{myDog.Name} is {myDog.Age} years old");
myDog.MakeSound();
myDog.Play();
myDog.Eat();
```
### Animal.cs
```cs
namespace exercise01
{
    internal class Animal
    {
        public string Name {  get; set; }
        public int Age { get; set; }
        public bool IsHungry { get; set; }
        public Animal(string name, int age) 
        {
            Name = name;
            Age = age;
            IsHungry = true;
        } 
        public virtual void MakeSound() {}
        public virtual void Eat()
        {
            if (IsHungry)
            {
                Console.WriteLine($"{Name} is eating");
            }else
            {
                Console.WriteLine($"{Name} is not hungry");
            }
        }
        public virtual void Play()
        {
            Console.WriteLine($"{Name} is playing");
        }
    }
}
```
### Dog.cs
```cs
namespace exercise01
{
    internal class Dog : Animal
    {
        public bool IsHappy { get; set; }
        public Dog(string name, int age) : base(name, age) 
        {
            IsHappy = true;
        }
        public override void Eat()
        {
            base.Eat();
        }
        public override void MakeSound()
        {
            Console.WriteLine("Wuuf");
        }
        public override void Play()
        {
            if (IsHappy)
            {
                base.Play();
            }
        }
    }
}
```
