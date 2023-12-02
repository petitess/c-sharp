namespace exercise01
{
    internal class FileName
    {
        static void Main(string[] args)
        {
            UniversityManager um = new UniversityManager();
            um.MaleStudents();
            um.SortStudentsByAge();
            um.AllStudentsFromBeijingTech();
            um.GetStudents();
            //Sort itegers v1
            int[] ints = { 12, 54, 2, 76, 21 };
            IEnumerable<int> sortInts = from i in ints orderby i select i;
            IEnumerable<int> reversedInt = sortInts.Reverse();
            foreach (int i in reversedInt)
            {
                Console.WriteLine(i);
            }
            //Sort itegers v2
            IEnumerable<int> reversedSortedInts = from i in ints orderby i descending select i;
            foreach (var i in reversedSortedInts)
            {
            Console.WriteLine(i);
            }
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
            students.Add(new Student { Id = 2, Name = "Carl", Gender = "male", Age = 31, UniversityId = 1 });
            students.Add(new Student { Id = 3, Name = "Leyla", Gender = "female", Age = 21, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "James", Gender = "male", Age = 32, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2 });
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

        public void SortStudentsByAge()
        {   //LINQ
            var sortedStudents = from student in students orderby student.Age select student;
            Console.WriteLine("Students sorted by age: ");
            foreach (Student student in sortedStudents)
            {
                student.Print();
            }
        }

        public void AllStudentsFromBeijingTech()
        {   //LINQ
            IEnumerable<Student> bjtStudents = from student in students 
                                               join university in universities on student.UniversityId equals university.Id
                                               where university.Name == "Beijing Tech"
                                               select student;
            Console.WriteLine("Students from Beijing Tech: ");
            foreach (var student in bjtStudents)
            {
                student.Print();
            }
        }
        public void GetStudents()
        {
            Console.WriteLine("Type university ID: ");
            string x = Console.ReadLine();
            int xToInt;
            if (int.TryParse(x, out xToInt))
            {   //LINQ
                IEnumerable<Student> bjtStudents = from student in students
                                                   join university in universities on student.UniversityId equals university.Id
                                                   where university.Id == xToInt
                                                   select student;
                IEnumerable<University> u = from university in universities where university.Id == xToInt select university;
                //Get the first element from an IEnumerable v1
                var e = u.ElementAt(0).Name;
                Console.WriteLine(e);
                //Get the first element from an IEnumerable v2
                var f = u.FirstOrDefault().Name; 
                Console.WriteLine(f);
                //Get the first element from an IEnumerable v3
                foreach (var university in u) 
                { 
                    Console.WriteLine("Students from {0}:", university.Name); 
                }

                foreach (var student in bjtStudents)
                {
                    student.Print();
                }
            }else { Console.WriteLine("Invalid ID"); }
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
