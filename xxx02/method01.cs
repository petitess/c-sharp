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
