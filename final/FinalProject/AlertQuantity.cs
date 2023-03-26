using System;

public class AlertQuantity : Alert
{

    public AlertQuantity(int id, Food food) : base(id, food)
    {
    }

    public override void Display()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Low quantity for: ");
        _food.Display();
    }
}
