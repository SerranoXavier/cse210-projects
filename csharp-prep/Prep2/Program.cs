using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade (%): ");
        string userInput = Console.ReadLine();
        Console.WriteLine();
        int grade = int.Parse(userInput);
        int remainder = grade % 10;

        string letter;
        string sign;
        
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (remainder >= 7 && (letter == "A" || letter == "F"))
        {
            sign = "";
        }
        else if (remainder < 3 && letter == "F")
        {
            sign = "";
        }
        else if (remainder >= 7)
        {
            sign = "+";
        }
        else if (remainder < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"Your letter grade is {letter}{sign}.");
        
        if (grade >= 70)
        {
            Console.WriteLine("You did pass the class. Congratulation!");
        }
        else
        {
            Console.WriteLine("You did not pass the class. Continue on working hard, next time you will succeed.");
        }

    }
}