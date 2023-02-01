using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction first = new Fraction();
        Fraction second = new Fraction(6);
        Fraction third = new Fraction(6,7);

        Console.WriteLine(first.GetTop());
        Console.WriteLine(first.GetBottom());
        Console.WriteLine(second.GetTop());
        Console.WriteLine(second.GetBottom());
        Console.WriteLine(third.GetTop());
        Console.WriteLine(third.GetBottom());

        first.SetTop(2);
        first.SetBottom(2);
        second.SetTop(7);
        second.SetBottom(2);
        third.SetTop(7);
        third.SetBottom(8);

        Console.WriteLine();
        Console.WriteLine(first.GetTop());
        Console.WriteLine(first.GetBottom());
        Console.WriteLine(second.GetTop());
        Console.WriteLine(second.GetBottom());
        Console.WriteLine(third.GetTop());
        Console.WriteLine(third.GetBottom());

        Console.WriteLine();
        Console.WriteLine(first.GetFractionString());
        Console.WriteLine(second.GetFractionString());
        Console.WriteLine(third.GetFractionString());

        Console.WriteLine();
        Console.WriteLine(first.GetDecimalValue());
        Console.WriteLine(second.GetDecimalValue());
        Console.WriteLine(third.GetDecimalValue());
    }
}