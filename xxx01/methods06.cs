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
public static string Convert(int i)
{
    Dictionary<int, string> empDict = new Dictionary<int, string>()
    {
        {0, "zero" },
        {1, "one" },
        {2, "two"},
        {3, "three" },
        {4, "four"},
        {5, "five" }
    };
    foreach (var key in empDict)
    {
        if (key.Key == i)
        {
            Console.WriteLine("Key: " + key.Key);
            return key.Value;
        }else
        {
            Console.WriteLine("nope");
        }
    }
    return empDict.Keys.ToString();
}
/////check if an integer exists in Dictionary
public static string Convert(int i)
{
    Dictionary<int, string> empDict = new Dictionary<int, string>()
    {
        {0, "zero" },
        {1, "one" },
        {2, "two"},
        {3, "three" },
        {4, "four"},
        {5, "five" }
    };
    if (empDict.ContainsKey(i))
        return empDict[i];
    else
        return "nope";
}
