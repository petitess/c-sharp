namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalValue = 0;
            int[] intsToCompress2 = new int[] { 10, 15, 20, 25, 30, 12, 34 };
            totalValue = GetSum(intsToCompress2);
            Console.WriteLine("GetSum: " + totalValue);
        }
        static private int GetSum(int[] intsToCompress)
        {
            int totalValue = 0;
            foreach (int intToCompress in intsToCompress)
            {
                totalValue += intToCompress;
            }
            return totalValue;
        }
    }
}
/////////////
namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> myNumberList = new List<int>(){
                2, 3, 5, 6, 7, 9, 10, 123, 324, 54
            };

            foreach (int number in myNumberList)
            {
                PrintIfOdd(number);
            }
        }
        static private int PrintIfOdd(int number)
        {
            if (number% 2 != 0)
            {
                Console.WriteLine(number);
                return number;
            }
            else
            {
                return number;
            }
        }
    }
}
