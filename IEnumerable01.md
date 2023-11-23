IEnumerable Interface is recommended to be used when your collection represents a massive databese table.

Types of IEnumerable:
1. IEnumerable `<T>` for generic collection > This one should be used
2. IEnumerable for non generic collection

### Program.cs
```cs
using exercise01;

DogShelter shelter  = new DogShelter();
foreach (Dog dog in shelter)
{
    if (!dog.IsNaughtyDog)
    {
        dog.GiveTreat(2);
    }
    else
    {
        dog.GiveTreat(1);
    }
}
```
### Dog.cs
```cs
namespace exercise01
{
    internal class Dog
    {
        public string Name { get; set; }
        public bool IsNaughtyDog { get; set; }
        public Dog(string name, bool isNaughtyDog) 
        {
            Name = name;
            IsNaughtyDog = isNaughtyDog;
        }

        public void GiveTreat(int numberOfTreats)
        {
            Console.WriteLine("Dog: {0} said wuff {1} times!", Name, numberOfTreats);
        }   
    }
}
```
### DogShelter.cs
```cs
namespace exercise01
{
    internal class DogShelter : IEnumerable<Dog>
    {
        public List<Dog> dogs;

        public DogShelter()
        {
            dogs = new List<Dog>()
            {
                new Dog("Casper", false),
                new Dog("Sif", true),
                new Dog("Philip", false),
                new Dog("Oreo", true),
                new Dog("Dix", true)
            };
        }
        IEnumerator<Dog> IEnumerable<Dog>.GetEnumerator()
        {
            return dogs.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
```
