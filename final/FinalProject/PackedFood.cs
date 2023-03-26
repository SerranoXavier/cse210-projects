using System;

public class PackedFood : Food
{
    private string _packaging;


    public PackedFood(int id, string name, double quantity, DateTime expirationDate, string packaging) : base(id, name, quantity, expirationDate)
    {
        _packaging = packaging;
    }

    public override void Display()
    {
        Console.WriteLine($"{_name} - {_quantity} {_packaging} - Best before {_expirationDate}");
    }
    public override string AsText()
    {
        return $"{_name} - {_quantity} {_packaging} - Best before {_expirationDate}";
    }
    public override string Export()
    {
        return $"{_name} ({_packaging})";
    }
}