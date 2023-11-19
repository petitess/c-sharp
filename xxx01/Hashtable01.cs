namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable table = new Hashtable();

            Student st1 = new Student(1, "Maria", 98);
            Student st2 = new Student(2, "Maria", 76);
            Student st3 = new Student(3, "Maria", 82);
            Student st4 = new Student(4, "Maria", 77);
            Student st5 = new Student(5, "Maria", 55);

            table.Add(st1.Id, st1);
            table.Add(st2.Id, st2);
            table.Add(st3.Id, st3);
            table.Add(st4.Id, st4);
            table.Add(st5.Id, st5);
            //retrive individual item with known id
            Student existingStudent = (Student)table[st1.Id];
            Console.WriteLine("ID:{0}, Name:{1},GPA:{2}", st1.Id, st1.Name, st1.GPA);
            //retrive all values from a Hashtable
            foreach (Student student in table.Values)
            {
                Console.WriteLine("ID: " + student.Id);
                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("GPA: " + student.GPA);
            }
        }
    }
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float GPA { get; set; }
        public Student(int id, string name, float GPA)
        {
            this.Id = id;
            this.Name = name;
            this.GPA = GPA;
        }
    }
}
