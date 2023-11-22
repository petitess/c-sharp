Create a main class with the Main Method, then a base class Employee with the properties Name, FirstName, Salary, and the methods Work() and Pause().

Create a deriving class Boss with the property CompanyCar and the method Lead().  

Create another deriving class of employees - Trainees with the properties WorkingHours and SchoolHours and a method Learn().

Override the methods Work() of the trainee class so that it indicates the working hours of the trainee.

Create an object of each of the three classes (with arbitrary values) and call the methods, Lead() of Boss and Work() of Trainee.

Create a Task mathod with timer function for Trainees class
### Program.cs
```cs
Employee employee1 = new Employee("John", 200000);
Console.WriteLine("This is {0} and he makes ${1} a year", employee1.Name, employee1.Salary);

Boss boss = new Boss("Michael", 500000, true);
if (boss.CompanyCar)
    Console.WriteLine("CEO of the company is {0} and he uses company car", boss.Name);
else
    Console.WriteLine("CEO of the company is {0}", boss.Name);

Trainees trainees = new Trainees("Matilda", "10AM - 2PM");
Console.WriteLine("{0} is a trainee and her working hours are: {1}", trainees.Name, trainees.WorkingHours);
trainees.Task();
Console.ReadKey();
```
### Employee.cs
```cs
namespace exercise01
{
    internal class Employee
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int Salary { get; set; }
        public Employee() { }
        public Employee(string name, int salary) 
        {
            Name = name;
            Salary = salary;
        }
        public void Work()
        {
            Console.WriteLine("Working hours: 9AM - 5PM ");
        }
        public void Pause() 
        {
            Console.WriteLine("Break at 12");
        }
    }
}
```
### Boss.cs
```cs
namespace exercise01
{
    internal class Boss : Employee
    {
        public bool CompanyCar {  get; set; }
        public Boss() { }
        public Boss(string name, int salary, bool companyCar):base(name, salary)
        {
            CompanyCar = companyCar;
        }
        public void Lead() 
        {
            Console.WriteLine("I'm leading");
        }
    }
}
```
### Trainees.cs
```cs
namespace exercise01
{
    internal class Trainees : Employee
    {
        Timer timer;
        protected bool taskStarted = true;
        protected int currDuration = 0;
        public string WorkingHours {  get; set; }
        protected string SchoolHours { get; set; }
        public Trainees() { }
        public Trainees(string name, string workingHours) 
        {
            Name = name;
            WorkingHours = workingHours;
        }
        public void Work() 
        {
            Console.WriteLine("Working hours: {0}", WorkingHours);
        }
        public void Task()
        {
            if (taskStarted)
            {
                Console.WriteLine("Press any key to start a task for {0}", Name);
                Console.ReadLine();
                taskStarted = true;
                Console.WriteLine("The task started");
                timer = new Timer(TimerCallback, null, 0, 1000);
            }
        }
        private void TimerCallback(Object o)
        {
            if (currDuration < 15)
            {
                currDuration++;
                Console.WriteLine("{0} seconds passed", currDuration);
                GC.Collect();
            }
            else
            {
                Stop();
            }
        }
        public void Stop()
        {
            if (taskStarted)
            {
                taskStarted = false;
                Console.WriteLine("Stopped at {0}", currDuration);
                currDuration = 0;
                timer.Dispose();
            }
        }
    }
}
```
