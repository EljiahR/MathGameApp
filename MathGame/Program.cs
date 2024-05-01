bool playAgain = false;
Random random = new();
do
{
    Console.WriteLine("Welcome to MathGame!");
    Console.WriteLine("Please select game mode:");
    Console.WriteLine("1. Addition");
    Console.WriteLine("2. Subtraction");
    Console.WriteLine("3. Multiplication");
    Console.WriteLine("4. Division");

    int gameMode = GetResponse(1, 4);
    Console.WriteLine("Choose your difficulty from 1-5");
    int difficulty = GetResponse(1, 5);

    MathGame(gameMode, difficulty);
    Console.WriteLine("Would you like to play again? y/n");
    playAgain = Console.ReadLine() == "y";

} while (playAgain);

Console.WriteLine("Goodbye!");
Console.ReadLine();



void MathGame(int gameMode, int difficulty)
{
    int score = 0;
    int min = 1;
    int max = (int)Math.Pow(10, difficulty);
    for (int i = 0;  i < difficulty + 2; i++)
    {
        
        int num1 = random.Next(min, max);
        int num2 = random.Next(gameMode == 4 ? 2 : min, gameMode == 4 ? 10 : max);
        if ((gameMode == 2 || gameMode == 4) && num2 > num1) (num1, num2) = (num2, num1);
        if(gameMode == 4)
            while(num1 % num2 != 0)
            {
                num1 = random.Next(min, max);
                num2 = random.Next(gameMode == 4 ? 2 : min, gameMode == 4 ? 10 : max);
            }
        
        bool correct = false;
        switch (gameMode)
        {
            case 1:
                Console.WriteLine($"{num1} + {num2}");
                if (Console.ReadLine() == (num1 + num2).ToString()) correct = true;
                break;
            case 2:
                Console.WriteLine($"{num1} - {num2}");
                if (Console.ReadLine() == (num1 - num2).ToString()) correct = true;
                break;
            case 3:
                Console.WriteLine($"{num1} * {num2}");
                if (Console.ReadLine() == (num1 * num2).ToString()) correct = true;
                break;
            case 4:
                Console.WriteLine($"{num1} / {num2}");
                if (Console.ReadLine() == (num1 / num2).ToString()) correct = true;
                break;
        }

        if (correct)
        {
            score++;
            Console.WriteLine("Correct!");
        }
        else Console.WriteLine("Incorrect!");
    }

    Console.Write("Final Score");
    Thread.Sleep(1000);
    for ( int i = 0; i < 3; i++)
    {
        Console.Write(".");
        Thread.Sleep(1000);  
    }
    Console.Write($" {score}!\n");
}

int GetResponse(int min, int max)
{
    string? response = Console.ReadLine();
    int result;
    while (response == null || !int.TryParse(response, out result) || result > max || result < min)
    {
        Console.WriteLine($"Response should be a number from {min} to {max}. Please try again:");
        response = Console.ReadLine();
    }
    return result;
}

