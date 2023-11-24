### Inheritance
Create a main class with the Main Method, then a base class Employee with the properties Name, FirstName, Salary, and the methods Work() and Pause().

Create a deriving class Boss with the property CompanyCar and the method Lead().  

Create another deriving class of employees - Trainees with the properties WorkingHours and SchoolHours and a method Learn().

Override the methods Work() of the trainee class so that it indicates the working hours of the trainee.

Create an object of each of the three classes (with arbitrary values) and call the methods, Lead() of Boss and Work() of Trainee.

Create a Task mathod with timer function for Trainees class
### Program.cs
```cs
Employee employee1 = new Employee("John", 200000);
Console.WriteLine("This is {0} and he makes ${1} a year", employee1.FirstName, employee1.Salary);

Boss boss = new Boss("Michael", 500000, true);
if (boss.CompanyCar)
    Console.WriteLine("CEO of the company is {0} and he uses company car", boss.FirstName);
else
    Console.WriteLine("CEO of the company is {0}", boss.Name);

Trainees trainees = new Trainees("Matilda", "10AM - 2PM");
Console.WriteLine("{0} is a trainee and her working hours are: {1}", trainees.FirstName, trainees.WorkingHours);
Console.WriteLine("{0}s salary is ${1} a month", trainees.FirstName, trainees.Salary);
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
        public Employee(string firstName, int salary) 
        {
            FirstName = firstName;
            Salary = salary;
        }
        //if you want to override a method use: public virtual
        public virtual void Work() 
        {
            Console.WriteLine("I'm working");
        }
        static void Pause()
        {
            Console.WriteLine("I'm having a break");
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
        public Boss(string firstName, int salary, bool companyCar):base(firstName, salary) 
        {
            CompanyCar = companyCar;
        }
        static void Lead()
        {
            Console.WriteLine("I'm the boss");
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
        public string SchoolHours { get; set; }
        public Trainees() { }
        public Trainees(string firstName, string workingHours):base(firstName, salary:1000)
        {
            WorkingHours = workingHours;
        }
        public override void Work()
        {
            Console.WriteLine("Working hours: " + WorkingHours);
        }
        //Timer function
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
            if (currDuration < 60)
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
