using System;

public class AlertExpirationDate : Alert
{

    public AlertExpirationDate(int id, Food food) : base(id, food)
    {
    }

    public override void Display()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Expiration date close for: ");
        _food.Display();
    }
}
