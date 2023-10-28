namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Todo> todos = new List<Todo>()
            {
                new Todo { Description = "Task 1", EstimatedHours = 6, Status = Status.InProgress},
                new Todo { Description = "Task 2", EstimatedHours = 12, Status = Status.Deleted},
                new Todo { Description = "Task 3", EstimatedHours = 3, Status = Status.Completed},
                new Todo { Description = "Task 4", EstimatedHours = 7, Status = Status.NotStarted},
                new Todo { Description = "Task 5", EstimatedHours = 11, Status = Status.NotCompleted},
            };

            Console.ForegroundColor = ConsoleColor.DarkRed;
            PrintAssesment(todos);
            Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintAssesment2(todos);
            Console.ReadLine();
        }

        private static void PrintAssesment(List<Todo> todos)
        {
            foreach (Todo todo in todos)
            {
                switch (todo.EstimatedHours) 
                {
                    case 6:
                        Console.WriteLine(todo.Description);
                        break;

                    case 10:
                        Console.WriteLine(todo.Description);
                        break;

                    case 11:
                        Console.WriteLine(todo.Description);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintAssesment2(List<Todo> todos)
        {
            foreach (Todo todo in todos)
            {
                switch (todo.Status)
                {
                    case Status.Completed:
                        Console.WriteLine(todo.Description);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    class Todo
    {
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public Status Status { get; set; }
    }
    enum Status
    {
        InProgress,
        Deleted,
        Completed,
        NotStarted,
        NotCompleted,
        Started,
        OnHold
    }
}
