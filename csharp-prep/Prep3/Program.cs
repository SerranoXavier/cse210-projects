using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        do
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess;
            int tries = 0;

            do
            {
                Console.Write("What is your guess? ");
                string userInputGuess = Console.ReadLine();
                guess = int.Parse(userInputGuess);

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                    Console.WriteLine();
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                    Console.WriteLine();
                }
                else if (guess == magicNumber)
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine();
                }

                tries ++;

            } while (guess != magicNumber);

            Console.WriteLine($"You guessed the magic number in {tries} tries.");
            Console.WriteLine();

            do
            {
                Console.Write("Do you want to play again (yes/no)? ");
                playAgain = Console.ReadLine();
            } while (!(playAgain == "yes" || playAgain == "y" || playAgain == "no" || playAgain == "n"));
        } while (playAgain == "yes" || playAgain == "y");

    }
}