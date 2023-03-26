using System;

public class Location
{
    private int _id;
    private string _name;
    private List<Food> _listFood;


    public Location(string name)
    {
        _id = 0;
        _name = name;
        _listFood = new List<Food>();
    }
    public Location(int id, string name, List<Food> listFood)
    {
        _id = id;
        _name = name;
        _listFood = listFood;
    }

    public void DisplayFoods() // if empty to handle
    {
        Console.WriteLine(_name);
        Console.WriteLine();

        for (int index = 0; index < _listFood.Count(); index++)
        {
            Console.WriteLine($"{index + 1} - {_listFood[index].AsText()}");
        }
    }

    private void AddBulkFood()
    {
        Validator validator = new Validator();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        double quantity = validator.GetValidDouble("Enter quantity (kg):");

        BulkFood newFood = new BulkFood(0, name, quantity);
        _listFood.Add(newFood);
    }
    private void AddBeverage()
    {
        Validator validator = new Validator();
        
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        double quantity = validator.GetValidDouble("Enter quantity (L):");

        DateTime expirationDate = validator.GetValidDate("Enter expiration date:");

        Beverage newFood = new Beverage(0, name, quantity, expirationDate);
        _listFood.Add(newFood);
    }
    private void AddPackedFood()
    {
        Validator validator = new Validator();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        int quantity = validator.GetValidInt("Enter quantity:");

        Console.Write("Enter packaging (can, pack...): ");
        string packaging = Console.ReadLine();

        DateTime expirationDate = validator.GetValidDate("Enter expiration date:");

        PackedFood newFood = new PackedFood(0, name, quantity, expirationDate, packaging);
        _listFood.Add(newFood);
    }
    public void AddFood()
    {
        Menu addFoodMenu = new Menu("Add Food");
        addFoodMenu.AddMenuOption(1, "Bulk Food");
        addFoodMenu.AddMenuOption(2, "Packed Food");
        addFoodMenu.AddMenuOption(3, "Beverage");
        addFoodMenu.AddMenuOption(4, "Back to Main Menu");
        
        int option = -1;

        do
        {
            option = addFoodMenu.AskOption("Which item do you want to add?");
            switch(option)
            {
                case 1:
                {
                    AddBulkFood();
                }
                break;
                case 2:
                {
                    AddPackedFood();
                }
                break;
                case 3:
                {
                    AddBeverage();
                }
                break;
            }
        } while (option != 4);

    }
    public void RemoveFood() // if empty to handle
    {
        Validator validator = new Validator();

        DisplayFoods();
        Console.WriteLine();
        int index = validator.GetValidInt("Wich item do you want to remove?") - 1;
        _listFood.RemoveAt(index);
    }
    public string GetName()
    {
        return _name;
    }
}