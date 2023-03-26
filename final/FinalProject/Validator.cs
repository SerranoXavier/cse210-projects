using System;

public class Validator
{
    public int GetValidInt(string prompt, bool strictlyPositive = true)
    {
        int number;
        Spinner spinner = new Spinner();
        if (strictlyPositive)
        {
            do
            {
                Console.Write($"{prompt} ");
                string input = Console.ReadLine();
                if(int.TryParse(input, out number)) // test if input can be parse as an integer
                {
                    if (int.Parse(input) > 0 && strictlyPositive )
                    {
                        number = int.Parse(input);
                    }
                    else{
                        Console.WriteLine("This is not a valid number.");
                        spinner.Wait(2);
                    }
                }
                else
                {
                    Console.WriteLine("This is not a valid number.");
                    spinner.Wait(2);
                }
            } while (number <= 0);
        }
        else
        {
            do
            {
                Console.Write($"{prompt} ");
                string input = Console.ReadLine();
                if(int.TryParse(input, out number)) // test if input can be parse as an integer
                {
                    if (int.Parse(input) >= 0)
                    {
                        number = int.Parse(input);
                    }
                    else{
                        Console.WriteLine("This is not a valid number.");
                        spinner.Wait(2);
                    }
                }
                else
                {
                    Console.WriteLine("This is not a valid number.");
                    spinner.Wait(2);
                }
            } while (number < 0);
        }
        return number;
    }
    public double GetValidDouble(string prompt, bool strictlyPositive = true)
    {
        double number;
        Spinner spinner = new Spinner();
        if (strictlyPositive)
        {
            do
            {
                Console.Write($"{prompt} ");
                string input = Console.ReadLine();
                if(double.TryParse(input, out number)) // test if input can be parse as an double
                {
                    if (double.Parse(input) > 0 && strictlyPositive )
                    {
                        number = double.Parse(input);
                    }
                    else{
                        Console.WriteLine("This is not a valid number.");
                        spinner.Wait(2);
                    }
                }
                else
                {
                    Console.WriteLine("This is not a valid number.");
                    spinner.Wait(2);
                }
            } while (number <= 0);
        }
        else
        {
            do
            {
                Console.Write($"{prompt} ");
                string input = Console.ReadLine();
                if(double.TryParse(input, out number)) // test if input can be parse as an double
                {
                    if (double.Parse(input) >= 0)
                    {
                        number = double.Parse(input);
                    }
                    else{
                        Console.WriteLine("This is not a valid number.");
                        spinner.Wait(2);
                    }
                }
                else
                {
                    Console.WriteLine("This is not a valid number.");
                    spinner.Wait(2);
                }
            } while (number < 0);
        }
        return number;
    }
    public DateTime GetValidDate(string prompt)
    {
        DateTime date;
        Spinner spinner = new Spinner();
        bool parsed = false;
        do
        {
            Console.Write($"{prompt} ");
            string input = Console.ReadLine();
            if(DateTime.TryParse(input, out date)) // test if input can be parse as a date
            {
                date = DateTime.Parse(input);
                parsed = true;
            }
            else
            {
                Console.WriteLine("This is not a valid date.");
                spinner.Wait(2);
            }
        } while (parsed is false);
        return date;
    }
}