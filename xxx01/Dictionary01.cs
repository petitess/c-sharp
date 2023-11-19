namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees =
            {
                new Employee("CEO", "Martin", 200),
                new Employee("Manager", "Joe", 25),
                new Employee("IT", "Lora", 35),
            };

            Dictionary<string, Employee> empDict = new Dictionary<string, Employee>();
            //Add data to Dictionary
            foreach (Employee empx in employees)
            {
                empDict.Add(empx.Role, empx);
            }
            //Get object from Dictionary
            if (empDict.ContainsKey("CEO"))
            {
                Employee x = empDict["CEO"];
                Console.WriteLine(x.Name);
            }
            //Get all objects from Dictionary
            for (int i = 0; i < empDict.Count; i++)
            {
                KeyValuePair<string, Employee> keyValue = empDict.ElementAt(i);
                Console.WriteLine("Key: " + keyValue.Key + " Value: " + keyValue.Value.Name);
            }
            //Update object
            string keyToUpdate = "Manager";
            if (empDict.ContainsKey(keyToUpdate))
            {
                empDict[keyToUpdate] = new Employee("Manager", "Eleka", 45);
            }
            //Remove object
            string keyToRemove = "IT";
            if (empDict.Remove(keyToRemove))
            {
                Console.WriteLine("{0} removed", keyToRemove);
            }  
        }
        internal class Employee
        {
            public string Role { get; set; }
            public string Name { get; set; }
            public float Rate { get; set; }
            public float Salary
            {
                get { return Rate * 8 * 5 * 4 * 12; }
            }
            public Employee(string role, string name, float rate)
            {
                this.Role = role;
                this.Name = name;
                this.Rate = rate;
            }
        }
    }
}
