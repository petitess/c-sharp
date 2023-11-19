//Print a range of numbers
static List<int> Solution() 
{
    int[] list;
    list = Enumerable.Range(100, 71).ToArray();
    foreach (int i in list)
    {
        Console.WriteLine(i);
    }
    return list.ToList();
}
////Add a range of numbers to a List
static List<int> Solution2()
{
    List<int> myList = new List<int>();
    for (int i = 100; i <= 170; i++) 
    {
        if (i % 2 == 0) 
        {
            myList.Add(i);
            Console.WriteLine(i);
        }
    }
    return myList;
}
////
