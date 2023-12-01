namespace exercise01
{
    internal class FileName
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };

            OddNumbers(numbers);
        }
        static void OddNumbers(int[] numbers)
        {
            Console.WriteLine("Odd numbers");
            //LINQ
            IEnumerable<int> oddNumbers = from number in numbers where number % 2 != 0 select number;
            Console.WriteLine(oddNumbers);
            foreach (int number in oddNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
