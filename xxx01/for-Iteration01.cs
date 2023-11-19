for (int i = 0; i < 10; i++)
{
    //Console.WriteLine(i);
    if (i == 7)
    {
        Console.WriteLine("Found seven");
        break;
    }
}
///Calculate average
int[] nr = { 8, 5, 12, 8, 5, 9 };

Console.WriteLine(GetAverage(nr));

static double GetAverage(int[] grades)
{
    int size = grades.Length;
    double average;
    int sum = 0;
    for (int i = 0; i < size; i++)
    {
        sum += grades[i];
    }
    average = (double)sum / size;
    return average;
}
