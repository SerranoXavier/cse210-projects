using System;

public class FruitVegetable : BulkFood
{
    public FruitVegetable(int? idLocation, int? idGroceryList, string name) : base(idLocation, idGroceryList, name)
    {       
    }
    public FruitVegetable(int? idLocation, int? idGroceryList, string name, double quantity) : base(idLocation, idGroceryList, name, quantity, DateTime.Today.AddDays(14))
    {       
    }
    public FruitVegetable(int? idLocation, int? idGroceryList, string name, double quantity, DateTime expirationDate) : base(idLocation, idGroceryList, name, quantity, expirationDate)
    {       
    }
    public override void Save()
    {
        using (StreamWriter outputFile = new StreamWriter("Food.txt", true))
        {
            outputFile.WriteLine($"FruitVegetable~|~{_idLocation}~|~{_idGroceryList}~|~{_name}~|~{_quantity}~|~{_expirationDate}~|~");
        }
    }
}