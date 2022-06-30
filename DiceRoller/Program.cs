bool runProgram = true;
int sides = 0;
int die1 = 0;
int die2 = 0;

Console.WriteLine("Welcome to the Casino!\n");

while (true)
{
    try
    {
        Console.WriteLine("How many sides should each die have?");
        sides = int.Parse(Console.ReadLine());

        if (sides < 1)
        {
            throw new Exception("The die must have one or more sides");
        }
        else
        {
            break;
        }
    }
    catch (FormatException e)
    {
        Console.WriteLine("Error! Input must be a number.");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

Console.WriteLine("Press any key to roll the dice");
Console.ReadKey();

while (runProgram)
{
    
    die1 = GetRandom(sides);
    die2 = GetRandom(sides);
    int total = die1 + die2;

    Console.WriteLine($"\nYou got a {die1} and a {die2}! Total: {total}");

    if(sides == 6)
    {
        Console.WriteLine(getDiceCombos(die1, die2));
        Console.WriteLine(getDiceTotals(total));
    }

    while (true)
    {
        Console.WriteLine("\nWould you like to roll again? y/n:");
        string rollAgain = Console.ReadLine().ToLower().Trim();
        if (rollAgain == "y")
        {
            break;
        }
        else if (rollAgain == "n")
        {
            runProgram = false;
            break;
        }
        else
        {
            Console.WriteLine("That was not y/n");
        }
    }
}

Console.WriteLine("\nGoodbye!");





//Methods
static int GetRandom(int sides)
{
    Random rnd = new Random();
    int dice = rnd.Next(1, sides + 1);
    return dice;
}

static string getDiceCombos(int die1, int die2)
{
    if (die1 == 1 && die2 == 1)
    {
        return ("Snake Eyes!");
    }
    else if (die1 == 6 && die2 == 6)
    {
        return ("Box Cars!");
    }
    else if(die1 == 1 && die2 == 2)
    {
        return ("Ace Deuce!");
    }
    else if(die1 == 2 && die2 == 1)
    {
        return ("Ace Deuce!");
    }
    else
    {
        return ("");
    }
}

static string getDiceTotals(int total)
{
    if (total == 7 || total == 11)
    {
        return ("Win!");
    }
    else if(total == 2 || total == 3 || total == 12)
    {
        return ("Craps!");
    }
    else
    {
        return ("");
    }
}
    
