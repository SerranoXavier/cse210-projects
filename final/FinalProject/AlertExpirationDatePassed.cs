using System;

public class AlertExpirationDatePassed : Alert
{
    public AlertExpirationDatePassed(Food food) : base(food)
    {
    }

    public override void Display()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Expiration date passed for: ");
        Console.ResetColor();
        _food.Display();
    }
}
