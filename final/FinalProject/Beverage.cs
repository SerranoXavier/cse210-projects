using System;

public class Beverage : Food
{
    public Beverage(int id, string name, double quantity, DateTime expirationDate) : base(id, name, quantity, expirationDate)
    {
    }

    public override void Display()
    {
        Console.WriteLine($"{_name} - {_quantity} L - Best before {_expirationDate}");
    }
    public override string AsText()
    {
        return $"{_name} - {_quantity} L - Best before {_expirationDate}";
    }
}