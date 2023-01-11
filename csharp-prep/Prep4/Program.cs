using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput;
        int numberInput;
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.WriteLine();
        do
        {
            Console.Write("Enter a number: ");
            userInput = Console.ReadLine();
            numberInput = int.Parse(userInput);
            if (numberInput != 0)
            {
                numbers.Add(numberInput);
            }
        } while (numberInput != 0);

        Console.WriteLine();

        int sum = 0;
        int largest = -999999999;
        foreach (int number in numbers)
        {
            sum += number;
            if (largest < number)
            {
                largest = number;
            }
        }

        Console.WriteLine($"The sum is: {sum}.");
        Console.WriteLine($"The average is: {((float)sum)/numbers.Count}.");
        Console.WriteLine($"The largest number is: {largest}.");
    }
}