### Loops
```cs
for (int counter = 0; counter <= 12; counter+=3)
{
    Console.WriteLine(counter);
}
//
for (int number = 0;  number <= 20; number+=2)
{
    Console.WriteLine(number);
}
```
```cs
int lenghtOfText = 0;
do
{
    Console.WriteLine("Enter your name");
    string? name = Console.ReadLine();
    int nameLenght = name.Length;
    lenghtOfText += nameLenght;
    Console.WriteLine(nameLenght);
}while (lenghtOfText < 10);
```
```cs
int count = 0;
while (count < 10)
{
    Console.WriteLine(count);
    count++;
}
//
int counter = 0;
string? text = "";
while (text.Equals(""))
{
    Console.WriteLine("Press enter");
    text = Console.ReadLine();
    counter++;
    Console.WriteLine("People count is " +  counter);
}
Console.WriteLine(counter + " People");
```
```cs
for(int counter = 0; counter <= 12; counter ++)
{
    Console.WriteLine(counter);
    if (counter == 3)
    {
        Console.WriteLine("At 3 we stop");
        break;
    }
}
```
```cs
for (int counter = 0; counter <= 12; counter++)
{
    if (counter == 3)
    {
        Console.WriteLine("At 3 we stop");
        continue;
    }
    Console.WriteLine(counter);
}
```
```cs
for (int counter = 0; counter <= 12; counter++)
{
    if (counter %2 == 0)
        continue;
    Console.WriteLine(counter);
}
```
```cs
//Get average number
string input = "0";
int count = 0;
int total = 0;
int currentNumber = 0;

while (input != "-1")
{
    Console.WriteLine("Last number was: " + currentNumber);
    Console.WriteLine("Enter score");
    Console.WriteLine("Current amount of entries: " + count);
    Console.WriteLine("Enter -1 to get average");
    input = Console.ReadLine();
    if (input == "-1")
    {
        Console.WriteLine("-----------------");
        double average = (double)total / (double)count;
        Console.WriteLine("The average score is: " + average);
    }
    if (int.TryParse(input, out currentNumber) && currentNumber >= 0 && currentNumber <= 20)
    {
        total += currentNumber;
    }
    else
    {
        if (!(input != "-1")) 
        {
            Console.WriteLine("Please enter the value between 1 and 20");
        }
        continue;
    }
    count++;
}
Console.Read();
```
