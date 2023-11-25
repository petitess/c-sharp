### Example 1
```cs
Random dice = new Random();
int numEyes;
for (int i = 0; i<10; i++)
{
    numEyes = dice.Next(1, 7);
    Console.WriteLine(numEyes);
}
Console.ReadKey();
```
### Example 2
```cs
Console.WriteLine("Enter your question");
Console.ReadLine();
Random yesNoMaybe = new Random();
int answerNum = yesNoMaybe.Next(1,11);
if (answerNum == 1)
{
    Console.WriteLine("Yes");
}
else if (answerNum == 2)
{
    Console.WriteLine("Maybe");
}
else
{
    Console.WriteLine("No");
}
```
