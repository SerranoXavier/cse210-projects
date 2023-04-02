using System;

public class PackedFood : Food
{
    private string _packaging;


    public PackedFood(int? idLocation, int? idGroceryList, string name, string packaging) : base(idLocation, idGroceryList, name)
    {
        _packaging = packaging;
    }
    public PackedFood(int? idLocation, int? idGroceryList, string name, double quantity, DateTime expirationDate, string packaging) : base(idLocation, idGroceryList, name, quantity, expirationDate)
    {
        _packaging = packaging;
    }

    public override void Display()
    {
        if (_quantity <= 1)
        {
            Console.WriteLine($"{_name} - {_quantity} {_packaging} - Best before {DisplayDate(_expirationDate)}");
        }
        else
        {
            Console.WriteLine($"{_name} - {_quantity} {_packaging}s - Best before {DisplayDate(_expirationDate)}");
        }
    }
    public override string AsText()
    {
        if (_quantity <= 1)
        {
            return $"{_name} - {_quantity} {_packaging} - Best before {DisplayDate(_expirationDate)}";
        }
        else
        {
            return $"{_name} - {_quantity} {_packaging}s - Best before {DisplayDate(_expirationDate)}";
        }
    }
    public override string Export()
    {
        if (_quantity <= 1 )
        {
            return $"{_name} ({_packaging})";
        }
        else
        {
            return $"{_name} ({_packaging}s)";
        }        
    }
    public override void Save()
    {
        using (StreamWriter outputFile = new StreamWriter("Food.txt", true))
        {
            outputFile.WriteLine($"PackedFood~|~{_idLocation}~|~{_idGroceryList}~|~{_name}~|~{_quantity}~|~{_expirationDate}~|~{_packaging}");
        }
    }
    public override string GetPackaging()
    {
        return _packaging;
    }
}