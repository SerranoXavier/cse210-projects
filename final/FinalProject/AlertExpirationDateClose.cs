using System;

public class AlertExpirationDateClose : Alert
{
    public AlertExpirationDateClose(Food food) : base(food)
    {
    }

    public override void Display()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Expiration date close for: ");
        Console.ResetColor();
        _food.Display();
    }
}
