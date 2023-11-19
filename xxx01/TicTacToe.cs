

int player = 2;
int input = 0;
bool inputCorrect = true;
int turns = 0;  
char[,] filed = new char[,]
    {
    { '1', '2', '3' },
    { '4', '5', '6' },
    { '7', '8', '9' }
    };

do
{
    if (player == 2)
    {
        player = 1;
        EnterXorO(player, input, filed);
    }
    else if (player == 1)
    {
        player = 2;
        EnterXorO(player, input, filed);
    }
    SetFiled(filed, turns);
    #region
    //Check winning condition
    char[] playerChars = { 'X', 'O' };

    foreach (char c in playerChars)
    {
        if (((filed[0,0] == c) && (filed[0,1] == c) && (filed[0,2] == c))
            || ((filed[1, 0] == c) && (filed[1, 1] == c) && (filed[1, 2] == c))
            || ((filed[2, 0] == c) && (filed[2, 1] == c) && (filed[2, 2] == c))
            || ((filed[0, 0] == c) && (filed[1, 0] == c) && (filed[2, 0] == c))
            || ((filed[0, 1] == c) && (filed[1, 1] == c) && (filed[2, 1] == c))
            || ((filed[0, 2] == c) && (filed[1, 2] == c) && (filed[2, 2] == c))
            || ((filed[0, 0] == c) && (filed[1, 1] == c) && (filed[2, 2] == c))
            || ((filed[0, 2] == c) && (filed[1, 1] == c) && (filed[2, 0] == c)))
        {
            if (c == 'X')
            {
                Console.WriteLine("\nPlayer 2 has won");
            }
            else 
            { 
            Console.WriteLine("\nPlayer 1 has won");
            }
            Console.WriteLine("Press any Key to Reset the Game");
            Console.ReadKey();
            //reset filed
            //filed = filedInitial;
            turns = 0;
            //SetFiled(filed, turns);
            ResteGame(filed,turns);
            break;
        }
        else if (turns == 10)
        {
            Console.WriteLine("/Draw");
            Console.WriteLine("Press any Key to Reset the Game");
            Console.ReadKey();
            //filed = filedInitial;
            turns = 0;
            //SetFiled(filed, turns);
            ResteGame(filed, turns);
            break;
        }
    }
    #endregion

    #region
    do
    {
        Console.WriteLine("\nPlayer {0}: Choose your filed! ", player);
        //controll the value is correct
        try
        {
            input = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Please enter a number");
        }

        if ((input == 1) && (filed[0, 0] == '1'))
            inputCorrect = true;
        else if ((input == 2) && (filed[0, 1] == '2'))
            inputCorrect = true;
        else if ((input == 3) && (filed[0, 2] == '3'))
            inputCorrect = true;
        else if ((input == 4) && (filed[1, 0] == '4'))
            inputCorrect = true;
        else if ((input == 5) && (filed[1, 1] == '5'))
            inputCorrect = true;
        else if ((input == 6) && (filed[1, 2] == '6'))
            inputCorrect = true;
        else if ((input == 7) && (filed[2, 0] == '7'))
            inputCorrect = true;
        else if ((input == 8) && (filed[2, 1] == '8'))
            inputCorrect = true;
        else if ((input == 9) && (filed[2, 2] == '9'))
            inputCorrect = true;
        else
        {
            Console.WriteLine("\n Incorrect input! Please use another field!");
            inputCorrect = false;
        }

    } while (!inputCorrect);

} while (true);
#endregion

static void SetFiled(char[,] filed, int turns)
{
    
    Console.Clear();
    Console.WriteLine(filed[0, 0] + " | " + filed[0, 1] + " | " + filed[0, 2]);
    Console.WriteLine("---------");
    Console.WriteLine(filed[1, 0] + " | " + filed[1, 1] + " | " + filed[1, 2]);
    Console.WriteLine("---------");
    Console.WriteLine(filed[2, 0] + " | " + filed[2, 1] + " | " + filed[2, 2]);
    turns++;
}

static void EnterXorO(int player, int input, char[,] filed)
{
    char playerSign = ' ';
    if (player == 1)
        playerSign = 'X';
    else
        playerSign = 'O';

    switch (input)
    {
        case 1: filed[0, 0] = playerSign; break;
        case 2: filed[0, 1] = playerSign; break;
        case 3: filed[0, 2] = playerSign; break;
        case 4: filed[1, 0] = playerSign; break;
        case 5: filed[1, 1] = playerSign; break;
        case 6: filed[1, 2] = playerSign; break;
        case 7: filed[2, 0] = playerSign; break;
        case 8: filed[2, 1] = playerSign; break;
        case 9: filed[2, 2] = playerSign; break;

    }
}

static void ResteGame(char[,] filed, int turns)
{
    char[,] filedInitial = new char[,]
    {
    { '1', '2', '3' },
    { '4', '5', '6' },
    { '7', '8', '9' }
    };
    filed = filedInitial;
    SetFiled(filed, turns);
}
