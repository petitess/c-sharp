namespace exercise01
{
    internal class FileName
    {
        static void Main(string[] args)
        {
            UniversityManager um = new UniversityManager();
            um.MaleStudents();
        }
    }

    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        public UniversityManager()
        {
            universities = new List<University>();
            students = new List<Student>();

            universities.Add(new University { Id = 1, Name = "Yale" });
            universities.Add(new University { Id = 2, Name = "Beijing Tech" });

            students.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 19, UniversityId = 1 });
            students.Add(new Student { Id = 1, Name = "Carl", Gender = "male", Age = 31, UniversityId = 1 });
            students.Add(new Student { Id = 1, Name = "Leyla", Gender = "female", Age = 21, UniversityId = 2 });
            students.Add(new Student { Id = 1, Name = "James", Gender = "male", Age = 32, UniversityId = 2 });
            students.Add(new Student { Id = 1, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2 });
        }
        public void MaleStudents()
        {   //LINQ
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;
            Console.WriteLine("Male students: ");
            foreach(Student student in maleStudents)
            {
                student.Print();
            }
        }
    }

    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Print() 
        {
            Console.WriteLine("University {0} with id {1}", Name, Id);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int UniversityId { get; set; }
        public void Print()
        {
            Console.WriteLine("Studen {0} with Id {1}, Gender {2} and Age {3} from university with the Id {4}", Name, Id, Gender, Age, UniversityId);
        }
    }
}
