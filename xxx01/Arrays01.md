### Declaring and Initializing Arrays
```cs
//declare and initialize array grades
int[] grades = new int[5];
grades[0] = 8;
grades[1] = 18;
//assign value to array grades at index 0
string? input = Console.ReadLine();
grades[0] = int.Parse(input);
//another way of initializing an array
int[] gradesMath = { 2, 5, 3, 9 };
//third way of initializing an array
int[] gradesSports  = new int[] {8,9,6,11};
```
### Multidemensional Arrays
```cs
//two dimentinal array
int[,] array2D = new int[,]
{
    { 1,2,3 },
    { 4,5,6 },
    { 7,8,9 }
};
Console.WriteLine(array2D[2,0]);
//three dimentinal array
int[,,] array3D = new int[,,]
{
    {
        { 1,2,3 },
        { 4,5,6 },
        { 7,8,9 }
    },
    {
        { 10,11,12 },
        { 13,14,15 },
        { 16,17,18 }
    }
};
Console.WriteLine(array3D[1,2,0]);
int dimensions = array3D.Rank;
Console.WriteLine(dimensions);
```
### Nested For Loops And 2D Arrays
```cs
int[,] matrix = new int[,]
{
    { 1,2,3 },
    { 4,5,6 },
    { 7,8,9 }
};
//outer for loop
for  (int i = 0; i < matrix.GetLength(0); i++)
{
    //Console.Write(i + " ");
    //inner for loop
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        //Console.Write(matrix[i, j] + " ");
        if (matrix[i, j] % 2 == 0 && false)
        {
            Console.Write(matrix[i, j] + " ");
        }
        if (i == j && true)
        {
            //print diagonal 
            Console.Write(matrix[i, j] + " ");
        }
    }
}
```
### Jagged Arrays
```cs
//declare jagged array
int[][] jaggedArray = new int[3][];
jaggedArray[0] = new int[5];
jaggedArray[1] = new int[3];
jaggedArray[2] = new int[2];
jaggedArray[0] = new int[] {4,7,3,9,11 };
jaggedArray[1] = new int[] { 3, 9, 5 };
jaggedArray[2] = new int[] { 1, 2 };
//declare jagged array
int[][] jaggedArray2 = new int[][]
{
    new int[] {4,7,3,9,11 },
    new int[] { 3, 9, 5 },
    new int[] { 1, 2 }
};
//Console.WriteLine(jaggedArray2[0][2]);
for (int i = 0; i < jaggedArray2.Length; i++)
{
    Console.WriteLine("Element: " + i);
    for (int j = 0; j < jaggedArray2[i].Length; j++)
    {
        Console.WriteLine(jaggedArray2[i][j]);
    }
}
```
