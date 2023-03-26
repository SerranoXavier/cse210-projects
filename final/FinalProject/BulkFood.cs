using System;

public class BulkFood : Food
{
    public BulkFood(int id, string name, double quantity) : base(id, name, quantity, DateTime.Now.AddYears(1))
    {       
    }

    public override void Display()
    {
        Console.WriteLine($"{_name} - {_quantity} kg - Best before {_expirationDate}");
    }
    public override string AsText()
    {
        return $"{_name} - {_quantity} kg - Best before {_expirationDate}";
    }
}