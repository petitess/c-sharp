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
### Example 2
```cs
List<int> numberList = new List<int>() {6,23,8,4,2 };
CollectionSum(numberList);

int[] numberArray = new int[] {8,4,2,4,11,9};
CollectionSum(numberArray);

static void CollectionSum(IEnumerable<int> anyCollection)
{
    int sum = 0;
    foreach (var item in anyCollection)
    {
        sum += item;
    }
    Console.WriteLine("Sum is {0}", sum);
}
```
