using System;

public class GroceryList
{
    private int _id;
    private int _idHome;
    private string _name;
    private List<Food> _listFoods;


    public GroceryList(int id, int idHome, string name)
    {
        _id = id;
        _idHome = idHome;
        _name = name;
        _listFoods = new List<Food>();
    }
    public GroceryList(int id, int idHome, string name, List<Food> listFood)
    {
        _id = id;
        _idHome = idHome;
        _name = name;
        _listFoods = listFood;
    }
    public void Display()
    {
        Console.WriteLine(_name);
        Console.WriteLine();
        if (_listFoods.Count() == 0)
        {
            Console.WriteLine("This Grocery List is empty.");
        }
        else
        {
            for (int index = 0; index < _listFoods.Count(); index++)
            {
                Console.WriteLine($"{index + 1} - {_listFoods[index].Export()}");
            }
        }
    }
    public void Export()
    {
        Spinner spinner = new Spinner();
        if (_listFoods.Count() == 0)
        {
            Console.WriteLine("This Grocery List is empty.");
            spinner.Wait(2);
        }
        else
        {
            // Ask for the file name
            Console.Write("What is the filename for the grocery list file? ");
            string fileName = Console.ReadLine();

            // Write the grocery list into a file
            if (!fileName.Contains(".txt"))
            {
                fileName += ".txt";
            }
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(_name);
                outputFile.WriteLine();
                foreach (Food food in _listFoods)
                {
                    outputFile.WriteLine($"[ ]  {food.Export()}");
                }
            }
        }
    }
    public void RemoveFood()
    {
        Validator validator = new Validator();
        Spinner spinner = new Spinner();

        if (_listFoods.Count() == 0)
        {
            Console.Clear();
            Console.WriteLine(_name);
            Console.WriteLine();
            Console.WriteLine("The Grocery List is empty.");
            spinner.Wait(2);
        }
        else
        {
            int input = -1;

            while (input != 0)
            {
                Console.Clear();
                Display();
                Console.WriteLine();

                input = validator.GetValidInt("Which item would you like to remove (type 0 to come back to Edit Grocery List)?", _listFoods.Count(), false);
                int index = input - 1;
                if (input == 0)
                {
                }
                else
                {
                    _listFoods.RemoveAt(index);
                    Console.WriteLine("The item has been removed.");
                    spinner.Wait(2);
                }
            }
        }
    }
    private void AddBulkFood()
    {
        Validator validator = new Validator();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        BulkFood newFood = new BulkFood(null, _id, name);
        _listFoods.Add(newFood);
    }
    private void AddFruitVegetable()
    {
        Validator validator = new Validator();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        FruitVegetable newFood = new FruitVegetable(null, _id, name);
        _listFoods.Add(newFood);
    }
    private void AddBeverage()
    {
        Validator validator = new Validator();
        
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Beverage newFood = new Beverage(null, _id, name);
        _listFoods.Add(newFood);
    }
    private void AddPackedFood()
    {
        Validator validator = new Validator();

        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter packaging (can, pack...): ");
        string packaging = Console.ReadLine();

        PackedFood newFood = new PackedFood(null, _id, name, packaging);
        _listFoods.Add(newFood);
    }
    public void AddFood()
    {
        Menu addFoodMenu = new Menu("Add Food");
        addFoodMenu.AddMenuOption(1, "Fruits or Vegetables");
        addFoodMenu.AddMenuOption(2, "Packed Food");
        addFoodMenu.AddMenuOption(3, "Beverage");
        addFoodMenu.AddMenuOption(4, "Bulk Food");
        addFoodMenu.AddMenuOption(5, "Back to Edit Grocery List");
        
        int option;

        do
        {
            option = addFoodMenu.AskOption("Which item do you want to add?");
            switch(option)
            {
                case 1:
                {
                    AddFruitVegetable();
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
                case 4:
                {
                    AddBulkFood();
                }
                break;
            }
        } while (option != 5);

    }
    public void AddExistingFood(Food food)
    {
        string name = food.GetName();
        double quantity = food.GetQuantity();
        DateTime expirationDate = food.GetExpirationDate();

        if (food is Beverage)
        {
            Beverage beverage = new Beverage(null, _id, name, quantity, expirationDate);
            _listFoods.Add(beverage);
        }
        if (food is BulkFood)
        {
            if (food is FruitVegetable)
            {
                FruitVegetable fruitVegetable = new FruitVegetable(null, _id, name, quantity, expirationDate);
                _listFoods.Add(fruitVegetable);
            }
            else
            {
                BulkFood bulkFood = new BulkFood(null, _id, name, quantity, expirationDate);
                _listFoods.Add(bulkFood);
            }
        }
        if (food is PackedFood)
        {
            string packaging = food.GetPackaging();
            PackedFood packedFood = new PackedFood(null, _id, name, quantity, expirationDate, packaging);
            _listFoods.Add(packedFood);
        }
    }
    public void Save()
    {
        using (StreamWriter outputFile = new StreamWriter("GroceryList.txt", true))
        {
            outputFile.WriteLine($"{_id}~|~{_idHome}~|~{_name}");
        }
        foreach (Food food in _listFoods)
        {
            food.Save();
        }
    }
    public void LoadFood(string fileFood)
    {
        string[] lines = System.IO.File.ReadAllLines(fileFood);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            string type = parts[0];
            int idGroceryList;
            if (int.TryParse(parts[2], out idGroceryList))
            {
                idGroceryList = int.Parse(parts[2]);
            }
            else
            {
                idGroceryList = -1;
            }
            string name = parts[3];
            double quantity = double.Parse(parts[4]);
            DateTime expirationDate = DateTime.Parse(parts[5]);
            string packaging = parts[6];

            if (idGroceryList == _id)
            {
                if (type == "PackedFood")
                {
                    PackedFood packedFood = new PackedFood(null, idGroceryList, name, quantity, expirationDate, packaging);
                    _listFoods.Add(packedFood);
                }
                else if (type == "Beverage")
                {
                    Beverage beverage = new Beverage(null, idGroceryList, name, quantity, expirationDate);
                    _listFoods.Add(beverage);
                }
                else if (type == "BulkFood")
                {
                    BulkFood bulkFood = new BulkFood(null, idGroceryList, name, quantity, expirationDate);
                    _listFoods.Add(bulkFood);
                }
                else if (type == "FruitVegetable")
                {
                    FruitVegetable fruitVegetable = new FruitVegetable(null, idGroceryList, name, quantity, expirationDate);
                    _listFoods.Add(fruitVegetable);
                }
            }
        }
    }
    public string GetName()
    {
        return _name;
    }
}

