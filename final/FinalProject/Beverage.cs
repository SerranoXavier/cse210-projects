using System;

public class Beverage : Food
{
    public Beverage(int? idLocation, int? idGroceryList, string name) : base(idLocation, idGroceryList, name)
    {
    }
    public Beverage(int? idLocation, int? idGroceryList, string name, double quantity, DateTime expirationDate) : base(idLocation, idGroceryList, name, quantity, expirationDate)
    {
    }

    public override void Display()
    {
        Console.WriteLine($"{_name} - {_quantity} L - Best before {DisplayDate(_expirationDate)}");
    }
    public override string AsText()
    {
        return $"{_name} - {_quantity} L - Best before {DisplayDate(_expirationDate)}";
    }
    public override void Save()
    {
        using (StreamWriter outputFile = new StreamWriter("Food.txt", true))
        {
            outputFile.WriteLine($"Beverage~|~{_idLocation}~|~{_idGroceryList}~|~{_name}~|~{_quantity}~|~{_expirationDate}~|~");
        }
    }
}