static void GetScore()
{
    int hightscore = 55;
    Console.WriteLine("Whats you name?");
    string? name = Console.ReadLine();
    Console.WriteLine("Whats your score?");
    string? score = Console.ReadLine();
    int scoreToInt = int.Parse(score);

    if (scoreToInt > hightscore)
    {
        Console.WriteLine("New hightscore is " + scoreToInt);
        Console.WriteLine("It is now held by " + name);
        hightscore = scoreToInt;
    }
    else
    {
        Console.WriteLine("Try again");
    }
}
