using System.Collections;
//declare an ArrayList with undefined amout of object
ArrayList myArray = new ArrayList();
//declare an ArrayList with defined amout of object
ArrayList myArray2 = new ArrayList();

myArray.Add(25);
myArray.Add("Hello");
myArray.Add(13.37);
myArray.Add(13);
myArray.Add(128);
myArray.Add(25.3);
myArray.Remove(13);
myArray.RemoveAt(0);
Console.WriteLine(myArray.Count);

double sum = 0;
foreach (object obj in myArray)
{
    if (obj is int)
    {
        sum += Convert.ToDouble(obj);
    }
    else if (obj is double)
    {
        sum += (double)obj;
    }
    else if (obj is string)
    {
        Console.WriteLine(obj);
    }
}
Console.WriteLine(sum);
//////
