using System;

public class BulkFood : Food
{
    public BulkFood(int? idLocation, int? idGroceryList, string name) : base(idLocation, idGroceryList, name)
    {       
    }
    public BulkFood(int? idLocation, int? idGroceryList, string name, double quantity) : base(idLocation, idGroceryList, name, quantity, DateTime.Today.AddYears(1))
    {       
    }
    public BulkFood(int? idLocation, int? idGroceryList, string name, double quantity, DateTime expirationDate) : base(idLocation, idGroceryList, name, quantity, expirationDate)
    {       
    }

    public override void Display()
    {
        Console.WriteLine($"{_name} - {_quantity} kg - Best before {DisplayDate(_expirationDate)}");
    }
    public override string AsText()
    {
        return $"{_name} - {_quantity} kg - Best before {DisplayDate(_expirationDate)}";
    }
    public override void Save()
    {
        using (StreamWriter outputFile = new StreamWriter("Food.txt", true))
        {
            outputFile.WriteLine($"BulkFood~|~{_idLocation}~|~{_idGroceryList}~|~{_name}~|~{_quantity}~|~{_expirationDate}~|~");
        }
    }
}