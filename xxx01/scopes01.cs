namespace SimpleMethod
{
    internal class Program
    {
        private static string k = "";
        static void Main(string[] args)
        {
           string j = "";
           for (int i = 0; i < 10; i++) 
            {
                j = i.ToString(); 
                k = i.ToString();
                Console.WriteLine(i);

                if (i == 9) 
                {
                string l = i.ToString();
                }

            }
            Console.WriteLine("Outside of the for: " + j);
            Console.WriteLine("Outside of the for: " + k);

            HelperMethod();

            Car car1 = new Car();
            car1.DoSomething();
        }
        static void HelperMethod()
        {
            Console.WriteLine("Value of k from HelperMethod: " + k);
        }
    }

    class Car
    {
        public void DoSomething()
        {
            Console.WriteLine(helperMethod());
        }
        private string helperMethod()
        {
            return "Hello World";
        }
    }
}
