using System;

public class AlertQuantity : Alert
{
    public AlertQuantity(Food food) : base(food)
    {
    }

    public override void Display()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Low quantity for: ");
        Console.ResetColor();
        _food.Display();
    }
}
