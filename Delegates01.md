### Program.cs
```cs
namespace exercise01
{
    public class Program
    {
        public delegate bool FilterDelegate(Person p);
        static void Main(string[] args)
        {
            Person p1 = new Person() { Name = "Aiden", Age = 41 };
            Person p2 = new Person() { Name = "Sif", Age = 69 };
            Person p3 = new Person() { Name = "Walter", Age = 23 };
            Person p4 = new Person() { Name = "Anatoil", Age = 31 };
            Person p5 = new Person() { Name = "Anton", Age = 10 };
            List<Person> people = new List<Person>() { p1, p2, p3, p4, p5 };

            DisplayPeople("Kids", people, IsMinor);
            DisplayPeople("Adults", people, IsAdult);
            DisplayPeople("Seniors", people, IsSenior);
            //Anonymous method 1
            FilterDelegate filter = delegate (Person person)
            {
                return person.Age >= 20 && person.Age <= 30;
            };
            DisplayPeople("Young adults", people, filter);
            //Anonymous method 2
            DisplayPeople("All", people, delegate (Person p) { return true;  });
        }
        static void DisplayPeople(string title, List<Person> person, FilterDelegate filter)
        {
            Console.WriteLine(title);

            foreach (Person p in person)
            {
                if (filter(p))
                {
                    Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
                }
            }
        }
        //filters
        static bool IsMinor(Person p)
        {
            return p.Age < 18;
        }
        static bool IsAdult(Person p)
        {
            return p.Age >= 18;
        }
        static bool IsSenior(Person p)
        {
            return p.Age > 65;
        }
    }
}
```
### Person.cs
```cs
namespace exercise01
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
```
