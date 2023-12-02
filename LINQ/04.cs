namespace wpf02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataClassesDataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["wpf02.Properties.Settings.BigDbConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext(connectionString);
            //InsertUniversities();
            //InsertStudents();
            //InsertLectures();
            //InsertStudentLectureAssociations();
            GetUniversity();
        }
        public void InsertUniversities()
        {
            dataContext.ExecuteCommand("delete from University");
            University yale = new University();
            yale.Name = "Yale";
            dataContext.Universities.InsertOnSubmit(yale);
            University mich = new University();
            mich.Name = "University of Michigan";
            dataContext.Universities.InsertOnSubmit(mich);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Universities;
        }
        public void InsertStudents()
        {
            dataContext.ExecuteCommand("delete from Student");
            University yale = dataContext.Universities.First(un => un.Name.Equals("Yale"));
            University mich = dataContext.Universities.First(un => un.Name.Equals("University of Michigan"));

            List<Student> students = new List<Student>();
            students.Add(new Student { Name = "Carla", Gender = "female", University = yale });
            students.Add(new Student { Name = "Carl", Gender = "male", University = yale });
            students.Add(new Student { Name = "Anna", Gender = "female", University = mich });
            students.Add(new Student { Name = "Tom", Gender = "male", University = mich });
            students.Add(new Student { Name = "Leyla", Gender = "female", University = yale });
            dataContext.Students.InsertAllOnSubmit(students);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Students;
        }
        public void InsertLectures()
        {
            dataContext.ExecuteCommand("delete from Lecture");
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Math" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "History" });
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource= dataContext.Lectures; 
        }
        public void InsertStudentLectureAssociations()
        {
            dataContext.ExecuteCommand("delete from StudentLecture");
            Student carla = dataContext.Students.First(s => s.Name.Equals("Carla"));
            Student carl = dataContext.Students.First(s => s.Name.Equals("Carl"));
            Student anna = dataContext.Students.First(s => s.Name.Equals("Anna"));
            Student tom = dataContext.Students.First(s => s.Name.Equals("Tom"));
            Student leyla = dataContext.Students.First(s => s.Name.Equals("Leyla"));

            Lecture math = dataContext.Lectures.First(l => l.Name.Equals("Math"));
            Lecture history = dataContext.Lectures.First(l => l.Name.Equals("History"));

            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = carla, Lecture = math });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = carl, Lecture = history });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = anna, Lecture = history });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = tom, Lecture = math });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = leyla, Lecture = math });

            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.StudentLectures;
        }
        public void GetUniversity()
        {
            Student tom = dataContext.Students.First(s => s.Name.Equals("Tom"));
            University university = tom.University;
            List<University> universities = new List<University>();
            universities.Add(university);
            MainDataGrid.ItemsSource = universities;
        }
    }
}
