namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime value = DateTime.Now;
            Console.WriteLine(value.ToString());
            Console.WriteLine(value.ToShortDateString());
            Console.WriteLine(value.ToShortTimeString());
            Console.WriteLine(value.ToLongDateString());
            Console.WriteLine(value.ToLongTimeString());
            Console.WriteLine(value.AddDays(3).ToLongDateString());
            Console.WriteLine(value.AddHours(3).ToLongTimeString());
            Console.WriteLine(value.Month);

            DateTime time1 = new DateTime(1993, 12, 24);
            Console.WriteLine(time1.ToShortDateString());

            DateTime time2 = DateTime.Parse("2010/10/30");
            Console.WriteLine(time2.ToShortDateString());
            TimeSpan diff = DateTime.Now.Subtract(time1);
            Console.WriteLine(diff.TotalDays);
        }
    }
}
