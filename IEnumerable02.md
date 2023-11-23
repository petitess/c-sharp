### Example 1
```cs
IEnumerable<int> unknownCollection;
unknownCollection = GetCollection(1);

foreach (var item in unknownCollection)
{
    Console.WriteLine(" {0} ", item);
}
static IEnumerable<int> GetCollection(int option)
{
    //create a list of numbers and initialize it
    List<int> result = new List<int>() { 4,7,32,7};
    //create a queue of numbers and initialize it
    Queue<int> q = new Queue<int>();
    q.Enqueue(5);
    q.Enqueue(8);
    q.Enqueue(22);
    q.Enqueue(12);
    q.Enqueue(3);

    if (option == 1)
    {
        return result;
    }
    else if (option == 2)
    {
        return q;
    }
    else
    {
        return new int[] { 1, 2, 3, };
    }
}
```
